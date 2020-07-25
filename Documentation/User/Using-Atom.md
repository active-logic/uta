# Howl - Using Atom

## Generate snippets

[TODO] explain how to setup custom snippets for adding Howl snippets
From Unity, open the Howl window. Under Snippets > Atom choose "Make".

## Enable snippets


Under *Atom > Config...*, add a custom file type:

```cson
"*":
  core:
    audioBeep: false
    customFileTypes:
      "source.cs": [
        "howl"
      ]
```

This tells atom that \*.howl files are to be handled like C# sources (Howl snippets are currently tied to C#)

## Disable syntax highlighting

Howl does not play nice with syntax highlighting. You can disable/subdue syntax highlighting using a theme such as [no syntax highlighting](https://atom.io/themes/no-syntax-highlighting-syntax)
