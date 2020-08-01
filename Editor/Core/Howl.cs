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
                                  bool dry = false, bool verbose = false){
        var conflicts = new List<string>();
        _importing = true;
        foreach (var p in FileSystem.Paths(ㅂ, ext)){
            try {
                ImportFile(p, dry ? null : p.InPath());
            } catch (InvOp ex){
                conflicts.Add($"{p} has conflicts\n{ex.Message}");
            }
        }
        _importing = false;
        if (conflicts.Count > 0 &&  verbose){
            foreach (var k in conflicts) Err(k);
        }
        return conflicts;
    }

    public static void ImportFile(string ㅂ, string ㄸ){
        string x = ㅂ.Read();
        string y = Exclude(x) ? x : x / map;
        string z = y * map;
        if (x != z) throw new System.Exception($"Integrity: {ㅂ}");
        ㄸ?.Write(y, mkdir: true, importAsset: true);
    }

    public static void ExportFile(string ㅂ){
        if (!ㅂ.IsHowlSource())
            Warn($"{ㅂ} should be under {howlRoot}...");
        else {
            var ㄸ = ㅂ.OutPath();
            string x = ㅂ.Read();
            string y = x * map;
            ㄸ.Write(y, mkdir: true, importAsset: true);
        }
    }

    public static void NitPick(string ㅂ, string ㄸ=null, bool force = false){
        // TODO ideally guard against double nitpick, which occurs
        // because an importing file is modified
        // UnityEngine.Debug.Log($"Nitpicking {ㅂ}");
        string x = ㅂ.Read();
        string y = (Exclude(x) && !force) ? x : x % map;
        if (x != y) (ㄸ ?? ㅂ).Write(y);
    }

    public static void Print(string x) => Debug.Log(x);

    public static bool importing => _importing;

    public static bool Exclude(string x)
    => x.Contains(Wards.GardenOfEden) || x.Contains(Wards.Tengu);

    static void Warn(string x){ if (warnings) Debug.LogWarning(x); }

    static void Err(string x) => Debug.LogError(x);

}}
