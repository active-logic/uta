using Ex = System.Exception;
using System.Linq;
using UnityEditor;

namespace Active.Howl{
public class Atom : Ed{

    public static Atom ι = new Atom();

    // NOTE: expands correctly on Win, maps to %USERPROFILE%\.atom
    const string appDataRoot = "~/.atom";
    const string howlExtDir = "~/.atom/packages/language-howl";
    const string defaultUserSnippetsPath
              = "packages/language-howl/snippets/language-howl.cson";
    const string userSnippetsPathKey = "Atom.User.Snippets.Path";

    // <Ed> ---------------------------------------------------------

    public string UserSnippetsPath(bool expand)
    => EditorPrefs.GetString(userSnippetsPathKey,
                             DefaultUserSnippetsPath(expand));

    public string DefaultUserSnippetsPath(bool expand){
        var ㄸ = $"{appDataRoot}/{defaultUserSnippetsPath}";
        return expand ? ㄸ.Expand() : ㄸ;
    }

    public string GenUserSnippets(bool dry){
        var snips = SnippetGen.Create();
        var ㄸ = "'.source.howl':"
              + snips.Aggregate("", (x, y) => $"{x}\n{Format(y)}")
              + '\n';
        DoExportSnippets(ㄸ, dry);  return ㄸ;
    }

    public void SetUserSnippetsPath(string ㅂ)
    => EditorPrefs.SetString(userSnippetsPathKey, ㅂ);

    // --------------------------------------------------------------

    public bool CanHideBuildDir() => config.Contains("~build");

    public bool IsBuildDirHidden () => !config.Contains("#\"~build\"") ;

    public void HideBuildDir(bool flag) {
        var x = config;
        if ( flag &&  IsBuildDirHidden()) return ;
        else if (!flag && !IsBuildDirHidden()) return ;
        else config = flag ? config.Replace("#\"~build\"", "\"~build\"")
                         : config.Replace("\"~build\"", "#\"~build\"");
    }

    // --------------------------------------------------------------

    public string Name() => nameof(Atom);

    public bool Exists() => appDataRoot.Expand().IsDir();

    public bool SupportsHowl() => howlExtDir.Expand().IsDir();

    // Imp -----------------------------------------------------------

    string config{
        get => $"{appDataRoot}/config.cson".Expand().Read();
        set => $"{appDataRoot}/config.cson".Expand().Write(value);
    }

    void DoExportSnippets(string ㅂ, bool dry){
        string π = UserSnippetsPath(expand: true);
        if(!dry) π.Write(ㅂ);
        log.message = $"Snippets exported to {π}"; 
    }

    public string Format(Snippet x) =>
        $"  '{x.name}':\n"
      + $"    prefix : '{x.prefix}'\n"
      + $"    body   : '{x.body}'";

}}
