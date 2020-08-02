using Env = System.Environment; using SysPath = System.IO.Path;
using InvOp = System.InvalidOperationException;
using UnityEngine;

namespace Active.Howl{
public static class Path{

    const string ROOT_TOKEN = "howl.root";  public static string _Howl = ".howl", _Cs = ".cs";

    // --------------------------------------------------------------

    public static void AvailHowlRoot(){
        var ρ = GetHowlRoot ();
        if (ρ.didCreate) Debug.Log($"Created Howl root: {ρ.path}");
    }

    public static string Expand(this string path) => path
    .Replace("~",
        Env.GetFolderPath(Env.SpecialFolder.UserProfile))
    .Replace("%APPDATA%",
        Env.GetFolderPath(Env.SpecialFolder.ApplicationData))
    .Nix();

    public static string FullPath(this string π) => SysPath.GetFullPath(π).Nix();

    public static string FindHowlRoot(){
        string root = FileSystem.Path("Assets/", ROOT_TOKEN);
        if (root == null) return null;
        else {
            // TODO don't want a sep at end but noticed too late.
            var dir = root.DirName() + "/";
            int i = dir.IndexOf("Assets/");
            return dir.Substring(i);
        }
    }

    public static bool IsPackaged(this string π) => π.StartsWith("Packages/");

    public static bool IsDetachedHowlSource(this string π) => π.EndsWith(_Howl);

    public static bool IsHowlSource(this string π)
    => π.FullPath().StartsWith(howlRoot.FullPath());

    public static string Nix(this string x) => x.Replace('\\', '/');

    public static string NoFinalSep(this string π)
    => (π = π.Nix()).EndsWith("/") ? π.Substring (0, π.Length - 1) : π;

    // Given path to a howl, return matching C# path
    public static string OutPath(this string ㅂ) => ㅂ.IsHowlSource()
       ? $"Assets/{ㅂ.Substring(howlRoot.Length).Replace(_Howl, _Cs)}"
       : throw new InvOp($"{ㅂ} doesn't howl");

    // Given path to a C# file, return matching Howl path
    public static string InPath(this string ㅂ){
        if(!ㅂ.InAssets()){
            var i = ㅂ.IndexOf("Assets");
            if(i < 0) throw new InvOp($"{ㅂ} not in Assets/");
            ㅂ = ㅂ.Substring(i);
        }
        var ㄸ = ㅂ.Substring("Assets/".Length).Replace(".cs", ".howl");
        return $"{howlRoot}{ㄸ}";
    }

    public static bool InAssets(this string path)
    => path.StartsWith("Assets/") || path.StartsWith("Assets" + '\\');

    public static bool InHowlPath(this string π) => π.StartsWith(howlRoot);

    // Properties ---------------------------------------------------

    public static bool howlRootExists => FindHowlRoot() != null;

    public static string howlRoot => GetHowlRoot().path;

    public static string defaultHowlRootPath => $"Assets/{projectName}.Howl/";

    // NOTE: App.dataPath uses forward slashes, even on Windows
    public static string projectName{ get{
        string[] s = Application.dataPath.Split('/');
        return s[s.Length - 2];
    }}

    // PRIVATE ------------------------------------------------------

    static (string path, bool didCreate) GetHowlRoot(){
        var root = FindHowlRoot();
        if (root == null){
            root = defaultHowlRootPath;
            (root + ROOT_TOKEN).Write("ROOT", mkdir: true);
            return  (root, true);
        } else
            return (root, false);
    }

}}
