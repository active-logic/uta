HOWL - Getting Started

REQUIREMENTS

You will need:
- A compatible code editor (Atom or Visual Studio Code)
- The `language-howl` extension package (when using Atom)

At the time of writing Atom is better supported, with dedicated syntax highlighting and font size adjustements.

RECOMMENDED SETUP

Get Atom
https://atom.io

Get the language-howl extension:
https://atom.io/packages/language-howl

If you are using the source import/export features, a VCS solution, such as Git, is recommended:
https://git-scm.com/book/en/v2/Getting-Started-Installing-Git

IMPORTANT: Howl provides import/export features for one step conversions between Howl and C#. These features manage (move/rename) your scripts. DO backup your files before enabling the import/export features.
While the author are not aware of a bug putting your files at risk in this case, using a backup/VCS solution is always recommended.

VSCode support is automated (you may need to restart Unity3D after installing VSCode). There is an upstream issue with character display:
https://github.com/microsoft/vscode/issues/105045
If you are affected by this, upvote the issue.

DEMO

Open "Bouncing Ball.unity", add the "Bouncing" script to the ball and enter play mode.
Congratulations! You have now compiled and run your first Howl script.

Searching for "Bouncing" in the project window, notice there are two versions of the Bouncing script. You may view `Bouncing.howl` and `Bouncing.cs` side-by-side to consider the differences.

TUTORIAL

In your code editor, open and create a file named "Greetings.howl".

Howl input is via snippets; in this tutorial, snippet input is displayed [within brackets].

As an example, if you type [public] or [pub], then ENTER or TAB, the figure dash symbol [‒] will appear.

NOTE: the figure dash [‒] is different from the Hyphen-minus [-] on your keyboard. Trying to type Howl symbols "directly" is always an error.

You need not learn exotic shortcuts to use Howl. Type C# and discover what is available.

Without further ado, type in your first Howl script:

```
[usingunity]

[public] [class] Greetings : MonoBehaviour{

    [void] [Start](){
        [logm] "Well Done";
    }

}
```

As you type, the following script is generated:

```
⊐ UnityEngine;

‒ ○ Greetings : MonoBehaviour{

    ┈ Start(){
        🐰 "Well Done";
    }

}
```

Adding the script to any game object, enter play mode. Thereupon, a message is displayed in the console window.

NITPICKING

We have covered snippet input. Nitpicking is another Howl input feature.
In `Greetings.howl` replace the body of the `Start()` function with an expression bodied member:

```
┈ Start() => 🐰 "Well Done";
```

Save the script and compile in Unity; then, going back to the code, notice the updated `Start()` method:

```
┈ Start() → 🐰 "Well Done";
```

A right pointing arrow (→) did replace the C# lambda operator (=>).

Nitpicking adds tiny improvements to the source, such as converting == to ☰ or >= to ≥.

Howl avails over a hundred notations, documented here:
https://github.com/active-logic/uta/blob/master/Documentation/Cosmo-Spec.md

WHERE ARE MY FILES?

Howl places C# output in `Assets/~build` aka "the build directory"; if you use the import feature, imported C# sources (with metafiles) will also be moved to the build directory.

Your assemblies (if any) are also relocated to the build directory.

IMPORTANT: Never delete the build directory; doing so would erase metafiles and assembly definitions, causing errors. If anything goes wrong - such as duplicate scripts appearing in the build directory - go to the Howl window and choose Rebuild.

MORE FEATURES

The Howl Window provides additional (self-documenting) options. Navigate between views/tabs using [...] in the top right corner.

You may also right click in the Project window to convert your scripts to Howl (and back to C# if you wish).

HELP, ADVICE AND SUPPORT

This guide is a short introduction. For additional information, check the Howl page here:
https://github.com/active-logic/uta/blob/master/README.md

After a number of uses, Howl will display one time information suggesting ways you might encourage futher development. Although released as free software, Howl is a serious project which requires time and effort. If you can afford supporting this work, you are encouraged to do so. Information may be found here:

https://github.com/active-logic/uta/blob/master/Documentation/Giveback.md
