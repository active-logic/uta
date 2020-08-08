# Known Issues and limitations

## Assembly related

If your project uses assemblies, the following considerations apply:
- Mixed assemblies (combine Howl and C# sources) are not supported.
- Even if an assembly targets only Howl sources, the \*.asmdef definition file should be kept in the build directory.

Note: *AssemblyInfo.cs* is processed like any other C# file. If you import this file, a \*.howl source file will be generated.  

## Deleting, moving and renaming files

Deleting, moving and renaming \*.howl sources should be done using the Unity Editor.

Howl relies on Unity Editor events to decide whether a file has moved, or was deleted; provided you are using the Unity Editor, C# counterparts will be moved/deleted/renamed accordingly.

## Interpolated strings

Howl is not supported in interpolated strings:

```howl
ㄹ[] arr = {"a", "b", "c"};
🍥($"The array length is {arr❙}");        // Does not compile
🍥($"The array length is {arr.Length}");  // OK
```

# Property files
