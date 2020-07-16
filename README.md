# Howl
*Brutishly concise C#*

Howl is a variant of the C# language. Similar to APL, it is prettily concise.

```
切 ㄹ Validate(ㄹ κ){
    ⤴(κ ≒ null) (╯°□°)╯ ⨮ InvOp(Undef);
    ∙ x = κ.Trim();
    ⤴(x ≒ "?" ∨ x ≒ "") (╯°□°)╯ ⨮ InvOp(Undef);
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

You may use Howl in Unity:

- Howl in your favorite IDE (C# on the fly)
- Convert legacy C# libraries (in dust we trust)
- Code'n'howl, then publish to C# (nobody needs to know)

## Writing Howl source

Howl uses uncommon symbols. In spirit the solution is, type C# and lo, the magic happens.

- Snippets (here's a list for Atom)
- Import time conversion. In this case Howl sources are 'rectified' (converted from C#) during asset import

Howl is (mostly) a shorthand notation; there isn't a need to use every shorthand.
You may configure what shorthands are applied when importing from C#.

## Why Howl?

A while back, I got annoyed having to *read* `Vector3` over and over. I started aliasing common types.
Given how aliasing works in C#, this means declaring aliases in each and every file header. 
Even so, I found aliasing beneficial and wondered: can I take this a step further?

Points of note:

- A good function is a one liner (70 chars); a 'good file' is 35 lines worth of code (personal opinion)
- Time is spent reading (not writing) computer programs (fact)

Notations are good, and information layering is also good; symbolic notations help 
practitioners focus on subject matter (vs beginners learning the language).

Also, Howl is fun.

## More features

- Hinted namespace import (don't need to explicit every `using` statement in Howl source) [coming soon]
- Simple macros [coming soon]

## Should I use Howl? What are the disadvantages?

Can't see why not. 

Howl is going to break your IDE's syntax coloring, autocompletion and syntax validator.

The [raft parable](https://www.oxfordreference.com/view/10.1093/oi/authority.20110803100401550) comes to mind.

## How can I support this project

I don't really plan to support custom shorthands. Actually, if you want this (or other features) bribe me here. 

Also, open an issue. If you don't open an issue, I will drink your money at a karaoke bar.

If there are many open issues, please don't open a new issue. Instead, get to work, fix something and submit a diff.

Think Howl is obnoxious but still kinda cool? There is a tee and a mug for people like you. The lit people.
