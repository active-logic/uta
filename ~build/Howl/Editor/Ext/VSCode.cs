using Ex = System.Exception; using System.Linq; using System.IO; using UnityEditor;

namespace Active.Howl{
[InitializeOnLoad] public class VSCode : Ed{

    public static VSCode ι = new VSCode();

    #if UNITY_EDITOR_LINUX
    const string userPrefsRoot = "~/.config/Code/User";
    #elif UNITY_EDITOR_OSX
    const string userPrefsRoot = "~/Library/Application Support/Code/User";
    #elif UNITY_EDITOR_WIN
    const string userPrefsRoot = "%APPDATA%/Code/User";
    #endif

    const string appDataRoot    = "~/.vscode/";
    const string resourcePath  = "Howl/Z/VSCodeX";
    const string extensionsDir = "~/.vscode/extensions";
    const string defaultUserSnippetsPath = "snippets/howl.json";
    const string userSnippetsPathKey = "VSCode.User.Snippets.Path";

    static VSCode(){
        var ι = new VSCode();
        if (ι.Exists()) ι.GenUserSnippets(dry: false, overwrite: false);
    }

    // <Ed> ---------------------------------------------------------

    public string UserSnippetsPath(bool expand)
    => EditorPrefs.GetString(userSnippetsPathKey,
                            DefaultUserSnippetsPath(expand));

    public string DefaultUserSnippetsPath(bool expand){
        var ㄸ = $"{userPrefsRoot}/{defaultUserSnippetsPath}";
        return expand ? ㄸ.Expand() : ㄸ;
    }

    public string GenUserSnippets(bool dry) => GenUserSnippets(dry, overwrite:true);

    public string GenUserSnippets(bool dry, bool overwrite){
        SideloadExtension();
        var snips = SnippetGen.Create();
        var ㄸ = snips.Aggregate("", (x, y) => $"{x},\n{Format(y)}")
             + '\n';
        DoExportSnippets(ㄸ = ㄸ.Substring(2), dry, overwrite);
        return ㄸ;
    }

    public void SetUserSnippetsPath(string ㅂ)
    => EditorPrefs.SetString(userSnippetsPathKey, ㅂ);

    // --------------------------------------------------------------

    public bool CanHideBuildDir() => false;

    public bool IsBuildDirHidden() => false;

    public void HideBuildDir(bool flag) {}

    // --------------------------------------------------------------

    public string Name() => nameof(VSCode);

    public bool Exists() => appDataRoot.Expand().IsDir();

    public bool SupportsHowl() => howlExtDir.Expand().IsDir();

    // Implementation -----------------------------------------------

    void DoExportSnippets(string ㅂ, bool dry, bool overwrite){
        string π = UserSnippetsPath(expand: true);
        if (dry) return;
        else if (π.Exists()){ if (overwrite) π.Write("{\n" + ㅂ + "\n}"); }
        else π.Write("{\n" + ㅂ + "\n}");
    }

    public string Format(Snippet x) =>
        ($"  '{x.name}': {{\n"
      +  $"    'prefix': '{x.prefix}',\n"
      +  $"    'body': [ '{x.body}' ],\n"
      +   "  }").Replace('\'', '"');

    public void SideloadExtension(){
        var π = howlExtDir; if (π.Exists()) return ;
        resourceDir.Copy(to: π);
        log.message = $"Howl support extension installed under {π}";
    }

    // Properties ----------------------------------------------------

    public string resourceDir => Path.FindResourceDir(resourcePath);

    string howlExtDir => $"{extensionsDir.Expand()}/howl";

}}
