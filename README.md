⚠️ **UNDER DEVELOPMENT 〜 HANDLE WITH CARE**

# Uta - Howl for Unity

NOTICE: *Uta is a Unity integration for the [Howl symbolic notation engine](https://github.com/active-logic/howl). Resources related to the CLI and core engine are being migrated; distributions are-self contained (no package/submodule dependencies)*

Howl is a symbolic notation engine for C# programming. Have a look:

```
ㅇ IsEscapedDoubleQuoteInString(ㄹ x, ᆞ i){
    ⤴ (suffix ≠ "\"" ∨ x[i] ≠ '"') ⮐ ✗;
    ㅇ esc = ✗;
    ⟲ (--i > 0){
        ⤴ (x[i] ≠ '\\') ¦
        ⤵ esc = !esc;
    }
    ⮐ esc;
}
```

Here is the C# conversion:

```cs
bool IsEscapedDoubleQuoteInString(string x, int i){
    if (suffix != "\"" || x[i] != '"') return false;
    bool esc = false;
    while (--i > 0){
        if (x[i] != '\\') break;
         else esc = !esc;
    }
    return esc;
}
```

- Howl is a superset of C#: configure which notations are applied, be it on first import, or later.
- Bi-directional translation imports your legacy (C#) sources.
- Input Howl source comfortably (VS Code and Atom snippets). As you type C#, Howl source is generated; therefore, learning the notation is easy and fun.
- Publish either C#, Howl scripts, or both.

In Atom, beautiful syntax highlighting is available.

![Image](Documentation/Images/Howl-Sample-Dark.png?raw=true)

This repository comprehends the Unity 3D integration. If you are looking for the CLI, visit [active-logic/howl](https://github.com/active-logic/howl)

Howl is free for personal use. Over one seat, enterprise users owe a cup of joe, [payable on ko-fi](https://ko-fi.com/eekstork#paymentModal).

## Why Howl?

Muting language semantics increases focus. Also, modifiers and keywords take up space (up to 20% of program source).

Successful notations are used in music, mathematics, dance and the road code. In programming, [APL](https://en.wikipedia.org/wiki/APL_(programming_language)) is a notable precursor.

## Getting started

- [Atom](https://atom.io) with the [language-howl](https://atom.io/packages/language-howl) extension is recommended. [VS Code](https://code.visualstudio.com) is also supported.
- Grab the [latest release](https://github.com/active-logic/uta/releases)
- Read: [getting started with Howl for Unity3D](Documentation/User/Unity.md)

## Resources

- Learn about [exciting features](https://github.com/active-logic/howl/issues?q=is%3Aissue+is%3Aopen+label%3A＼%28＾∀＾%29メ%28＾∀＾%29ノ) being worked on.
- Have a peak at the [Howl source code](https://github.com/active-logic/howl/tree/master/Editor/Core) (written in Howl).
- View the [Cosmo specification](Documentation/Cosmo-Spec.md)

[Fuel this rocket](https://github.com/active-logic/howl/issues) 🚀and [feed the beast](Documentation/Giveback.md) ☕️
