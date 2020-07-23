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

    const ㄹ userPrefsRoot="~/Library/Application Support/Code/User";
    const ㄹ defaultUserSnippetsPath = "snippets/howl.json";
    const ㄹ userSnippetsPathKey = "VSCode.User.Snippets.Path";

    public ㄹ Format(Snippet x) =>
        ($"  '{x.name}': {{\n"
      +  $"    'prefix': '{x.prefix}',\n"
      +  $"    'body': [ '{x.body}' ],\n"
      +   "  }").Replace('\'', '"');

    public ㄹ GenUserSnippets(ㅇ dry){
        var snips = SnippetGen.Create();
        var ㄸ = snips.Aggregate("", (x, y) => $"{x}\n{Format(y)}");
        DoExportSnippets(ㄸ.Substring(1), dry);
        return ㄸ;
    }

    void DoExportSnippets(ㄹ ㅂ, ㅇ dry){
        ㄹ π = UserSnippetsPath(expand: true);
        if(!dry) π.Write(ㅂ);
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

    //static ㅇ Warn(ㄹ msg)
    //{ UnityEngine.Debug.LogWarning(msg); return false; }

}}
