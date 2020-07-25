using System.IO;
using System.Collections.Generic;
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

    public static List<ㄹ> ImportDir(ㄹ ㅂ, ㄹ ext = "*.cs",
                                          ㅇ dry = false,
                                          ㅇ verbose = false){
        var conflicts = new List<ㄹ>();
        _importing = true;
        foreach(var p in FileSystem.Paths(ㅂ, ext)){
            try{
                ImportFile(p, dry ? null : p.InPath());
            }catch(InvOp ex){
                conflicts.Add($"{p} has conflicts\n{ex.Message}");
            }
        }
        _importing = false;
        if(conflicts.Count > 0 && verbose){
            foreach(var k in conflicts)
                UnityEngine.Debug.LogError(k);
        }
        return conflicts;
    }

    public static void ImportFile(ㄹ ㅂ, ㄹ ㄸ){
        ㄹ x = File.ReadAllText(ㅂ);
        ㄹ y = Exclude(x) ? x : x / map;
        if(ㄸ != null){
            var dir = Directory.GetParent(ㄸ);
            dir.Create();
            File.WriteAllText(ㄸ, y);
            UnityEditor.AssetDatabase.ImportAsset(ㄸ);
        }
    }

    public static void ExportFile(ㄹ ㅂ){
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

    public static void NitPick(ㄹ ㅂ, ㄹ ㄸ=null){
        // TODO ideally guard against double nitpick, which occurs
        // because an importing file is modified
        // UnityEngine.Debug.Log($"Nitpicking {ㅂ}");
        ㄹ x = File.ReadAllText(ㅂ);
        ㄹ y = Exclude(x) ? x : x % map;
        if(x == y) return;
        (ㄸ ?? ㅂ).Write(y);
    }

    public static void Print(ㄹ x) => Debug.Log(x);

    public static ㅇ importing => _importing;

    public static ㅇ Exclude(ㄹ x)
    => x.Contains("▓▒░(°◡°)░▒▓") || x.Contains("👺");

    static void Warn(ㄹ x){ if(warnings) Debug.LogWarning(x); }

}}
