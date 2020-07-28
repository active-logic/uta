# Atom integration notes

# Now, a workflow?

So, in a loop, it looks like I will...
- Update the tree-sitter grammar.
- Make sure apm gets the update.
- Update `howl.cson` in the `language-howl` package
- Reload the atom window to see the result.

This workflow seems a little painful. Meanwhile, although tree-sitter does syntax coloring, it does it in a different way so... I don't know.

Let's start with the simplest thing. I'm just going to highlight C# keywords. Then I would also highlight howl symbols.
It has to be simple, because there are literal strings, not patterns.

Then I would match the following too:
- Comments (C/C++ style)
- Literal strings
- Everything else

And frankly that would be enough for a good start like, have something here

## Tree-sitter woes?

Okay this wasn't working but just needed to restore stuff i removed from my bash profile.

# Uh but about the coloring?

The manual here starts mumbling about "scopes". Without of course telling us where they should be defined.

Scopes are defined in the `foo.cson` file that glues the tree-sitter grammart to the atom language-foo package.

Sure enuf adding this to howl.cson produces some crazy coloring.

Or maybe not so crazy uh

This put me on track for making a bit of coloring even work:

https://github.com/Aerijo/language-relaxng/blob/1b76de70bf49f498b467c8b434e0619ac7a058f0/grammars/tree-sitter-relaxng-compact.cson

## Got some answers

The short answer is to do an `apm install` inside the `language-foo` package.
This works provided that `tree-sitter-foo` is a dependency in the language's package.json file.

Why it works?
=> package.json declares dependencies
=> `require(pkg)` on its own does not download anything.

## Did I start on the wrong node?

A grating thing in all that is: why do I have node/npm version conflicts at all?
I had sym-linked my package to `.atom/packages` so I moved the actual source there instead, thinking that might cause conflicts of sorts.

Also, I added this to my `~/.bash_profile`; let's remove this stuff:

```
export PATH=$PATH:./node_modules/.bin
export PATH=$PATH:/usr/local/bin
```

Now let's go back to school for a bit

## After this

I found that I can install my `tree-sitter-howl` directly under language-howl via `npm i tree-sitter-howl` and that would be picked up.

Sadly, atom tells me NODE_MODULE_VERSION is now 72

## Found U Wuheh

After waiting something between one or two hours, the package became visible. Feel is without much contribution on my part, reloading the atom window came with

```
...was compiled against a different Node.js version using
NODE_MODULE_VERSION 83. This version of Node.js requires
NODE_MODULE_VERSION 70. Please try re-compiling or re-installing
```

Update Atom? Maybe... not.
My npm is probably too new... I guess.

`npm version` shows that there's an actual "modules" node (or nodes module!?) with a version number of 83. Sigh.

So anyway. I tried downgrading the so called "modules". No luck. I tried downgrading NPM. Bad luck as this created a conflict between NPM and node.js ("nvm?").

Well, atom --version returns node 12

So it's time I remember (dimly) that I brewed node. Now `brew uninstall node && brew install node@12.0.0` ... hopefully?

Nope.

Eventually I got here:
https://nodejs.org/download/release/v12.0.0/

And grab a pkg. Uhm. To be on the safe side I also cleaned my tree-sitter-howl directory and re-install the tree-sitter CLI and nan.

## Where is the tree-sitter package?

So, fact remained that my freshly published grammar did not appear in atom.
A github search ("scopeName tree-sitter fileTypes") on code brought up 415 results and a simple thing: it should *just* work.

This does:

```
npm i tree-sitter-howl
```

Anyway. Hoping to smooth things over I tried adding a couple of things to `tree-sitter-howl`. Upgrading on the NPM side has a trick to it

```
npm version 0.1.1  # increment that
npm publish
```

Another note is wanting to test my package install I ran `npm i tree-sitter-howl` and got a few warnings. Now, the way npm even works, these warnings actually referred to the CONTEXT. That is, we're trying to install within the current dir, and that is considered a "hosting package" which (if no package.json is defined) shows up as incomplete.

Which does not in any way incriminate the package we are installing.

## Create the atom package

https://github.blog/2016-08-19-building-your-first-atom-plugin/

In atom
[⌘ + SHIFT + P] => Generate Language Package

Then enter `language-FOO`; now this (which is currently empty) is installed (implicitly, by virtue of having just generated the same) via atom prefs.

And we are back to:

https://flight-manual.atom.io/hacking-atom/sections/creating-a-grammar/

I then edited grammars/FOO.cson to refer my NPM published grammar and for me it's time to remove this from my atom config:

```
customFileTypes:
  "source.cs": [
    "howl"
  ]
```

Now is a good time to find out... I mean, did we manage to even link \*.howl files to anything?

It didn't feel like things were working much. Notably because my howl (custom) snippets weren't picked up. Disable/enable the package got me an error too as (apparently) the link to my grammar is broken.

looking inside ~/.atom/packages I find that there is a COPY of my package there. Not sure what this should be fore. I mean, what's the point?

So I sym-linked my local version to ~/.atom/packages and so far it works.

At which point it's worth noting that we *do not need a grammar to support snippets*. Kind of what I wanted to hear but. Hoops.

Still, I've come this far and I would have a little syntax coloring, if at all possible.

## Publish the grammar

Now that we have a so called simple grammar...

Okay so from the atom doc I need to publish the grammar. There isn't a route described to use a local version whatever so, let's do this although it does feel a bit fresh.

`npm publish` does not work for me so erm, let's make an npm account. Now what.

`npm adduser` to add me

And `npm publish` ... go!

Yea that *is* fresh

## A simple grammar using tree-sitter

I followed the Tree-sitter doc which got me to setup a test/toy project. A casual workflow, then, is like this:

1) Add a rule to `grammar.js`
2) run `tree-sitter generate`
3) run `tree-sitter parse foo.bar` to see the parsing result

This is what my first grammar did look like:

```js
module.exports = grammar({

        name: 'Howl', word: $ => $.identifier, rules: {

            source_file: $ => repeat($._definition),
            _definition: $ => choice($.return, $.identifier),
            return     : $ => 'return',
            identifier : $ => /[a-z]+/,

        }
});
```

And my sample file:

```
return hello
```

## Do what?

In their words what I want is a language package, which would be named `language-howl`.

`language-text` may be a good place to start for somebody who (initially) only want a file association, and some snippets.

## References (atom packages)

Tree-sitter doc
http://tree-sitter.github.io/tree-sitter/creating-parsers

An older tree-sitter tutorial
https://gist.github.com/Aerijo/df27228d70c633e088b0591b8857eeef

Create a word count package (manual)
https://flight-manual.atom.io/hacking-atom/sections/package-word-count/

Create your first package (tutorial)
https://github.blog/2016-08-19-building-your-first-atom-plugin/

## References (languages and grammars)

Tree-sitter-starter
https://gist.github.com/Aerijo/df27228d70c633e088b0591b8857eeef#guide-to-your-first-tree-sitter-grammar

Talks about syntax col and other issues
https://discuss.atom.io/t/help-creating-a-grammar-from-scratch/52466/13

Create a new package for a custom language
https://discuss.atom.io/t/solved-creating-a-new-package-for-a-custom-language-in-atom/49380

Creating a grammar
https://flight-manual.atom.io/hacking-atom/sections/creating-a-grammar/

A tutorial on creating grammars; even seems to explain a little regex.
https://github.com/atom/flight-manual.atom.io/blob/7f11d44a3a618db2b0d79f2d5dc63d32ad85bb82/content/hacking-atom/sections/creating-a-grammar.md

Discussion on atom.io
https://discuss.atom.io/t/creating-a-custom-grammar-or-language-package/16711/12
