using System.Collections.Generic;
using Ex = System.Exception; using InvOp = System.InvalidOperationException;
#if UNITY_EDITOR
using UnityEngine; using UnityEditor;
using S = Active.Howl.Messages;
#endif
using static Active.Howl.Path ;

namespace Active.Howl{
public static class Howl{

    public static bool warnings = true;
    static Map map = Map.@default;

    // --------------------------------------------------------------

    #if UNITY_EDITOR

    public static void ExportAll(){
        log.message = "Convert *.howl scripts to C# 〜 (;ω;)";
        ExportDir("Assets/", verbose: true);
    }

    public static void ImportAll(){
        log.message = "Convert *.cs scripts to Howl 〜 (╯°□°)╯ ⌢ C#";
        ImportDir("Assets/", verbose: true);
    }

    public static void ReApply(){
        log.message = "Apply notation";
        FileSystem.Paths(Path.howlRoot, "*.howl")
                  .ForEach(ReimportFile);
    }

    public static void Refresh(){
        log.message = "Refresh";
        Rebuild(quick: true);
    }

    public static void Rebuild(){
        log.message = "Rebuild";
        // Do not delete metafiles on rebuild or scene scripts unbind
        Path.buildRoot.DeleteFiles("*.cs", withMetaFile: false);
        Rebuild(quick: false);
    }

    public static void Rebuild(bool quick){
        foreach (var x in FileSystem.Paths(Path.howlRoot, "*.howl")){
            if(!quick || x.DateModified() > Config.ι.lastExportDate){
                log.message = $"Building {x.FileName()}";
                BuildFile(x);
            }
        } AssetDatabase.Refresh();
    }

    #endif

    // --------------------------------------------------------------

    public static void BuildFile(string ㅂ){
        if (!ㅂ.IsHowlSource())
            That.Logger.Warn($"{ㅂ} should be under {howlRoot}...");
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

    // TODO - from Builder.howl, compared to other methods, somewhat
    // different contract
    public static bool Export(string src, string dst){
        src = src.WithFinalSep();
        dst = dst.WithFinalSep();
        if (!src.IsDir()){ log.message =$"Source dir not found: {src}\n"; return false; }
        var paths = FileSystem.Paths(src, "*.howl");
        foreach (var x in paths){
            var y = dst + x.RelativeTo(src).SetExtension(".cs");
            Howl.BuildFile(x, y);
        } return true;
    }

    public static void ExportDir(string π, bool verbose=false)
    => FileSystem.Paths(π, "*.howl", "*.asmdt").ForEach(ExportFile);

    public static void ExportFile(string π){
        #if UNITY_EDITOR
        if (!Config.ι.allowExport) throw new Ex(S.EnableExport);
        #endif
        ExportFile(π, dry: false);
    }

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
        foreach (var π in FileSystem.Paths(ㅂ, ext, "*.asmdef")){
            if (π.In(Path.buildRoot)) continue;
            try {
                ImportFile(π, dry);
            } catch (InvOp ex){
                conflicts.Add($"{π} has conflicts\n{ex.Message}");
            }
        }
        if (conflicts.Count > 0 && verbose) foreach (var k in conflicts) log.error = k;
        return conflicts;
    }

    public static void ImportFile(string π){
        #if UNITY_EDITOR
        if (!Config.ι.allowImport) throw new Ex(S.EnableImport);
        #endif
        ImportFile(π, dry: false);
    }

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
            if (fromPath != null) log.warning = $"{Wards.Cerberus} 〜 {fromPath}";
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

    public static string cerberusWard => Wards.Cerberus.Comment();

}}
