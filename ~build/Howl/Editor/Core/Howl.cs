using System.Collections.Generic;
using InvOp = System.InvalidOperationException;
using UnityEngine;
using static Active.Howl.Path;

namespace Active.Howl{
public static class Howl{

    public static bool warnings = true;
    static Map map = Map.@default;
    static bool _importing;

    public static List<string> ImportDir(string ㅂ, string ext= "*.cs", bool dry = false, bool verbose = false){
        var conflicts = new List<string>();
        _importing = true;
        foreach (var π in FileSystem.Paths(ㅂ, ext)){
            try {
                ImportFile(π, dry);
            } catch (InvOp ex){
                conflicts.Add($"{π} has conflicts\n{ex.Message}");
            }
        }
        _importing = false;
        if (conflicts.Count > 0 && verbose) foreach (var k in conflicts) Err(k);
        return conflicts;
    }

    public static string ImportFile(string π, bool dry){
        var σ = π.SetExtension(Path._Howl);
        ImportFile(π, dry ? null : σ);
        var θ = σ.BuildPath();
        π.Rename(θ, dry);
        return dry ? $"Import\n{π} as\n{σ} and move it to\n{θ}" : null;
    }

    public static string ImportFile(string ㅂ, string ㄸ){
        string x = ㅂ.Read();
        string y = ImportAsIs(x) ? x : x / map;
        string z = y * map;
        if (x != z){
            Warn($"{Wards.Cerberus} 〜 {ㅂ}");
            y = WithCerberusWard(x);
        }
        ㄸ?.Write(y, date: ㅂ. DateModified());
        return y;
    }

    public static void BuildFile(string ㅂ){
        if (!ㅂ.IsHowlSource())
           Warn($"{ㅂ} should be under {howlRoot}...");
        else BuildFile(ㅂ, ㅂ.BuildPath());
    }

    public static string BuildFile(string ㅂ, string ㄸ){
        string x = ㅂ.Read();
        if (x.StartsWith(cerberusWard)) return DismissCerberus(x, ㄸ);
        string y = ExportAsIs(x) ? x : x * map;
        ㄸ?.Write(y, date: ㅂ.DateModified());
        return y;
    }

    // TODO ensure no double nitpick
    public static string NitPick(string ㅂ, string ㄸ = null, bool force = false){
        string x = ㅂ.Read();
        string y = (NitPickAsIs(x) && !force) ? x : x % map;
        if (x != y) (ㄸ ?? ㅂ).Write(y);
        return y;
    }

    public static string DismissCerberus(string x, string ㄸ){
        while (x.StartsWith(cerberusWard))
            x = x.Substring(cerberusWard.Length);
        ㄸ?.Write(x, mkdir: true, importAsset: true);
        return x;
    }

    // --------------------------------------------------------------

    public static string WithCerberusWard(string x)
    => x.StartsWith(cerberusWard) ? x : cerberusWard + x;

    public static bool ImportAsIs(string x) => x.Contains(Wards.GardenOfEden) || x.Contains(Wards.Tengu);

    public static bool ExportAsIs(string x) => x.Contains(Wards.Cerberus);

    public static bool NitPickAsIs(string x) => ImportAsIs(x) || ExportAsIs(x);

    public static void Print(string x) => Debug.Log(x);

    static void Warn(string x){ if (warnings) Debug.LogWarning(x); }

    static void Err(string x) => Debug.LogError(x);

    // --------------------------------------------------------------

    public static string cerberusWard => Wards.Cerberus.Comment();

    public static bool importing => _importing;

}}
