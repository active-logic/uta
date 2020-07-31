using Ex = System.Exception;
using System.Linq;
using UnityEditor;

namespace Active.Howl{
public class Atom : Ed{

    // NOTE: expands correctly on Win, maps to %USERPROFILE%\.atom
    const string appDataRoot = "~/.atom";
    const string howlExtDir = "~/.atom/packages/language-howl";
    const string defaultUserSnippetsPath
              = "packages/language-howl/snippets/language-howl.cson";
    const string userSnippetsPathKey = "Atom.User.Snippets.Path";

    public string Format(Snippet x) =>
        $"  '{x.name}':\n"
      + $"    prefix : '{x.prefix}'\n"
      + $"    body   : '{x.body}'";

    public string GenUserSnippets(bool dry){
        var snips = SnippetGen.Create();
        var ㄸ = "'.source.howl':"
              + snips.Aggregate("", (x, y) => $"{x}\n{Format(y)}")
              + '\n';
        DoExportSnippets(ㄸ, dry);
        return ㄸ;
    }

    void DoExportSnippets(string ㅂ, bool dry){
        string π = UserSnippetsPath(expand: true);
        if(!dry) π.Write(ㅂ);
    }

    public string UserSnippetsPath(bool expand)
    => EditorPrefs.GetString(userSnippetsPathKey,
                             DefaultUserSnippetsPath(expand));

    public void SetUserSnippetsPath(string ㅂ)
    => EditorPrefs.SetString(userSnippetsPathKey, ㅂ);

    public string DefaultUserSnippetsPath(bool expand){
        var ㄸ = $"{appDataRoot}/{defaultUserSnippetsPath}";
        return expand ? ㄸ.Expand() : ㄸ;
    }

    public string Name() => nameof(Atom);

    public bool Exists() => appDataRoot.Expand().IsDir();

    public bool SupportsHowl() => howlExtDir.Expand().IsDir();

    static bool Warn(string msg)
    { UnityEngine.Debug.LogWarning(msg); return false; }

}}
