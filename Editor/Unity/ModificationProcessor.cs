using System.IO;
using UnityEditor; using UnityEngine;
using RemoveOpt = UnityEditor.RemoveAssetOptions;
using static UnityEditor.AssetMoveResult;
using static UnityEditor.AssetDeleteResult;

namespace Active.Howl{
public class ModificationProcessor
           : UnityEditor.AssetModificationProcessor{

    public static bool warnings = true;

    static AssetDeleteResult OnWillDeleteAsset(string π, RemoveOpt opt){
        if(!Config.allowExport) return DidNotDelete;
        if(π.IsHowlSource()) AssetDatabase.DeleteAsset(π.OutPath());
        return DidNotDelete;
    }

    static AssetMoveResult OnWillMoveAsset(string src, string dst){
        if(!Config.allowExport) return DidNotMove;
        if(src.IsHowlSource()){
            if(dst.IsHowlSource()){
                string x = src.OutPath(), y = dst.OutPath();
                if(File.Exists(x)){
                    AssetDatabase.MoveAsset(x, y);
                }else{
                    Warn("Moved orphaned Howl {src}");
                }
            }else{
                Warn("Moved a Howl outside the path");
                AssetDatabase.DeleteAsset(src.OutPath());
            }
        }else if(src.IsDetachedHowlSource() && dst.IsHowlSource()){
            Howl.ImportFile(src, dst.OutPath());
        }
        return DidNotMove;
    }

    static void Warn(string x){ if(warnings) Debug.LogWarning(x); }

}}
