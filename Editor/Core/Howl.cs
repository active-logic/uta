using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine;

namespace Active.Howl{
public static class Howl{

    static Map map = Map.@default;
    static ㅇ _importing;

    public static void ImportDir(string ㅂ){
        _importing = true;
        foreach(var p in FileSystem.Paths(ㅂ, "*.cs"))
            ImportFile(p, InPath(p));
        _importing = false;
    }

    public static void ImportFile(string ㅂ, string ㄸ){
        var x = File.ReadAllText(ㅂ);
        var dir = Directory.GetParent(ㄸ);
        dir.Create();
        File.WriteAllText(ㄸ, Exclude(x) ? x : x / map);
        UnityEditor.AssetDatabase.ImportAsset(ㄸ);
    }

    public static void ExportFile(string ㅂ){
        (string path, string msg) ㄸ = Outpath(ㅂ);
        if(ㄸ.msg != null){ Debug.LogWarning(ㄸ.msg); return; }
        var x = File.ReadAllText(ㅂ);
        Directory.GetParent(ㄸ.path).Create();
        File.WriteAllText(ㄸ.path, x * map);
        UnityEditor.AssetDatabase.ImportAsset(ㄸ.path);
    }

    // Given path to a cs file, return path to matching howl file
    public static string InPath(string ㅂ){
        var π = "Assets/";
        if(!ㅂ.StartsWith(π)){
            var i = ㅂ.IndexOf(π);
            if(i < 0) throw new InvOp($"{ㅂ} not in {π}");
            ㅂ = ㅂ.Substring(i);
        }
        var ㄸ = ㅂ.Substring(π.Length).Replace(".cs", ".howl");
        return $"{root}{ㄸ}";
    }

    public static (string path, string msg) Outpath(string ㅂ){
        if(!ㅂ.StartsWith(root))
            return (null, $"{ㅂ} should be under {root}...");
        var ㄸ = ㅂ.Substring(root.Length).Replace(".howl", ".cs");
        return ($"Assets/{ㄸ}", null);
    }

    public static void Print(string x) => Debug.Log(x);

    public static ㅇ importing => _importing;

    public static string root => $"Assets/{projectName}.Howl/";

    public static string projectName{ get{
        string[] s = Application.dataPath.Split('/');
        return s[s.Length - 2];
    }}

    public static ㅇ Exclude(ㄹ x)
    => x.Contains("▓▒░(°◡°)░▒▓") || x.Contains("👺");

}}
