using System.IO;
using System.Collections.Generic;
using InvOp = System.InvalidOperationException;
using UnityEngine;
using static Active.Howl.Path;

namespace Active.Howl{
public static class Howl{

    public static bool warnings = true;
    static Map map = Map.@default;
    static bool _importing;

    public static List<string> ImportDir(string ㅂ, string ext = "*.cs",
                                          bool dry = false,
                                          bool verbose = false){
        var conflicts = new List<string>();
        _importing = true;
        foreach(var p in FileSystem.Paths(ㅂ, ext)){
            try{
                ImportFile(p, dry ? null : p.InPath());
            }catch(InvOp ex){
                conflicts.Add($"{p} has conflicts\n{ex.Message}");
            }
        }
        _importing = false;
        if(conflicts.Count > 0 &&  verbose){
            foreach(var k in conflicts)
                UnityEngine.Debug.LogError(k);
        }
        return conflicts;
    }

    public static void ImportFile(string ㅂ, string ㄸ){
        string x = File.ReadAllText(ㅂ);
        string y = Exclude(x) ? x : x / map;
        if(ㄸ != null){
            Directory.GetParent(ㄸ).Create();
            File.WriteAllText(ㄸ, y);
            UnityEditor.AssetDatabase.ImportAsset(ㄸ);
        }
    }

    public static void ExportFile(string ㅂ){
        if(!ㅂ.IsHowlSource()){
            Warn($"{ㅂ} should be under {howlRoot}...");
        }else{
            var ㄸ = ㅂ.OutPath();
            var x = File.ReadAllText(ㅂ);
            Directory.GetParent(ㄸ).Create();
            x *= map;
            File.Delete(ㄸ);
            File.WriteAllText(ㄸ, x);
            UnityEditor.AssetDatabase.ImportAsset(ㄸ);
        }
    }

    public static void NitPick(string ㅂ, string ㄸ=null){
        // TODO ideally guard against double nitpick, which occurs
        // because an importing file is modified
        // UnityEngine.Debug.Log($"Nitpicking {ㅂ}");
        string x = File.ReadAllText(ㅂ);
        string y = Exclude(x) ? x : x % map;
        if(x == y) return;
        (ㄸ ?? ㅂ).Write(y);
    }

    public static void Print(string x) => Debug.Log(x);

    public static bool importing => _importing;

    public static bool Exclude(string x)
    => x.Contains("▓▒░(°◡°)░▒▓") || x.Contains("👺");

    static void Warn(string x){ if(warnings) Debug.LogWarning(x); }

}}
