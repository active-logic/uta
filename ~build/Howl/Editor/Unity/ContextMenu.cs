using System.Collections.Generic; using System;
using UnityEditor; using UnityEngine; using ADB = UnityEditor.AssetDatabase;
using S = Active.Howl.UIStrings.Main;

namespace Active.Howl{ public class ContextMenu{

    [MenuItem(S.ApplySymset, false, 0)] static void ApplySymset
    () => Do(Howl.ReimportFile, "Updating", Path._Howl);

    [MenuItem(S.UseHowl, false, 0)] static void UseHowl
    () => Do(Howl.ImportFile, "Importing", Path._Cs, Path._Asmdef);

    [MenuItem(S.UseCSharp, false, 0)] static void UseCs(){
        Do(Howl.ExportFile, "Exporting", Path._Howl, Path._Asmdt);
        Path.buildRoot.Clean();
    }

    // Validators ---------------------------------------------------

    [MenuItem(S.ApplySymset, true), MenuItem(S.UseCSharp, true)]
    static bool IsHowlFileAction () => ValidateSel(Path._Howl);

    [MenuItem(S.UseHowl, true)]
    static bool IsCsFileAction () => ValidateSel(Path._Cs, Path._Asmdef);

    // --------------------------------------------------------------

    static void Do(Action<string> α, string verb, params string[] types){
        var Λ = Sel(types); int N = Λ.Count;
        if (N == 0) log.message = $"No input";
        else if (N == 1) log.message = $"{verb} {Λ[0].FileName()}";
        else         log.message = $"{verb} {N} files";
        Λ.ForEach(α);
        AssetDatabase.Refresh();
    }

    static bool ValidateSel(params string[] ext){
        var Λ = Sel(ext);  if (Λ.Count == 0)             return false;
        foreach (var x in Λ)      if (x.Contains(Path.buildRoot)) return false;
        return true;
    }

    static List<string> Sel(params string[] types)
    => Selection.assetGUIDs.GUIDsToPaths(types);

}}
