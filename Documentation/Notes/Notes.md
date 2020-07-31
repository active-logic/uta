# Notes

## "Just works" experience

### Howl with a new project

In the case of a new project, we install the howl package. Then the expectation is that the howl root should be auto-generated (works via UPM).

## Verbose mode for file sync operations

Enabled...

## Testing may cause "no-export" to be set

Could confirm that ConfigTest is unsafe; fixed

## Broke protecting commented and double quoted strings

Okay this is no regression. It just has never been done in export mode.

## The weird case of how Howl files are not in VCS

Not sure exactly what to make of this.
The immediate reason this happens is Howl files are under Assets; which is fine with a regular Unity project.
But in the case of a UPM library "Assets/Foo", only Foo is under VCS.
For now let's see if I can configure the Howl root.

## ImportConfig is too long, poorly named etc... (6.30)

The first thing we're going to do here is move serialization to a utility class.

## Change how symbol selection is serialized and reloaded

Okay let's have a look at how it works now...
We first call ImportConfig.Read() then ImportConfig.Write() if dirty. That's okay.

The only issue here is either not writing the whole map, or just reading the selector status.

## Make no-import syms available for selection (40 minutes)

Took a while with refactoring etc

## Nitpicking causes an import loop

Fixed for now. Should still file a task until I'm sure we're not double importing.

## Windows related

Fixed a number of bugs; mainly caused by path comparison issues and differences in file management.
Still need to remove locking feature

## VS Code...

It looks like I need an extension:
https://code.visualstudio.com/api/language-extensions/snippet-guide
And probably with a language id:
https://code.visualstudio.com/docs/languages/identifiers

K it doesn't look they'll just let me type my extension without installing junk.

So, homebrew.
https://changelog.com/posts/install-node-js-with-homebrew-on-os-x

Then

```
npm install -g yo generator-code
```

As an aside, I can use my snippets through the "plaintext" mode, just
needed to fix them a little.

Somehow made a template for howl language support. Looks like I can sideload the extension.
https://vscode-docs.readthedocs.io/en/stable/extensions/install-extension/

Let's try.

```
🍙 cp -r howl ~/.vscode/extensions
```

Note: [⌘ + K + M] to view available languages

And well... no luck? Uh after a long time figured because I aliased Howl from ~/ I copied the unity project to VS code.

SIGH

So it seems I can just sideload this thing to ~/.vscode/extensions/howl and I'll be good.

## VS for mac take 2

Looking here:
https://docs.microsoft.com/en-us/visualstudio/ide/adding-visual-studio-editor-support-for-other-languages?view=vs-2019

So there could be something under ~/.vs/Extensions
Right now there isn't. Well. There are no extensions, so that's okay.

So I'm going to leave this alone for now. Way too annoying.

Well. Rationale behind this:
- VS for mac looks a revamped version of Monodevelop
- It is different from visual studio. So that's not going to help windows users either way.
- It's also different from VS code

## Using "Visual studio for Mac"

I go to snippets under preferences

*Visual Studio > Preferences > Text Editor > Code Snippets*

Top right I select "Add". So that created a snippet in a nameless folder (folders are per language).

I can put it in a Howl "group" but this does not change that the folder still looks nameless mmh?
Okay... appears under Howl after I reopen preferences.

As a case in point there is apparently no snippet support in howl files... for now.

I'm going to change the snippet mime type to text/plain.

Nothing.

## Import time conversions

For specific symbols, a conversion is effected on import. This is implemented via Howl.Polish()

## More snippet stuff

- `=>` prefix is empty; same goes for all operators
- I am not going to manually update this list again.
- In places, not sure the "full word" approach is going to work
(spacing related; in other words the choice is to insert spaces manually, or develop a more structured snippet; take `⟳ ` as an example)
- Seems that for compounds, prefixes may be too long

=================

~ Some snippets probably can't be used (actually they can)

## Better snippets

I have made a tool to translate snippets. Based on the default C# snippets for atom, this is not satisfying.

1) For a person who like Atom snippets for C#, many shorthands are going to be missing. So, it's a matter of adding the shorthands.

2) Snippets are actual 'shorthands' - contracted 2/1 letter forms.
Legitimately an alternative to that based on the actual keywords being replaced will make sense.
It would make sense to me, to other programmers who don't care for "shorthands" and quite possibly to a coder who use snippets, but aren't used to atom snippets.

3) A decision is needed for how compound keywords will be handled.

4) There will be no sane snippets for operator contractions. Well; put another way snippets starting with symbols (such as '=') are ignored. So, these should be translated on import. Optionally, give an option to spell them out.

### King's own

Guess I'll make my own for now; will end up taking time so I'll build a list mechanically first.
Works; a little testing shows that spaces must be inserted after symbols.
Because, when the caret is placed after a non alphanumerical
character, auto-complete appears, but does nothing.

Duplicate snippets are not allowed. This applies to same-name snippets. I remove duplicates but I'm seeing too many of these... apparently.

The number of duplicates is correct; some snippets I will drop because they should be explicitly disabled; they are few.

Some snippets need a dedicated name.

## Adding snippet support

First things first; language snippets for C# are defined as part of the language pack, here:
https://github.com/atom/language-csharp

I could probably hack the C# language pack to create a howl pack. But for now I really just want a method to generate snippets.

Since the notation may evolve, I also (ideally) want snippets to be auto-generated from the C# version.

### Persist Atom config on github

Atom config has a predefined .gitignore file...

### Test snippets

A quick test shows gaps in translation; now fixed

## Detecting conflicts

We can detect a conflict inside an input string. On import this is something like:

```
x = x / map;  // may have conflicts.
```

## How do we generate thousands of lines for 'Actor'?

Let's make a functional test around this source file.
So we can see that this error is related to comments.
It looks like the occurence of a comment causes the source file to recur.

Caused by consolidating the input

## Fix 'using errors' in export

In export, I find:

`using float = System.Single;  using bool = System.Boolean;`

This is not as intended. Specifically there should be a remove rule for this.

Remove rules are broken because `using` has a mapping to `♖`

## Lock and hide C# files

### Wanted behaviour

The basic behavior is simple. Upon running "Generate Howl source", I want to lock the original C# files.
So that's a change to Howl.ImportFile.

Works; having said that it's far from perfect. Atom will just request
a permission to write. If we grant this, it then goes on to override files anyway.

For now, this is fine.

### Spike

First let's see to what extent I even can lock/hide files on macOS.

- I can set the hidden attribute via `FileAttributes` but this does not do anything. Still, should be fixed somewhere in C#, see here:
https://github.com/dotnet/runtime/issues/25989
- I can hide files via `chflags hidden test.xyz`
- I can view the macOS hidden status via `ls -Ola`

As to locking files:
- Looks like I can set a file to 'eadonly'
- Once eadonly I can't make it writable again but it would
seem that I can delete the file and make it again, which does the same thing.

## Linq notation

↦ x ∊ list ¿ cond ፥ x

## Whitespace discards

The easiest approach to discards is including whitespace inside the base definition.
This applies to modifiers, which are:
- public, protected, internal, private
- abstract, const, override, extern, partial, eadonly, sealed, static, unsafe, virtual, volatile

## Better whitespace control

We don't want to add too many spaces.
Specifically, if a symbol is not followed by a letter or digit,
it is safe.
Unless the next symbol is itself soft.

## Whitespace on export

This applies to a number of mappings, notably when the source is an alphanumerical keyword (such as 'public') and the target is a symbol.
Where the source and target are both symbols, the problem does not exist.

So, let's consider an `Air(string, char[])` function which is used to add such whitespace.

In a first approximation:

```cs
ㄹ Air(ㄹ ㅂ, char[] S)
=> (from c in ㅂ select c.Consolidate(against: S)).Join();
```

Where `S` is a set of "soft" symbols, and Consolidate()

```cs
ㄹ Consolidate(this char c, char[] S)
=> new ㄹ(c) + S.Contains(c) ? " " : null;
```

Then we need a function to extract soft symbols (Map.cs)

```cs
public char[] operator ! (Map m)
=> (from x in m.rules where !x select x.a[0]).ToArray();
```

A definition of `!x` (for 'soft') is added to Rep.cs

Finally, integrate solution with `Map` and functional test.

## Asset move and delete operations

When a howl file is deleted, we of course want the matching C# file to also be deleted.
Let's create a functional test for this.
Now, let's implement this.

```cs
if(π.IsHowlSource()) AssetDatabase.DeleteAsset(π.OutPath());
```

These functions already exist, but we need to migrate them and improve them a little.

Good so far. Now, the move operation; first, the test; next, the implementation.

Getting the functional test to work was... a bit tricky, mostly
because of small differences between asset ops via Unity's AssetDB and file system ops.

There's a couple more cases to cover. What if...
- We moved a howl asset outside the howl source dir?
- We moved a howl asset from outside the howl source dir, to within?

First the inbound operation. In this case a new C# file needs to be generated, unless allowExport is enabled

Now the outbound operation. In this case a C# file needs to be
deleted, unless:
- allowExport is disabled
- or no such file existed in the first place.

## References

Kaomoji
http://kaomoji.ru/en/
Alt-codes
https://www.alt-codes.net/math-symbols-list
Rapid-tables
https://www.rapidtables.com/math/symbols/Basic_Math_Symbols.html
Unicode-Search.net
https://unicode-search.net/
