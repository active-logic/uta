using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine;
using static Active.Howl.Path;

namespace Active.Howl{
public static class Howl{

    public static ㅇ warnings = true;
    static Map map = Map.@default;
    static ㅇ _importing;

    public static void ImportDir(string ㅂ){
        _importing = true;
        foreach(var p in FileSystem.Paths(ㅂ, "*.cs"))
            ImportFile(p, p.InPath());
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
        if(!ㅂ.IsHowlSource()){
            Warn($"{ㅂ} should be under {howlRoot}...");
        }else{
            var ㄸ = ㅂ.OutPath();
            var x = File.ReadAllText(ㅂ);
            Directory.GetParent(ㄸ).Create();
            File.WriteAllText(ㄸ, x * map);
            UnityEditor.AssetDatabase.ImportAsset(ㄸ);
        }
    }

    public static void Print(string x) => Debug.Log(x);

    public static ㅇ importing => _importing;

    public static ㅇ Exclude(ㄹ x)
    => x.Contains("▓▒░(°◡°)░▒▓") || x.Contains("👺");

    static void Warn(ㄹ x){ if(warnings) Debug.LogWarning(x); }

}}
