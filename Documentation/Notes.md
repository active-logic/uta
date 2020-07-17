# Notes

## Asset move and delete operations

When a howl file is deleted, we of course want the matching C# file to also be deleted.
Let's create a functional test for this.
Now, let's implement this.

```cs
if(π.IsHowlSource()) AssetDatabase.DeleteAsset(π.OutPath());
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
