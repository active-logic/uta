# Atom integration notes

## Make a language package

First we call [⌘ + SHIFT + P] to run the "Generate Language Package" command.
- We pick the location of the created package
- Atom generates an alias/symlink within ~/.atom/packages

Now, what happens if we then uninstall our package? The alias is
removed, and we keep our package. Atom does not have an option to install a "local package" so we then would have to either directly checkout/clone into ~/.atom/packages, or make a symlink ourselves.

## Making a simple grammar

Okay we've done that.

## Up the NPM package

In short

```
npm version x.x.x && npm publish
```

## Install the language package

I cloned my repository directly under ~/.atom/packages.

```
cd ~/.atom/packages
git clone https://github.com/eelstork/language-howl
cd language-howl
apm install
```

That's an error...

```
make: *** No rule to make target `Release/obj.target/tree_sitter_Howl_binding/src/parser.o', needed by `Release/tree_sitter_Howl_binding.node'.  Stop.
```
Not 100% what to make of this but. I can install v0.1.5 - let's diff them.
Except there is no 0.1.5 version. But well, 0.1.4 does work too.

So I just moved my new grammar to 0.1.5 (there was one after all), branched, and
made a 0.1.9 from that. What did I break in between? Don't know. apm install
works okay now.

## Coloring

I'm going to work from ~/.atom so, learned a new thing. When adding a new project, ⌘ + SHIFT + DOT(.) to show hidden things.

Now I'm back to `language-howl`, the atom package per se.

My simple problem is to match parser names to syntax names. Via the so called `scopes` of `howl.cson`

I've been hacking away for a bit. Several reasons.
The first problem is finding what the style names even are.

For example, I looked here:
https://github.com/atom/language-javascript/blob/master/grammars/tree-sitter-javascript.cson

So the (CSS?) classes are 'usually' to the right hand side. This is pretty fuzzy. Gets worse when trying to understand C# coloring.
I just lifted a few classes that seem to fit.

Maybe reading "creating a theme" will help... ?

Now looking around here:

https://github.com/iakhator/atom-one-dark-syntax/tree/df7c299750262895ccd7641c2befb39e0bed0652/styles/syntax

If I open one of these... seems like it's done like this, where:

```
&.syntax--other.syntax--uni
>>
other.uni
//
.syntax--string.syntax--quoted.syntax--json
string.quoted
```

So maybe I should just look here and apply this rule:

https://github.com/iakhator/atom-one-dark-syntax/blob/df7c299750262895ccd7641c2befb39e0bed0652/styles/syntax/_base.less

And uhm, apparently if I just create a theme they will pre-populate these names.
Sigh.

## The other problem being...

My syntax is more broken than I think... sort of.
The prominent issue here is, Howl aliases are not automatically added just yet.

With a token effort in this direction, coloring looks better. Not great but, better.

## Automate

The next step should be, refine my style classes, and automate Howl rule injection into the grammar.

I could make an "other chars" class but this seems like doing it wrong.

My guess is matching can happen without tree-sitter, which needs compile and publishing. But this is a problem for another day.

## Missing classes

I need to add classes to scopes
