using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine;

// TODO - files that include legacy 'using' do not import correctly
namespace Active.Howl{
public static class Howl{

    static Map map = Map.@default;

    public static void ImportDir(string ㅂ){
        foreach(var p in FileSystem.Paths(ㅂ, "*.cs"))
            ImportFile(p, InPath(p));
    }

    public static void ImportFile(string ㅂ, string ㄸ){
        var x = File.ReadAllText(ㅂ) * map;
        var dir = Directory.GetParent(ㄸ);
        dir.Create();
        File.WriteAllText(ㄸ, x / map);
    }

    public static void ExportFile(string ㅂ){
        (string path, string msg) ㄸ = Outpath(ㅂ);
        if(ㄸ.msg != null){ Debug.LogWarning(ㄸ.msg); return; }
        var x = File.ReadAllText(ㅂ);
        Directory.GetParent(ㄸ.path).Create();
        File.WriteAllText(ㄸ.path, x * map);
        UnityEditor.AssetDatabase.ImportAsset(ㄸ.path);
    }

    // Given a path to a cs file, return the path to the matching
    // howl file.
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

    public static string root => $"Assets/{projectName}.Howl/";

    public static string projectName{ get{
        string[] s = Application.dataPath.Split('/');
        return s[s.Length - 2];
    }}


}}
