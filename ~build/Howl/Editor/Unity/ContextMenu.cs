using System.Collections.Generic;
using UnityEditor; using UnityEngine; using ADB = UnityEditor.AssetDatabase;
using Sel = UnityEditor.Selection;

namespace Active.Howl{ public class ContextMenu{

    [MenuItem("Assets/☆ Apply symset ", false, 0)]
    static void ApplySymset(){
        UnityEngine.Debug.Log($"Apply symset");
        foreach (var π in Selected(".howl")) Howl.ReimportFile(π, dry: false);
    }

    static List<string> Selected(string filetype)
    => Sel.assetGUIDs.GUIDsToPaths(filetype);

    [MenuItem("Assets/⎚ Use Howl 〜 (╯°□°)╯", false, 0)]
    static void UseHowl(){
        if (!Config.ι.allowImport){
            Warn("(⁎˃ᆺ˂) 〜 Enable import in Howl window first");
            return ;
        }
        foreach (var π in Sel.assetGUIDs.GUIDsToDirs()){
            if(!π.InHowlPath()){
                Howl.ImportDir(π);
                Log($"Howl scripts @ {π.SourcePath()}");
            }
        }
    }

    [MenuItem("Assets/⎚ Use C# (remove Howl scripts)", false, 0)]
    static void UseCSharp(){
        foreach (var π in Sel.assetGUIDs.GUIDsToDirs()){
            if (π.InHowlPath()){
                Log($"Remove Howl scripts 〜 {π}");
                π.RmDir();
            }
        }
        AssetDatabase.Refresh();
    }

    static bool Log(string msg){ Debug.Log(msg); return true; }

    static bool Warn(string msg){ Debug.LogWarning(msg); return false; }

}}
