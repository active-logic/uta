using Env   = System.Environment;
using InvOp = System.InvalidOperationException;
using UnityEngine;

namespace Active.Howl{
public static class Path{

    const string ROOT_TOKEN = "howl.root";  public static string _Howl = ".howl", _Cs = ".cs";

    // --------------------------------------------------------------

    public static void AvailHowlRoot(){
        UnityEngine.Debug.Log("Make howl root: " + howlRoot);
        //howlRoot.MkDir();
    }

    public static string Expand(this string path) => path
    .Replace("~",
        Env.GetFolderPath(Env.SpecialFolder.UserProfile))
    .Replace("%APPDATA%",
        Env.GetFolderPath(Env.SpecialFolder.ApplicationData))
    .Nix();

    public static bool IsDetachedHowlSource(this string π)
    => π.EndsWith(_Howl);

    public static bool IsHowlSource(this string π)
    => π.Nix().StartsWith(howlRoot.Nix()) && π.EndsWith(_Howl);

    public static string Nix(this string x) => x.Replace('\\', '/');

    public static string NoFinalSep(this string path){
        path = path.Nix();
        return path.EndsWith("/") ? path.Substring (0, path.Length - 1) : path;
    }

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
    => path.StartsWith("Assets/") || path.StartsWith("Assets\\");

    public static bool InHowlPath(this string π) => π.StartsWith(howlRoot);

    public static string howlRoot{ get{
        var root = FindHowlRoot();
        if (root == null){
            root = $"Assets/{projectName}.Howl/";
            (root + ROOT_TOKEN).Write("ROOT");
        }
        return root;
    }}

    // NOTE: App.dataPath uses forward slashes, even on Windows
    public static string projectName{ get{
        string[] s = Application.dataPath.Split('/');
        return s[s.Length - 2];
    }}

    // PRIVATE ------------------------------------------------------

    static string FindHowlRoot(){
        string root = FileSystem.Path("Assets/", ROOT_TOKEN);
        if (root == null) return null;
        else{
            // TODO don't want a sep at end but noticed too late.
            var dir = root.DirName() + "/";
            int i = dir.IndexOf("Assets/");
            return dir.Substring(i);
        }
    }

}}
