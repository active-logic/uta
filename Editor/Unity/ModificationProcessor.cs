using System.IO;
using UnityEditor; using UnityEngine;
using RemoveOpt = UnityEditor.RemoveAssetOptions;
using static UnityEditor.AssetMoveResult; using static UnityEditor.AssetDeleteResult;

namespace Active.Howl{
public class ModificationProcessor : UnityEditor.AssetModificationProcessor{

    public static bool warnings = true;

    static AssetDeleteResult OnWillDeleteAsset(string π, RemoveOpt opt){
        if (!Config.ι.allowExport) return DidNotDelete;
        if (π.IsHowlSource()) AssetDatabase.DeleteAsset(π.OutPath());
        else if (π.IsHowlBound()){
            Err("Do not modify Howl-bound assets"); return FailedDelete;
        }
        return DidNotDelete;
    }

    static AssetMoveResult OnWillMoveAsset(string src, string dst){
        Log($"Moving {src} ---> {dst}");
        if (!Config.ι.allowExport)  return DidNotMove;
        if (src.IsHowlSource())    return WillMoveHowlAsset(src, dst);
        else if (src.IsHowlBound()){
            Err("Do not move Howl-bound assets");
            return FailedMove;
        } else if (src.IsDetachedHowlSource() && dst.IsHowlSource()){
            Howl.ImportFile(src, dst.OutPath());
        }
        return DidNotMove;
    }

    static AssetMoveResult WillMoveHowlAsset(string src, string dst){
        if(dst.IsHowlSource()){
            string x = src.OutPath(), y = dst.OutPath();
            if(x.Exists()){
                AssetDatabase.MoveAsset(x, y);
            }else{
                Warn($"Moved orphaned Howl {src}");
            }
        }else{
            Warn("Moved a Howl outside the path");
            AssetDatabase.DeleteAsset(src.OutPath());
        }
        return DidNotMove;
    }

    static void Log(string x){ Debug.Log(x); }
    static void Warn(string x){ if(warnings) Debug.LogWarning(x); }
    static void Err(string x){ Debug.LogError(x); }

}}
