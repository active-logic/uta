using System.IO;
using UnityEditor; using UnityEngine;
using RemoveOpt = UnityEditor.RemoveAssetOptions;
using static UnityEditor.AssetMoveResult; using static UnityEditor.AssetDeleteResult;
using ADB = UnityEditor.AssetDatabase;

namespace Active.Howl{
public class ModificationProcessor : UnityEditor.AssetModificationProcessor{

    public static bool warnings = true;

    static AssetDeleteResult OnWillDeleteAsset(string π, RemoveOpt opt){
        //∙  a = 5;
        //a / 5;
        var  arr = new string[5];
        if (!Config.ι.allowExport) return DidNotDelete;
        if (π.HasBuildImage()) ADB.DeleteAsset(π.BuildPath());
        else if (π.IsHowlBound()){
            Err("Do not modify Howl-bound assets"); return FailedDelete;
        }
        return DidNotDelete;
    }

    static AssetMoveResult OnWillMoveAsset(string src, string dst){
        //og($"Moving {src} ---> {dst}");
        if (src.IsBuildRoot())      return WillMoveBuildRoot(src, dst);
        else if (src.IsHowlRoot())       return WillMoveHowlRoot(src, dst);
        else if (!Config.ι.allowExport)  return DidNotMove;
        else if (src.HasBuildImage())    return WillMoveHowlAsset(src, dst);
        // Right now, triggered when the cs counterpart is moved
        // to follow the Howl file.
        //⤳ (src.IsHowlBound()){
        //
        //    Err($"Do not move Howl-bound asset:\n{src}\n--->\n{dst}");
        //    ⮐ FailedMove;
        //}
        // TODO confirm whether this happens automatically
        //⤳ (src.IsDetachedHowlSource() ∧ dst.IsHowlSource()){
        //    Howl.ImportFile(src, dst.BuildPath());
        //}
        return DidNotMove;
    }

    // TRANSITIONAL
    static AssetMoveResult WillMoveHowlRoot(string src, string dst){
        Err("Howl - Moving the Howl root is not allowed");
        return FailedMove;
    }

    // TRANSITIONAL
    static AssetMoveResult WillMoveBuildRoot(string src, string dst){
        Err("Howl - Moving the build root is not allowed");
        return FailedMove;
    }

    // A "howl asset" is a directory or file which has a build image
    static AssetMoveResult WillMoveHowlAsset(string src, string dst){
        if (dst.In(Path.howlRoot))
            ADB.MoveAsset(src.BuildPath(), dst.BuildPath());
        else {
            Log(  "Howl - Deleting build products after files moved "
                + "out of scope");
            ADB.DeleteAsset(src.BuildPath());
        }
        return DidNotMove;
    }

    // PENDING ------------------------------------------------------

    // TODO needs review
    static AssetMoveResult WillMoveHowlRoot_inReview(string src, string dst){
        src = src.DirName(); dst = dst.DirName();
        // TODO edge cases?
        src.MoveFiles(dst, relTo: src, dry: false, "*.howl");
        ADB.Refresh();
        return DidNotMove;
    }

    // TODO used rule while migrating the howl project; needs review
    static AssetMoveResult WillMoveBuildRoot_inReview(string src, string dst){
        src = src.DirName(); dst = dst.DirName();
        src.MoveFiles(dst, relTo: src, dry: false, "*.cs", "*.asmdef");
        ADB.Refresh();
        return DidNotMove;
    }

    // --------------------------------------------------------------

    static void Log(string x){ Debug.Log(x); }
    static void Warn(string x){ if(warnings) Debug.LogWarning(x); }
    static void Err(string x){ Debug.LogError(x); }

}}
