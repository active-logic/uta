## Tree Sittin'

### Regicide?

First we want to match strings. We'll find inspiration in the [C# grammar](https://github.com/tree-sitter/tree-sitter-c-sharp/blob/df20955232ad36a348764ff002313df92321a31a/grammar.js)

There, we find matches for `string` and `string_literal`. Verbatim string looks easy:

```
verbatim_string_literal: $ => token(seq(
      '@"',
      repeat(choice(
        /[^"]/,
        '""',
      )),
      '"'
    )),
```

Seeing matches for that in my makeshift grammar. Also seeing that parsing simple input causes an error. How I understand this to be an error is because there is no unification. verbatim literals currently don't unify with "source_file" {1}

Since my goal is simple, I only need a grammar that recognizes elements, where an element can be a string or 'something else'.

Abbreviating somewhat, we get this:

```
Σ   : $ => repeat($._e),
_e  : $ => choice($.str, $.id),
id  : $ => /[a-z]+/,
str : $ => token(seq(
    '@"', repeat(choice( /[^"]/, '""', )), '"'
))
```

Where Σ, the target symbol ("source file"), and e, an element which can be a verbatim string str, or an identifier id.

My example...

```
return @"my litt"
hello
```

...parses:

```
(Σ [0, 0] - [2, 0]
  (id [0, 0] - [0, 6])
  (str [0, 7] - [0, 17])
  (id [1, 0] - [1, 5]))
```

Right now I don't want to deal with differences between verbatim, interpolated and non interpolated strings. However removing '@' from the string definition causes an error (it's not "a-z" and isn't a string either... so, what is it?)

I want to match more! For example this matches all but whitespace and backslashes.

/[^\s\\]/

(via https://stackoverflow.com/questions/6125098/how-to-match-any-non-white-space-character-except-a-particular-one)

However it matches only one char at a time... fiddling a bit, my new "id" rule:

```js
id  : $ => /[^\s"]+/,
```

Here...

```
@"my litt" $"bar"
```

...there's now four elements - two strings and two identifiers ($ and @). Bit rough but enough for our purpose.

Remember, we want the following:

- String literals
- Comments
- Keywords
- Aliases

### No comment...

In the C# grammar, 'comment' matches 3 times. Both C and C++ style comments are defined single handedly. Nice fit

### Keywords

My keyword definition starts like this:

```
key: $ => 'return',
```

But I want to match many keywords, so, 'choice'?

```
key: $ => choice('class', 'return', 'end'),
```

### Matching symbols

Howl uses a lot of symbols. Initially it looks like symbols are the same as keywords:

```
sym: $ => choice('⤴', '⤵')
```

However that is not the case... At least in how originally intended symbol chars are also breaking chars. Whereas Tree-sitter interprets this...

```
⤵hello
```

As just one identifier. Because of how its tokenizer works... maybe... or not?

```
+hello
```

Yea, this also matches as one identifier; our regex for these is too greedy. So how about this?

```
[\u0000-\u007F]+
```

Not going to lie. This one sent Tree-sitter snoozing for a bit.

The same [source](https://stackoverflow.com/questions/150033/regular-expression-to-match-non-ascii-characters)

Has a range of erm... alternatives? This one...

```
/[\u00C0-\u1FFF\u2C00-\uD7FF\w]+/
```

...does not hang the parser. Only problem is now, '@+$' are interpreted as errors.

So I created a 'z' class for everything operator bracket etc

```
z: $ => choice(/[!-@]/, /[\x5b-\x60]/, /[\x7b-\x7d]/)
```

(ref, this [beauty](http://www.asciitable.com))

### The extra mile?

There are more literals; I just lifted them from the C# grammar.

However...

I could parse everything, except ints. Then, either:
- One of my definitions conflicts with what an 'int' is supposed to be... or
- That definition of integer literals is not standalone.

And yet, what is so special about it?

Maybe nothing.

I'm making an assumption here, that 'choice' has a precedence order. The order could be fortuitous.

The real issue here is how I defined 'id'.

Of course an identifier cannot start with a digit. And this is the problem here.

### Oh wow

We're still lacking support for directives but definitely covered the basics. For polish we could lift the 'extras' field but this adds significant overhead to parsing (really) so I'll take a pass for now.
