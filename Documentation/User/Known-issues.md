# Known Issues and limitations

## Escaped characters

Escaped characters may cause issues:

[TODO example]

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
