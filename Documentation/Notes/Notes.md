# Notes

## A rebuild

A rebuild

I synchronized the Howl repo on my Windows machine and this reveals an error in `ThatGUI.cs`. I find it hard to explain since both cs and howl files are in source control.

So I decided to do a Rebuild to clean things up. Well, Rebuild is still the nuclear option, let’s have a look.

- it is building files under Howl/Tests/Data.

Notes
- Syntax highlighting for directives is so-so, probably not handled well by grammar
- I added a directive to prevent building tests, however there is probably a use case for doing this properly...
Probably

## Bridging token evaluation issues.

When a token is bridging, we do not want to effect a straight `string.Replace`; instead we want to tokenize the rule's left hand and replace occurences of the lh sequence in tokenized input.

### Diff quality

- Clean StringArrayTest
- Format
- Continue symbol has changed

## Most used keywords (Antistar)

Antistar has a vocable of 5k words. Here are some of the most used.

Vector3 (614 times)
target
transform
position (404)
name
GameObject
GetComponent (235)
Debug
gameObject
Transform
Update
Start
enabled
Color
hit
up
======================= 100 times and less
input
message
magnitude
Find
Time
speed
FindObjectOfType
radius
AddComponent
zero
point
camera
duration
parent
forward
height
Player
Collider
collider
actor
time
Physics

## More things

- review reason for implied self argument.
- document provisional log.message, warn, err
- take Active logic seriously come on

## Todo later:

- Underscore not recognized as identifier start
- Check line 64 in Map.Howl

# Stats

I want to know what the largest files are, by line count.
For this purpose only interested in files exceeding 34 lines.

# Grammar questions

- What is "var"? Is var more like a "cat" or more like a "prim"
okay for now we'll treat "var" as a primitive type
- What is math π - for now it's represented as a primitive but
really it's a constant. So that makes it a literal?
- Append, Contains, ContainsKey, Exists, should be treated as "uppercase id"
- "that" should be treated as lowercase id

# Highlighting questions

- What is correct highlighting of operators
(check +, - vs / *)

# About the operator keyword

*Type conversion*
They are always public and static. the implicit/explicit keywords
must be placed prior to the operator
```
public static implicit operator byte(Digit d) => d.digit;
```

*Overloading*
Always public and static. the return type must be placed *before*
the operator keyword
```
public static Fraction operator /(Fraction a, Fraction b)
```

Therefore, in Howl
- operator is only used to refer overloading

# Support new assembly definitions

Currently, when a new assembly def is created, it is ignored... well. That's normal. I made it in the wrong place.
Still the same when I do it correctly.

# Why are Howl scripts imported twice?

- C# scripts outside the Howl build are not exported twice.
- Howl bound C# scripts are not exported twice.
- Disabling nit-picking does not change a thing.
- Howl.BuildFile() is called. BuildFile is a very short function (well... two) and there's no way it is re-writing the Howl source. Commenting out "Build" does not fix the issue.
- Commenting out the modification processor wholesale also does not fix this.

Well well. PostProcessor explicitly calling ADB.ImportAsset().

# Well designed log messages

In essence I want messages to be fun, non intrusive and, when needed, the ability to detail their content or view a message history.
Usually we do not want messages in the unity console.

## User messages: where/what

There's a few places where we want to emit messages:
- In response to explicit user action, including via the howl window and context menu
- In response to implicit user action, via the PostProcessor and ModificationProcessor

### Do not want duplicate import message on import

### Through the Howl window part 2 (-> 3.15)

First I should look up calls to:
Debug.Log et al.
UnityEngine.Debug.Log et al.

### So how am I going to ease my testing woes?

Look here
https://koukia.ca/how-to-remove-local-untracked-files-from-the-current-git-branch-571c6ce9b6b1

Then again, I'm not trying to test the actual actions at all.
Let's stay focused.

### Through the Howl window 1/2 (1:05-2:15)

They are:
Howl.Refresh
Howl.Rebuild
Howl.ImportAll
Howl.ExportAll
Howl.ReApply

I just want to check messages so maybe I'll disable action effects
for now as they are quite disruptive.
But then I also want to avoid legacy messages so, need to test this stuff properly.

???: seriously, is nitpicking going too far

## The API [11:15 - 1:05]

For user level messages I don't need log messages everywhere. So I am somewhat willing to import the API but this may not be a thing. Here are two options I consider

```
!  Log / $"message";  // log a warning
!! Log / $"message";  // log an error
+  Log / $"message";  // log information
```

```
log.warning / $"message";  // log a warning
log.message / $"message";  // log an error
log.error   / $"message";  // log information
```

All this is a pipe dream though. The C# compiler is going to bounce me for not issuing statements.

However let's have a look at what the compiler actually says:

**
Only...
- assignment,
- call,
- increment,
- decrement,
- await, and
- new object expressions can be used as a statement.
**

So we are not BOUND to call a function after all. It looks like we have at least one sweet hack at our fingertips.

Maybe something like this:

```
++ log.warning / "Foo";
```

Now *this* does not actually compile. Because '++' has higher precedence than div...

```
(++ log.warning) / "Foo";
```

...which makes ++ x / y; into a div expression.

For sake of argument, we could write it this way:

```
++ (log.warning / "Foo");
```

But here's another thing:

```
The operand of an increment or decrement operator must be a variable, property or indexer
```

So the closest we get to our wanted syntax is an assignment after all. Which maybe is okay.

# Document or fix escaped char issue

I will write a test and document.
Let's start with the double quote rule.

```
"Fox" box
```

That's two blocks. Now assume we add an escape like so:

```
"Fox\\" box
```

Should still be two blocks.

Interestingly this here also breaks the conversion.

```
if (suffix != "\"" || x[i] != '\"') ⮐ ✗;
```

Well. probably because it isn't valid C#. Double quotes in single
quotes should not be escaped.

So the fix here is counting parity on back-slashes before a double quote, assuming said double quote is a suffix candidate.

Let's take an example:

"\\\\""

# Reapply notation may not trigger a re-import

# Export while importing

The problem here is that, while the post-processor is importing, we may get an incoming call to `OnPreprocessAsset`.

The details of how this happens are somewhat unclear right now but there are a few possibilities:

1) Because we make changes to derived files, nested calls to the postprocessor may occur (that is, on the same stack).

2) If importing (not compiling) really takes time - and it does take up to seconds we could be making a concurrent edit in the code editor.

3) Again, while importing if Unity allocates multiple threads to asset processing, concurrent requests may be normal.

Let's test the third possibility. This should be easy enough.

Taking a pass on this. For now I will remove the `_importing` flag and focus on other issues.

# Update user actions (10.44)

Actions not implemented/bound:
- ReApply()
- ExportDir()

These have been implemented already via the context menu:

```
Do(Howl.ReimportFile, "Updating", ".howl");
Do(Howl.ExportFile, "Exporting", Path._Howl, Path._Asmdt);
```

```
∘ ┈ Do(⒜<ㄹ> α, ㄹ verb, params ㄹ[] types){
    ∙ Λ = Sel(types); ᆞ N = Λ⁝;
    ⤴ (N ☰ 0) Debug.Lg($"No input");
    ⤳ (N ☰ 1) Debug.Lg($"{verb} {Λ[0].FileName()}");
    ⤵         Debug.Lg($"{verb} {N} files");
    Λ.ForEach(α);
    AssetDatabase.Refresh();
}
```

## Update Window UI source (11:30-4:00)(6-7)(10-11)

## ImportFile test is broken

The reason is simple: it cannot find a file to import, because imported files are moved to `~build`.
This is part of a bigger problem: updating the build system means potentially breaking it. At some point I need to move away from this, and it probably means running a second instance on the side.

But for now I'm going to accomodate the added complexity.

Also, ImportFile works in dry mode anyway. So what more likely broke it is manual testing of user actions.

## Export/testing annoyances

Noticed I had a build dir inside the build dir.
Probably caused by running tests, maybe ImportDir?

Afaik although importdir was liable to cause this, it is running in dry mode while testing.

One thing I do see happening is cs files being generated while testing, which then end up in the build directory and cause errors.

ConflictHandlerFu looks responsible for this. But uh
why.

There was a confusion in Rename between "dry" and "withMetafile".
I did this v:v.

## Export/import assemblies

Well, this could have been fun. So to export the assembly
definition, this is what we do:
- Rename the .asmdt (assembly def token) to .asmedf
- Delete the assembly def token

Still getting an error

So this is a bug in `ExportAssemblyDefToken`
Specifically at `θ.Rename(σ, withMetaFile: ✓);`
Rename op choking on `if (m0.Exists()) File.Move(m0, m1);`

And telling me *the destination file is null*

(trace)

```
ArgumentNullException: Value cannot be null.
Parameter name: destFileName
System.IO.File.Move (System.String sourceFileName, System.String destFileName) (at <437ba245d8404784b9fbab9b439ac908>:0)
Active.Howl.IO.Rename (System.String ㅂ, System.String ㄸ, System.Boolean withMetaFile) (at Assets/Howl/~build/Howl/Editor/Util/IO.cs:58)
Active.Howl.Howl.ExportAssemblyDefToken (System.String π, System.Boolean dry) (at Assets/Howl/~build/Howl/Editor/Core/Howl.cs:55)
Active.Howl.Howl.ExportFile (System.String π, System.Boolean dry) (at Assets/Howl/~build/Howl/Editor/Core/Howl.cs:34)
```

## How.ExportFile (12:25-13.48)

ExportFile is similar to ImportFile, in reverse
First σ is the input path, but with the .cs extension
Then we call BuildFile and output the result to σ
We get the build path and delete the derived product, if any.

Interestingly that causes two kinds of error; first, it triggers the PostProcessor:

ArgumentException:
/Users/xxx/Documents/Howl/Assets/Howl/Editor/Unity/Onboarding/IOnboardingReqs.cs
is not a subpath of
/Users/xxx/Documents/Howl/Assets/Howl/~build/

And another, the howl files are not being deleted. Uhm did I do this?
Probably not.

As a case in point, restoring C# files that belong to an assembly can't be done randomly. All the files in that assembly need to move together. And we should also put the assembly back.

## Context menu actions

- Apply Symset (done)
- Refactor ContextMenu functions to use `Selected(filetype)` [done]
- ImportFile should use ImportString [done]
- Context menu actions should be disabled in build dir [done]
- Collection returned by `Selected` should not contain duplicates [done]
- cx menu actions to provide user feedback [done]

### Disable actions when build dir is included

I do not think I can use a pattern to detect elements on the
build path.

## Inconsistent behavior of `import` when using a custom build root

When the build root is implicitly set to `Assets/`
re-importing a directory will not only import unconverted C# sources; it will also reconvert already converted sources.

When the build root is Assets/~build, re-importing a directory will not reconvert sources.

So this is okay-ish. Real problem here is there is no option to apply the currently selected notation

## Custom highlighting/modif to solarized theme (workflow)
would like some highlighting in .md, and fix the gutter

## Review validating PostProcessor and ModificationProcessor operations [DONE]

Let's start with the modification processor.
First thing. I don't think `allowExport` makes sense; fix this later.

### Asset move operations

Reviewed

### Asset delete operations

1) if not allowing export, ignore [okay]

2) if a howl source file, delete the C# product [good].
=> Verify meaning of "IsHowlSource" [DONE]

3) if a file is howl bound (it is a build product), issue a warning [good]
=> Verify isHowlBound; okay, this means "file for which a howl source file exists". However, dep on `SourcePath`
[write a test to verify out-of-build files will trigger this?]

#### Broken tests

Okay so, a change I made breaks BuildPath_dir
That is because BuildPath relies on IsHowlSource and I just made this more stringent so it does not support directories anymore.
So what needs BuildPath to support directories?
This is needed to support moving directories.
So can we have a definition of IsHowlSource that supports directories? Should we want this?

The idea behind all this is, if we move a directory, and it has a counterpart in the ~build directory, the counterpart should move.

So the current definition for "howl source" is:
- It denotes a howl file.
- The path is in howl root (which means "in assets/")

This does not port to "howl directory". What is a howl directory?
A howl directory is a dir in howl root which has a counterpart in ~build. The counterpart MUST exist

For the purpose of syncing the build directory with operations in assets/ the only relevant question should be, does this directory or file have a counterpart in build~

So is there something else that needs IsHowlSource to accept directories?

HowlSource:
- In Howl.cs BuildFile used to verify this file is on the Howl path
- In ModificationProcessor used to decide whether to delete a build image [shouldbe "hasBuildImage"]
- Used to decide whether to move the counterpart of a directory (again "hasBuildImage")
- Used to decide whether a file is being moved outside the howl root (WillMoveHowlAsset) but there, check is redundant

In short, IsHowlSource is probably used wrongly wherever it is even used.

=> write and test HasBuildImage
=> remove broken tests for IsHowlSource
=> replace misuses of IsHowlSource

Uses of BuildPath
- in OnWillDeleteAsset (should support directory)
- in WillMoveHowlAsset (needs dir)

### Is a thing misusing SetExtension?

No...

## Updating the "import" functionality

Previously, import created files in the howl directory and did not move C# files.
In the updated version import should move C# files. The howl file replaces the C# file.

What ImportFile would now is just override the C# file and put it nowhere.

```
System.ArgumentException :
/Users/xxx/Documents/Howl/Assets/Howl/Tests/Data/Valid.cs.test
is not a subpath of
/Users/xxx/Documents/Howl/Assets/~build/
```

Okay so I was told I can't get a source path for the C# file. Which is correct. SourcePath is only to walk back from a build path.

So the source path is just π relative to Assets/, right?
Well not exactly. I need to set the extension, which is why I got this... probably

```
System.InvalidOperationException : Howl/Tests/Data/Valid.cs.test doesn't howl
```

I pass the test but it's not a great test since dry output.
SetExtension is fairly confusing. Does it change the extension of a path, or actually rename a file?

It renames a path.

I'm not sure how to properly handle dry runs but for now, let's look at the print output:

```
Import
Assets/Howl/Tests/Data/Valid.cs.test as
Assets/Howl/Tests/Data/Valid.cs.howl and move it to
Assets/~build/Howl/Tests/Data/Valid.cs.cs
```

So this is actually incorrect... maybe... or not?
I guess it's just a little of an oddity because the name of the
build product should be the same as that of the original source file. But that *would* work if I ran against Valid.cs -

I approached validating using dry run output candidly, and maybe that's okay.

## Smaller issues

- CopyFiles test broken
- .git not found - Fixed
- SourcePath is incorrect - Fixed

## The build root token

I now use a build root token. Question is how do I make this effective, so that C# files go to, say,

~build

I can create a ~build folder and move the token there. Then see what happens.

Well. For me this caused a rebuild and no howl.

Going the post-processor route then

## The build path

I renamed "Export" to "Build" and "OutPath" to "BuildPath"
Now the behavior of OutPath needs to change

## File management note

Although I can make it work well enough, derived product management in Howl is counter intuitive. In fact there are only two intuitive solutions:

1) use a hidden/build folder.
2) use a package

In both cases the arrangement is that user files (Howl, C#) can live anywhere inside the Asset folder, and also (later) in packages.

## Renaming scripts

Renaming a C# file currently raises
the "creating a new C# script on howl path" user error.

- Renaming a howl file
Expected: rename C# counterpart

- Renaming a howl dir
Expected: rename the C# counterpart

- Renaming a howl bound C# dir
Expected: flag unsafe operation
This is not implemented; reason something okay-ish happens for moving a C# file is a side effect of PostProcessor.

## Move howl file fails on true/false in fileopsfu

Fixed

## The inpath bug on refresh

From inpath /Users/xxx/Documents/Howl/Assets/Howl/Howl.Src/Howl/Editor/Unity/PostProcessor.howl

Gen outpath
Assets/Howl/Assets/Howl/Howl.Src/Howl/Editor/Unity/PostProcessor.cs

## More on refresh and accidental edits

I have two kind of errors appearing on refresh, in connection with dropping changes on commit.

One error is when cs files are generated under howlRoot/assets/...

Another is where C# files have been labelled "without counterpart".
Likely here is that an incorrect inPath is generated for some files.

In other words for a file like Assets/foo.cs the inPath is probably wrong.

Let's get this sorted slowly.

## Preventing accidental edits to C# files

The .atom configuration itself is under .atom/storage/application.json
It may be possible to use this to open the howl root in atom. So this is potentially a useful thing.

Now, when the user edit a C# file, normally we receive a notification. However we need to know whether the edit is machine-wise or user-wise.

Well could be just setting the date of the C# file ourselves.

Then we know that, if the C# file is newer, and there is a Howl counterpart, the edit is a user/external edit that's unstable.

## A kink in rebuild/refresh

isHowlSource does not work with full paths

## Rebuild/Refresh

Right now the method used for this is... ...no good.
The main thing is we don't want to have all sources reimport.

Half of the solution is changing needed files then this:

```cs
AssetDatabase.Refresh ();
```

Causing changes to get picked automatically; the other half is, date modified is available and accurate.

Refresh replaces rebuild. Refresh will export all "new" files then call ADB.Refresh()

Now, "new" means newer than the config date time. So what is that?

- Whenever a file is imported via `OnPreprocessAsset` config updates to current time.
- When the config is initialized it also updates.

Let's do a few test to see that this works.
First we can postpone calling ADB.Refresh() in PostProcessor.

Expected behavior: no new files export on refresh, but unity
does import things.
Actual behavior:
- provided the post-processor is called, C# file is updated even though we didn't call import or refresh.
- OnPreprocessAsset did fail to be called. We then could see that
Refresh picks up the out of date files.

In fact we only need to touch the config on reloaded. Any time files are recompiled config is going to reload anyway

## Asset store releases

With Asset Store Tools it is currently not possible to cherry pick.
The choice here is to create an ad-hoc package programmatically, or find another solution.

Let's find a way to clean the package on install

... Well. Maybe just make a custom package for now.

## Warn in console when trying to import/export and same is disabled

On import, applies to context menu.
On export, should apply to post-processing

## Nits... ?

- protect/fix emo howl
- Known issue some files may round-trip and still have incorrectly
translated literals (check VSCodeTest, MapFu.howl)

## Conversion integrity

For testing, Editor Core round trips and also does not generate commit noise.

Talking of testing. I'm going to fix newly broken test and repurpose them.

HowlTest.ImportFile => HowlTest.ImportRogue

- has a round trip issue so make sure it's correctly marked;
- secondly ensure a marked file exports verbatim

### Do wards pile up?

If we import a non-integer file, the cerberus ward is added.
On export, the ward remains.
So, what happens if we import this file again?
Of course the file is still not integer.
So the ward would be added again.
That is not really what we want. In fact the cerberus ward
tells us that the file should be imported "as is" too.

### Conversion integrity and nit-picking

"As is" means no changes. Nitpicking should recognize both wards

## Main UI revamp

Mostly done.
I need to implement Rebuild.
There is no "exportDir" function in Howl. I could try an asset DB reimport.

So there are 2 functions. An interesting one is AssetDatabase.Refresh but I doubt it would trigger re-translating the C# files.

Small things:
- When import is disabled, importing via context menu should also be disabled

### Checking for onboarding status takes too long

It's down to how long ReadyForUse() is taking.

## Concluding the onboarding sequence

As a last step to onboarding the user okay and OnboardingReqs.Validate() is called, setting `inProgress`
to false.

The question then is, how do we enter onboarding?
When `Window.OnGUI` is first called, we do call `Onboarding.UI()`

So, in order to enter the onboarding seq., InProgress should return true.

We want the value of "InProgress" to revert when some conditions are true.

## Making the root dir.

The bigger issue here is we want to remove what's been done before. Notably we don't want to avail the howl root via the post-processor.

Well, it's quite simple; we need

```
Path.AvailHowlRoot();
Path.howlRootExists;
```

## Handling configuration data

So far I used a static configuration; however this may be less than ideal; one issue is that a static config cannot be serialized.

The problem really is understanding the life cycle of the config object.

Whenever we compile, the config instance is re-created. This is because assemblies are being reloaded.

If we can get an event before editor exit and assembly reload, we don't need to I/O the config whenever modified.

There are three related events:

```
AssemblyReloadEvents.beforeAssemblyReload += WillReload;
EditorApplication.wantsToQuit += WannaQuit;
EditorApplication.quitting += Quitting
```

Better choice is "quitting" here - unless we might want to prevent quitting the editor.

Another note: the config object shouldn't have a no-arg constructor. Well, maybe it's possible but this apparently short-circuits correct serialization (verify with a test)

## Single quoted double quotes and escaped quotes

Problem is StringBreaker does not recognize either quoted double quote or escaped double quotes.

```cs
[Test] public void Break_With_SQDQ(
                [Values("'\"'", "char c = '\"'")] string @in){
    o( @in.Break(("\"", "\"")).Length, 1 );
}
```

Hack Block.Def.Enter...
Now in the following, we "enter" a double quoted at position 1, and the length is of course 3.

'"'

```cs
// Single quoted double quote hack
if((i>0) && (i < x.Length - 1)
         && x.Substring(i-1, 3) == "'\"'") return false;
```

Now for an escaped quote; first the test

```cs
[Test] public void Break_With_EDQ(){
    char dq = '"', bs = '\\';
    o( ("" + dq + bs + dq + dq).Break(("\"", "\"")).Length, 1 );
}
```

Hack in Block.Def.Exit

```cs
// Escaped double quote hack
if((i>0) && x.Substring(i-1, 2) == "\\\"") return false;
```

## "Just works" experience

### Howl with a new project

In the case of a new project, we install the howl package. Then the expectation is that the howl root should be auto-generated
=> Works via UPM; expected to work via normal package install.

After making a new project I want to create a howl source source file. I expect the file to by default compile correctly.
So the correct default is "export enabled".

However visual studio is not a good environment to edit howl source.

So there are things to do before howling.

1) Howl needs visual studio code or atom to work properly. We recommend atom. [GET] (but skip if VS code is preferred and installed)
2) You need the howl language pack to use Howl with atom [GET] (but skip if vs code is preferred and installed)
4) Let's create the Howl root [OK]
5) We noticed that you already have cs files. Shall we convert your files now? (your cs files will not be modified).
6) Your project is not in source control. To protect your files we strongly recommend you enable source control [Don't care]
7) You are all set. Howl is a community project. You can support the developer by making a donation. Would you like to send us a tip?
8) You can also support us by getting one of our recommended assets [VISIT]
9) Spread the word and help us make howl bigger!

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
if(π.IsHowlSource()) AssetDatabase.DeleteAsset(π.BuildPath());
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
