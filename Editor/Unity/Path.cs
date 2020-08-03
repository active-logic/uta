using System.Collections.Generic;
using UnityEditor;
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

    public static bool HasExtension(this string π, string ext) => π.EndsWith(ext);

    public static List<string> GUIDsToDirs(this string[] ㅂ){
        var ㄸ = new List<string>();
        foreach (var guid in ㅂ){
            var π = AssetDatabase.GUIDToAssetPath(guid);
            if(System.IO.Directory.Exists(π)) ㄸ.Add(π);
        }
        return ㄸ;
    }

    public static bool InAssets(this string path)
    => path.StartsWith("Assets/") || path.StartsWith("Assets" + '\\');

    public static bool InHowlPath(this string π) => π.StartsWith(howlRoot);

    public static bool IsHowlBound(this string π) => π.InPath().Exists();

    public static bool IsPackaged(this string π) => π.StartsWith("Packages/");

    public static bool IsDetachedHowlSource(this string π) => π.EndsWith(_Howl);

    public static bool IsHowlSource(this string π)
    => π.FullPath().StartsWith(howlRoot.FullPath());

    public static bool IsCSharpSource(this string π) => π.EndsWith(".cs");

    public static string Nix(this string x) => x.Replace('\\', '/');

    public static string NoFinalSep(this string π)
    => (π = π.Nix()).EndsWith("/") ? π.Substring (0, π.Length - 1) : π;

    public static string SetExtension(this string π, string ext)
    => SysPath.ChangeExtension(π, ext);

    // --------------------------------------------------------------

    // Given path to a C# file or a directory outside the howl path,
    // return matching Howl path
    public static string InPath(this string ㅂ){
        if(!ㅂ.InAssets()){
            var i = ㅂ.IndexOf("Assets");
            if(i < 0) throw new InvOp($"{ㅂ} not in Assets/");
            ㅂ = ㅂ.Substring(i);
        }
        ㅂ = ㅂ.Substring("Assets/".Length);
        var  ㄸ = ㅂ.HasExtension(_Cs) ? ㅂ.SetExtension(_Howl) : ㅂ;
        return $"{howlRoot}{ㄸ}";
    }

    // Given path to a howl, or directory on the howl path
    // return matching C#/export path
    public static string OutPath(this string ㅂ){
        if (!ㅂ.IsHowlSource())
            throw new InvOp($"{ㅂ} doesn't howl");
        var π     = ㅂ.FullPath();
        var @base = howlRoot.FullPath();
        if (!π.StartsWith(@base))
            throw new InvOp($"{ㅂ} not in howl path");
        π = π.Substring(@base.Length);
        var  ㄸ = π.HasExtension(_Howl) ? π.SetExtension(_Cs) : π;
        return "Assets/" + ㄸ;
   }

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
