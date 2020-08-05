using System.Collections.Generic;
using ArgEx = System.ArgumentException;
using UnityEditor;
using Env = System.Environment; using SysPath = System.IO.Path;
using InvOp = System.InvalidOperationException;
using UnityEngine;

namespace Active.Howl{
public static class Path{

    static int frame;
    static string cachedBuildRoot;

    const string HOWL_ROOT_TOKEN       = "howl.root";
    const string BUILD_ROOT_TOKEN = "howl.build";

    public static string _Howl = ".howl", _Cs = ".cs";

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

    public static bool HasBuildImage(this string π){
        if (π.In(buildRoot) || !π.In(howlRoot)) return false;
        var α = buildRoot + π.RelativeTo(howlRoot);
        if (α.TypeIs(_Howl)) α = α.SetExtension(_Cs);
        return α.Exists();
    }

    public static bool TypeIs(this string π, string ext) => π.EndsWith(ext);

    public static List<string> GUIDsToPaths(this string[] ㅂ, string fileType){
        var ㄸ = new List<string>();
        foreach (var guid in ㅂ){
            var π = AssetDatabase.GUIDToAssetPath(guid);
            if (π.IsFile()){
                if (π.TypeIs(fileType)) ㄸ.Add(π);
            }else if (π.IsDir()){
                string pattern = "*" + fileType;
                foreach (var x in FileSystem.Paths(π, pattern)) ㄸ.Add(x);
            }
        }
        return new List<string>(new HashSet<string>(ㄸ));
    }

    public static bool InAssets(this string path)
    => path.StartsWith("Assets/") || path.StartsWith("Assets" + '\\');

    public static bool In(this string π, string that) => π.FullPath().StartsWith(that.FullPath());

    // TODO unreliable
    public static bool InHowlPath(this string π) => π.StartsWith(howlRoot);

    public static bool IsHowlBound(this string π) => π.In(buildRoot) ?
                              π.SourcePath().Exists() : false;

    public static bool IsBuildRoot(this string π) => π.FileName() == BUILD_ROOT_TOKEN;

    public static bool IsHowlRoot(this string π) => π.FileName() == HOWL_ROOT_TOKEN;

    public static bool IsPackaged(this string π) => π.StartsWith("Packages/");

    public static bool IsDetachedHowlSource(this string π) => π.EndsWith(_Howl);

    public static bool IsHowlSource(this string π) => π.TypeIs(_Howl) && π.In(howlRoot);

    public static bool IsCSharpSource(this string π) => π.EndsWith(".cs");

    public static string MetaFile(this string π) => (π = π + ".meta").Exists() ? π : null;

    public static string Nix(this string x) => x.Replace('\\', '/');

    public static string NoFinalSep(this string π)
    => (π = π.Nix()).EndsWith("/") ? π.Substring (0, π.Length - 1) : π;

    public static string RelativeTo(this string π, string κ){
        π = π.FullPath(); κ = κ.FullPath();
        if (κ[κ.Length-1] != '/') κ += '/';
        return π.StartsWith(κ) ? π.Substring(κ.Length)
                   : throw new ArgEx($"{π} is not a subpath of {κ}");
    }

    public static string SetExtension(this string π, string ext) => SysPath.ChangeExtension(π, ext);

    // --------------------------------------------------------------

    // Given path to a C# file or a directory outside the howl path,
    // return matching Howl path
    public static string SourcePath(this string π){
        π = howlRoot + π.RelativeTo(buildRoot);
        return π.TypeIs(_Cs) ? π.SetExtension(_Howl) : π;
    }

    // Given path to howl source or a dir. on Howl path, return the
    // matching C#/export path
    public static string BuildPath(this string ㅂ){
        if(!ㅂ.In(howlRoot)) throw new InvOp($"{ㅂ} not in Howl path");
        ㅂ = ㅂ.RelativeTo(howlRoot);
        var ㄸ = ㅂ.TypeIs(_Howl) ? ㅂ.SetExtension(_Cs) : ㅂ;
        return buildRoot + ㄸ;
   }

    // Properties ---------------------------------------------------

    public static bool howlRootExists => true;   // FindHowlRoot() ≠ ∅;

    public static string assets => "Assets/";

    public static string howlRoot => assets;  // GetHowlRoot().path;

    public static string buildRoot{get{
        if (cachedBuildRoot != null && frame == Time.frameCount)
            return cachedBuildRoot;
        else {
            frame = Time.frameCount; return cachedBuildRoot =
                GetRoot(defaultBuildRoot, BUILD_ROOT_TOKEN).path;
        }
    }}

    public static string defaultHowlRoot => $"{assets}{projectName}.Howl/";

    public static string defaultBuildRoot => $"{assets}~build";

    // NOTE: App.dataPath uses forward slashes, even on Windows
    public static string projectName{ get{
        string[] s = Application.dataPath.Split('/');
        return s[s.Length - 2];
    }}

    // PRIVATE ------------------------------------------------------

    static (string path, bool didCreate) GetRoot(string @default, string token
                                               , bool writeToken = true){
        var ρ = FindRoot(token);
        if (ρ == null){
            if (writeToken) (@default + token).Write("0", mkdir: true);
            return (@default, true);
        } else
            return (ρ, false);
    }

    public static string FindRoot(string token){
        string root = FileSystem.Path(assets, token);
        if (root == null) return null;
        else {
            var dir = root.DirName() + "/";
            int i = dir.IndexOf(assets);
            return dir.Substring(i);
        }
    }

    // DEPRECATE - Use GetRoot
    static (string path, bool didCreate) GetHowlRoot(){
        var root = FindHowlRoot();
        if (root == null){
            root = defaultHowlRoot;
            (root + HOWL_ROOT_TOKEN).Write("ROOT", mkdir: true);
            return  (root, true);
        } else
            return (root, false);
    }

    // DEPRECATE - Use FindRoot
    public static string FindHowlRoot(){
        string root = FileSystem.Path("Assets/", HOWL_ROOT_TOKEN);
        if (root == null) return null;
        else {
            // TODO don't want a sep at end but noticed too late.
            var dir = root.DirName() + "/";
            int i = dir.IndexOf("Assets/");
            return dir.Substring(i);
        }
    }

}}
