using System.Collections.Generic; using System;
using UnityEditor; using UnityEngine; using ADB = UnityEditor.AssetDatabase;
using S = Active.Howl.UIStrings;

// TODO honor allowExport, allowImport
namespace Active.Howl{ public class ContextMenu{

    [MenuItem(S.ApplySymset, false, 0)]
    static void ApplySymset () => Do(Howl.ReimportFile, "Updating", ".howl");

    [MenuItem(S.UseHowl, false, 0)]
    static void UseHowl () => Do(Howl.ImportFile, "Importing", ".cs");

    [MenuItem(S.UseCSharp, false, 0)]
    static void UseCs () => Do(Howl.ExportFile, "Exporting", ".howl");

    // Validators ---------------------------------------------------

    [MenuItem(S.ApplySymset, true), MenuItem(S.UseCSharp, true)]
    static bool IsHowlFileAction () => ValidateSel(".howl");

    [MenuItem(S.UseHowl, true)]
    static bool IsCsFileAction () => ValidateSel(".cs");

    // --------------------------------------------------------------

    static void Do(Action<string> α, string verb, string fileType){
        var Λ = Sel(fileType); int N = Λ.Count;
        if (N == 0) Debug.Log($"No input");
        else if (N == 1) Debug.Log($"{verb} {Λ[0].FileName()}");
        else         Debug.Log($"{verb} {N} files");
        Λ.ForEach(α);
        AssetDatabase.Refresh();
    }

    static bool ValidateSel(string ext){
        var Λ = Sel(ext);  if (Λ.Count == 0)             return false;
        foreach (var x in Λ)      if (x.Contains(Path.buildRoot)) return false;
        return true;
    }

    static List<string> Sel(string ext) => Selection.assetGUIDs.GUIDsToPaths(ext);

}}
