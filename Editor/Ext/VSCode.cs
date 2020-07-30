using Ex = System.Exception;
using System.Linq;
using System.IO;
using UnityEditor;

// REFS:
// https://dev.to/codechimp/creating-and-syncing-personal-snippets-in-vs-code-2g9m
// https://vscode-docs.readthedocs.io/en/stable/customization/userdefinedsnippets/

namespace Active.Howl{
public class VSCode : Ed{

    #if UNITY_EDITOR_LINUX
    const string userPrefsRoot = @"~/.config/Code/User";
    #elif UNITY_EDITOR_OSX
    const string userPrefsRoot = @"~/Library/Application Support/Code/User";
    #elif UNITY_EDITOR_WIN
    const string userPrefsRoot = @"%APPDATA%/Code/User";
    #endif

    const string appDataRoot = @"~/.vscode/extensions";
    const string defaultUserSnippetsPath = "snippets/howl.json";
    const string userSnippetsPathKey = "VSCode.User.Snippets.Path";

    public string Format(Snippet x) =>
        ($"  '{x.name}': {{\n"
      +  $"    'prefix': '{x.prefix}',\n"
      +  $"    'body': [ '{x.body}' ],\n"
      +   "  }").Replace('\'', '"');

    public string GenUserSnippets(bool dry){
        SideloadExtension();
        var snips = SnippetGen.Create();
        var ㄸ = snips.Aggregate("", (x, y) => $"{x},\n{Format(y)}")
               + '\n';
        DoExportSnippets(ㄸ = ㄸ.Substring(2), dry);
        return ㄸ;
    }

    // TODO when installed as a UPM package probably not the correct
    // source path
    // TODO sometimes we want to reinstall the extension
    public void SideloadExtension(){
        var x = "Assets/Howl/Z/VSCodeX";
        var y = $"{appDataRoot.Expand()}/howl";
        if(!Directory.Exists(y)){
            x.Copy(to: y);
            UnityEngine.Debug.Log(
                $"Howl support extension installed under {y}");
        }
    }

    public string UserSnippetsPath(bool expand)
    => EditorPrefs.GetString(userSnippetsPathKey,
                             DefaultUserSnippetsPath(expand));

    public void SetUserSnippetsPath(string ㅂ)
    => EditorPrefs.SetString(userSnippetsPathKey, ㅂ);

    public string DefaultUserSnippetsPath(bool expand){
        var ㄸ = $"{userPrefsRoot}/{defaultUserSnippetsPath}";
        return expand ? ㄸ.Expand() : ㄸ;
    }

    public string Name() => nameof(VSCode);

    // --------------------------------------------------------------

    void DoExportSnippets(string ㅂ, bool dry){
        string π = UserSnippetsPath(expand: true);
        if(!dry) π.Write("{\n" + ㅂ + "\n}");
    }

}}
