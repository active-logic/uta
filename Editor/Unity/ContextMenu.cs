using UnityEditor; using UnityEngine;
using ADB = UnityEditor.AssetDatabase;
using Dir = System.IO.Directory;

namespace Active.Howl{
public class ContextMenu{

    [MenuItem("Assets/(╯°□°)╯⌢ Howl")]
    static bool Import(){
        if (!Config.ι.allowImport)
            return Warn("(⁎˃ᆺ˂) 〜 Enable import in Howl window first");
        var guids = Selection.assetGUIDs;
        if(guids.Length != 1)
            return Warn("(⁎˃ᆺ˂) 〜 Select exactly one directory");
        //
        var π = ADB.GUIDToAssetPath(guids[0]);
        //
        if(π.InHowlPath()) return Warn("( ﾟ∀ ﾟ)");
        if(!Dir.Exists(π)) return Warn($"(｀^´)> 〜 {π} is not a directory");
        //
        Howl.ImportDir(π);
        Debug.Log($"Generated under {π.InPath()}");
        return true;
    }

    static bool Warn(string msg){ Debug.LogWarning(msg); return false; }

}}
