HOWL - Getting Started

REQUIREMENTS

In order to use Howl, you will need the following:
- A compatible code editor (Atom or Visual Studio Code)
- The `language-howl` extension package (if you are using Atom)
- Git

At the time of writing, Atom is better supported, with dedicated syntax highlighting and font size adjustements.

SETUP

Open setup via Window > Activ > Howl; setup will guide through simple steps to ensure you have a compatible code editor and your project is in source control.

ATTENTION: Whether using source control or not, please backup and commit your project before proceeding.

You will also get an option to import your C# sources. You may choose to skip this step for a variety of reasons, since you have more control over this process later on.

VERIFICATION AND TUTORIAL

To verify setup, in your code editor, open and create a new file entitled "Greetings.howl".

Let's get familiar with Howl input. Howl uses code snippets. Therefore, in the provided example snippet input is displayed in brackets.

For example, if you type [public] or [pub], then ENTER or TAB, the figure dash symbol [‒] will appear.

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

You need not learn exotic shortcuts to use the notation. Instead you just type C# code and discover what is available.

Howl avails a little over 100 notations, documented here:

https://github.com/active-logic/howl/blob/master/Documentation/Cosmo-Spec.md

STAY IN CONTROL

You do not need to know or use every notation to use Howl. All notations are optional, so if you, say, prefer to see "void" whenever you type "void", you can.

Indeed, you may turn selected symbols/notations OFF, like so:
- Go to the Howl Window and de-select every notation you dislike.
- Press "Generate snippets".
- Restart your code editor (or just reload/reopen the editor window)

The same process can be used to choose which notations are applied when importing your C# sources.

WHERE ARE MY FILES?

When you import C# scripts to Howl, they are moved to Assets/~build.

Since assemblies manage C# scripts, your assemblies (if any) are also relocated to the ~build directory.

Never delete the ~build directory; doing so would erase metafiles and assembly definitions, causing errors.
If something went wrong and, say, you have duplicate scripts in the ~build directory, go to the Howl window and choose Rebuild.

NITPICKING

There is just one more essential thing we have not covered about Howl input: nit-picking. So, let's get back to the `Greetings` behavior.

Please delete the body of the `Start()` function. Instead, we will use an expression bodied member, like so:

```
┈ Start() => 🐰 "Well Done";
```

Save the script and compile in Unity; then, go back to the code editor and observe the updated definition for the `Start()` method:

```
┈ Start() → 🐰 "Well Done";
```

Observe how the C# lambda operator (=>) was replaced by the right pointing arrow (→).

This process, 'nitpicking', consists in making tiny improvements to your script on import. By default nitpicking only converts selected operators such as == (becomes ☰) or >= (becomes ≥).

MORE FEATURES

The Howl Window provides a few additional options, documented therein.

Also, you can right click in the Project window to convert your scripts to Howl (and back to C# if you wish). And if you decided to tweak your choice of notations, you can also reapply the notation ("symset") to selected files and directories.

HELP, ADVICE AND SUPPORT

This guide is intended as a short introduction. For more information, please visit:

https://github.com/active-logic/howl/blob/master/README.md
