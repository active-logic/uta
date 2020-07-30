# Howl root

By default \*.howl source files are placed under `Assets/PROJECT_NAME.Howl`.

For example, consider the following project structure:

```
Snafu/
+-- Assets/
    +-- Scripts/
        +-- BigClass.cs
        +-- Pool.cs
        +-- BLM.cs
```

When you import C# sources, Howl adds a `Snafu.Howl` directory:

```
Snafu/
+-- Assets/
    +-- Scripts/
        +-- BigClass.cs
        +-- Pool.cs
        +-- BLM.cs
    +-- Snafu.Howl/
        +-- Scripts/
            +-- BigClass.Howl
            +-- Pool.Howl
            +-- BLM.Howl
```

New howl source-files must be placed under the Howl root. For practical purposes after importing it is better to ignore C# files, as they are considered "derived products".

Howl does not manage \*.howl files outside the howl root. If you accidentally create one such file you may receive a warning. Likewise moving a howl source outside the root causes the C# counterpart to be deleted, and so forth.

Howl ignores C# sources placed within the howl root.

**[TODO] adding a C# file to the howl source hierarchy should trigger an error and stay put until the user move it somewhere new**

## Choosing a different root [PROVISIONAL/UNTESTED]

To find its root directory, howl looks for a file named `.howl.root`. You can move your howl directory wherever you please under `/Assets` and it is still the howl root; when setting up a new project you may also create this file yourself to assign a root.

**[TODO] multiple howl roots should be a serious error and stay put until cleared**
