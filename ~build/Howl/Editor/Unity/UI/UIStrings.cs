
namespace Active.Howl{
public static class UIStrings{

    // Howl Window
    public const string
        Btn_ExportAll      = "Export all",
        Btn_ApplyNotation  = "Apply",
        Btn_ImportAll      = "Import all",
        Btn_Rebuild        = "Rebuild",
        Btn_Refresh        = "Refresh",
        ShowTips   = "show tips",
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
        MakeSnippets   = "Make",
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
            = "NOTE: Symbols may look different in the Unity Editor",
        ExportAllNotice
            = "Restore C# scripts and stop using Howl";

    // URLS (migrate)
    public const string
        Discord      = "https://discord.gg/qTbhRmB",
        Github       = "https://github.com/active-logic/howl";

    public static string Documentation => $"{Github}/blob/master/README.md";
    public static string Support       => $"{Github}/blob/master/README.md";


    // Context actions

    public const string
        ApplySymset = "Assets/☆ Apply symset",
        UseHowl     = "Assets/⎚ Use Howl 〜 (╯°□°)╯",
        UseCSharp   = "Assets/⎚ Use C# (remove Howl scripts)";


}}
