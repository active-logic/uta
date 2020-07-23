using Ex = System.Exception;
using System.Linq;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEditor;

//
//
//

namespace Active.Howl{
public class Atom : Ed{

    const ㄹ userPrefsRoot = "~/.atom";
    const ㄹ defaultUserSnippetsPath = "snippets.cson";
    const ㄹ userSnippetsPathKey = "Atom.User.Snippets.Path";

    public ㄹ Format(Snippet x) =>
        $"  '{x.name}':\n"
      + $"    'prefix': '{x.prefix}'\n"
      + $"    'body': '{x.body}'";

    public ㄹ GenUserSnippets(ㅇ dry){
        var snips = SnippetGen.Create();
        var ㄸ = snips.Aggregate("", (x, y) => $"{x}\n{Format(y)}");
        DoExportSnippets(ㄸ.Substring(1), dry);
        return ㄸ;
    }

    void DoExportSnippets(ㄹ ㅂ, ㅇ dry){
        ㄹ π = UserSnippetsPath(expand: true);
        ㄹ snippets = π.Read();
        ㄹ ㄸ = snippets.Insert(ㅂ, SnippetGen.Le, SnippetGen.Ri);
        if(ㄸ == null) { Warn("Cannot insert snippets"); return; }
        //UnityEngine.Debug.Log("New snippets\n" + ㄸ);
        if(!dry) π.Write(ㄸ);
    }

    public void RemUserSnippets(){
        //UnityEngine.Debug.LogWarning("Rem snips not implemented");
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

    public ㄹ Name() => nameof(Atom);

    static ㅇ Warn(ㄹ msg)
    { UnityEngine.Debug.LogWarning(msg); return false; }

}}
