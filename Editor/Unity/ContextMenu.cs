using UnityEditor; using UnityEngine;
using ADB = UnityEditor.AssetDatabase;
using Dir = System.IO.Directory;

namespace Active.Howl{
public class ContextMenu{

    [MenuItem("Assets/(╯°□°)╯⌢ Howl")]
    static bool Import(){
        var guids = Selection.assetGUIDs;
        if(guids.Length != 1) return Warn("(⁎˃ᆺ˂) => sel⠇ ≠ 1");
        //
        var π = ADB.GUIDToAssetPath(guids[0]);
        //
        if(π.InHowlPath())    return Warn("( ﾟ∀ ﾟ)");
        if(!Dir.Exists(π))    return Warn($"(｀^´)> [{π}] ≠ a dir/");
        //
        Howl.ImportDir(π);
        Debug.Log($"Generated under {π.InPath()}");
        return true;
    }

    static bool Warn(string msg){ Debug.LogWarning(msg); return false; }

}}
