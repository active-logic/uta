namespace Active.Howl.UIStrings{
public static class Main{

    // Howl Window

    public const string
        Btn_ExportAll      = "Export all",
        Btn_ApplyNotation  = "Apply",
        Btn_ImportAll      = "Import all",
        Btn_Rebuild        = "Rebuild",
        Btn_Refresh        = "Refresh",
        ShowTips           = "Show tips",
        PressForSymset     = "Select [+] (top-right) to config. symset",
        MoreOpts           = "[…]",
        DevInfo =
@"Refresh rebuilds outdated *.howl scripts. Use rebuild
to clean the build directory and rebuild all scripts.
You may also 'reimport' via the project window",
        EnableImp      = "Enable",
        EnableExp      = "Enable",
        H_Develop      = "Dev",
        H_Import       = "Import (C# => Howl)",
        H_Export       = "Export (Howl => C#)",
        Howl           = "Howl",
        IgConflicts    = "Ignore conflicts",
        MakeSnippets   = "Make snippets",
        RemoveSnippets = "Del.",
        SymsetConfig   = "Symset configuration",
        ApplyNotationNotice
            = "Re-convert Howl scripts to match your preferences",
        ImportAllNotice
            = "Import C# scripts (convert to Howl)",
        SymsetNote =

@"Selection applies to import and snippet generation;
choose [apply] to update source, or update selectively
via the project window.",

        NotWYSIWYG
= @"Not all symbols are supported in the Unity Editor;
brown denotes approximate renditions",
        ExportAllNotice
            = "Restore C# scripts and stop using Howl";

    public static string ImportWarning =
    $"{Warning} Backup your files before using this feature";

    public static string ExportWarning =
    $"{Warning} Backup your files before using this feature";

    #if UNITY_2019
    const string Warning = "<color=red>⚠️</color>";
    #else
    const string Warning = "<color=red>▲</color>";
    #endif

    // URLS (migrate)
    public const string
        Discord      = "https://discord.gg/qTbhRmB",
        Github       = "https://github.com/active-logic/howl";

    public static string Documentation => $"{Github}/blob/master/README.md";
    public static string Support       => $"{Github}/blob/master/Documentation/Giveback.md";


    // Context actions

    public const string
        ApplySymset = "Assets/☆ Apply symset",
        UseHowl     = "Assets/⎚ Use Howl 〜 (╯°□°)╯",
        UseCSharp   = "Assets/⎚ Use C# (remove Howl scripts)";


}}
