# Howl

Symbolic notation for C# reminiscent of [APL](https://en.wikipedia.org/wiki/APL_(programming_language)).

```
 ⃠ ㄹ Validate(ㄹ κ){
    ⤴(κ ☰ null) (╯°□°)╯ ⌢ InvOp(Undef);
    ∙ x = κ.Trim();
    ⤴(x ☰ "?" ∨ x ☰ "") (╯°□°)╯ ⌢ InvOp(Undef);
    ⮑ κ;
}
```

C# equiv ~

```cs
public static string Validate(string κ){
    if(κ == null) throw new InvOp(Undef);
    var x = κ.Trim();
    if(x == "?" || x == "") throw new InvOp(Undef);
    return κ;
}
```

You may Howl in Unity:

- Your favorite IDE (C# on the fly)
- One click conversion (Goodbye C#)
- Code'n'howl, publish to C# (nobody needs to know)

## Getting started

⚠️ :HOWL IS UNDER DEVELOPMENT; BEFORE IMPORTING AND USING THIS PACKAGE, BACKUP/COMMIT YOUR FILES: ⚠️

This is a UPM package which requires Unity 3D (the game engine). After adding the package (to an existing project), go to `Window > Activ > Howl`. Then in the Howl window:

- Uncheck **lock**
- Press **Generate Howl Source**

After a wait (a few seconds for medium sized projects) a `project_name.howl/` directory appears in your Project tab. At this point you can view your own sources converted to Howl.

By default, Howl does not modify your C# files. When you are ready, however, you can start actually using Howl. Then, back to the Howl window, check **Enable Export**

## Writing Howl source

Howl uses *uncommon* symbols. In spirit the solution is, type C# and lo, the magic happens.

- Use/define your own snippets (here [TODO] is a list for Atom; if you made nice snippets for VS Code, Rider or any other glorified text editor, please submit a diff)
- Import time conversion [TODO] (In this case Howl shorthands are applied during asset import)

## Why Howl?

Howl uses information layering and symbolic notations to help you focus on subject matter. It is on average XX% more concise than C#. Howl is for writing short, expressive computer programs. 

There isn't a need to start with every available shorthand; take it at your own pace ([TODO] configurable)

## Should I use Howl? What are the disadvantages?

Can't see why not. Howl is going to break your IDE's syntax coloring, autocompletion and syntax validator.
The [raft parable](https://www.oxfordreference.com/view/10.1093/oi/authority.20110803100401550) comes to mind.

## More features

- Hinted namespace import (don't need to explicit every `using` statement in Howl source) [SOON]
- Simple macros [SOON]

## How do I even support this project

I don't really plan to support custom shorthands. Actually, if you want this (or other features) bribe me here. Also, open an issue. If you don't open an issue, I will drink your money at a karaoke bar.

If there are many open issues, please don't open a new issue. Instead get to work and submit a diff.

Think Howl is obnoxious but still kinda cool? There is a tee and a mug for people like you. The lit people.
