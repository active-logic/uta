using Ex = System.Exception;
using System.Linq;
using System.IO;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEditor;

// REFS:
// https://dev.to/codechimp/creating-and-syncing-personal-snippets-in-vs-code-2g9m
// https://vscode-docs.readthedocs.io/en/stable/customization/userdefinedsnippets/

namespace Active.Howl{
public class VSCode : Ed{

    #if UNITY_EDITOR_LINUX
    const ㄹ userPrefsRoot = @"~/.config/Code/User";
    #elif UNITY_EDITOR_OSX
    const ㄹ appDataRoot = @"~/.vscode/extensions";
    const ㄹ userPrefsRoot = @"~/Library/Application Support/Code/User";
    #elif UNITY_EDITOR_WIN
    const ㄹ userPrefsRoot = @"%APPDATA%/Code/User";
    #endif

    const ㄹ defaultUserSnippetsPath = "snippets/howl.json";
    const ㄹ userSnippetsPathKey = "VSCode.User.Snippets.Path";

    public ㄹ Format(Snippet x) =>
        ($"  '{x.name}': {{\n"
      +  $"    'prefix': '{x.prefix}',\n"
      +  $"    'body': [ '{x.body}' ],\n"
      +   "  }").Replace('\'', '"');

    public ㄹ GenUserSnippets(ㅇ dry){
        SideloadExtension();
        var snips = SnippetGen.Create();
        var ㄸ = snips.Aggregate("", (x, y) => $"{x},\n{Format(y)}");
        DoExportSnippets(ㄸ.Substring(2), dry);
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

    public void RemUserSnippets(){
        //throw new Ex("Rem snips not imp");
    }

    public ㄹ UserSnippetsPath(ㅇ expand)
    => EditorPrefs.GetString(userSnippetsPathKey,
                             DefaultUserSnippetsPath(expand));

    public void SetUserSnippetsPath(ㄹ ㅂ)
    => EditorPrefs.SetString(userSnippetsPathKey, ㅂ);

    public ㄹ DefaultUserSnippetsPath(ㅇ expand){
        var ㄸ = $"{userPrefsRoot}/{defaultUserSnippetsPath}";
        return expand ? ㄸ.Expand() : ㄸ;
    }

    public ㄹ Name() => nameof(VSCode);

    // --------------------------------------------------------------

    void DoExportSnippets(ㄹ ㅂ, ㅇ dry){
        ㄹ π = UserSnippetsPath(expand: true);
        if(!dry) π.Write("{\n" + ㅂ + "\n}");
    }

}}
