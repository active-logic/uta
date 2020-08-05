using System.Collections.Generic;
using InvOp = System.InvalidOperationException;
using UnityEngine;
using static Active.Howl.Path;

namespace Active.Howl{
public static class Howl{

    public static bool warnings = true;
    static Map map = Map.@default;
    static bool _importing;

    // --------------------------------------------------------------

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

    // --------------------------------------------------------------

    public static void ExportFile(string π) => ExportFile(π, dry: false);

    public static string ExportFile(string π, bool dry){
        if (π.TypeIs(_Asmdt)) return ExportAssemblyDefToken(π, dry);
        var σ = π.SetExtension(Path._Cs);
        BuildFile(π, dry ? null : σ);
        var θ = σ.BuildPath();
        if (!dry){
            if (θ.Exists()){
                θ.Delete(withMetaFile: false);
                var m0 = θ.MetaFile();
                var m1 = σ.PathToMetaFile();
                if (m0 != null) System.IO.File.Move(m0, m1);
            }
            π.Delete(withMetaFile: true);
        }
        return dry ? $"Export\n{π} as\n{σ} and move it to\n{θ}" : null;
    }

    public static string ExportAssemblyDefToken(string π, bool dry){
        var σ = π.SetExtension(Path._Asmdef);
        var θ = σ.BuildPath();
        if (!dry){
            θ.MoveTo(σ, withMetaFile: true);
            π.Delete(withMetaFile: true);
        }
        return dry ? $"Rename {θ} to\n{σ}\nand delete {π}" : null;
    }

    // --------------------------------------------------------------

    public static List<string> ImportDir(string ㅂ, string ext= "*.cs", bool dry = false, bool verbose = false){
        var conflicts = new List<string>();
        _importing = true;
        foreach (var π in FileSystem.Paths(ㅂ, ext)){
            if (π.In(Path.buildRoot)) continue;
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

    public static void ImportFile(string π) => ImportFile(π, dry: false);

    public static string ImportFile(string π, bool dry){
        if (π.TypeIs(Path._Asmdef)) return ImportAssemblyDefToken(π, dry);
        var σ = π.SetExtension(Path._Howl);
        ImportFile(π, dry ? null : σ);
        var θ = σ.BuildPath();
        if (!dry) π.MoveTo(θ, withMetaFile: true);
        return dry ? $"Import\n{π} as\n{σ} and move it to\n{θ}" : null;
    }

    public static string ImportAssemblyDefToken(string π, bool dry){
        var σ = π.SetExtension(Path._Asmdt);
        var θ = π.BuildPath();
        if (!dry){
            π.MoveTo(θ, withMetaFile: true);
            σ.Write("Assembly def token\n");
        }
        return dry ? $"Rename {π} to\n{θ}\nand create {σ}" : null;
    }

    public static string ImportFile(string ㅂ, string ㄸ){
        string y = ImportString(ㅂ.Read(), fromPath: ㅂ);
        ㄸ?.Write(y, date: ㅂ.DateModified());
        return y;
    }

    public static string ImportString(string x, string fromPath=null){
        string y = ImportAsIs(x) ? x : x / map;
        if ( x != y * map){
            y = WithCerberusWard(x);
            if (fromPath != null) Warn($"{Wards.Cerberus} 〜 {fromPath}");
        }
        return y;
    }

    // --------------------------------------------------------------

    // TODO ensure no double nitpick
    public static string NitPick(string ㅂ, string ㄸ = null, bool force = false){
        string x = ㅂ.Read();
        string y = (NitPickAsIs(x) && !force) ? x : x % map;
        if (x != y) (ㄸ ?? ㅂ).Write(y);
        return y;
    }

    // --------------------------------------------------------------

    public static void ReimportFile(string π){ ReimportFile(π, false); }

    public static string ReimportFile(string π, bool dry){
        string e = BuildFile(π, null);
        string ㄸ = ImportString(e);
        if (!dry) π.Write(ㄸ);
        return ㄸ;
    }

    // --------------------------------------------------------------

    public static string DismissCerberus(string x, string ㄸ){
        while (x.StartsWith(cerberusWard))
            x = x.Substring(cerberusWard.Length);
        ㄸ?.Write(x, mkdir: true, importAsset: true);
        return x;
    }

    public static bool ExportAsIs(string x) => x.Contains(Wards.Cerberus);

    public static bool ImportAsIs(string x) => x.Contains(Wards.GardenOfEden) || x.Contains(Wards.Tengu);

    public static bool NitPickAsIs(string x) => ImportAsIs(x) || ExportAsIs(x);

    public static string WithCerberusWard(string x)
    => x.StartsWith(cerberusWard) ? x : cerberusWard + x;

    // --------------------------------------------------------------

    public static void Print(string x) => Debug.Log(x);

    static void Warn(string x){ if (warnings) Debug.LogWarning(x); }

    static void Err(string x) => Debug.LogError(x);

    // --------------------------------------------------------------

    public static string cerberusWard => Wards.Cerberus.Comment();

    public static bool importing => _importing;

}}
