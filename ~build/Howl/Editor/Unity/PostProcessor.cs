using UnityEditor; using UnityEngine;
using System; using Task = System.Threading.Tasks.Task;

namespace Active.Howl{
public class PostProcessor : AssetPostprocessor{

    static bool needsRefresh;
    public static bool verbose = false, warn = true;

    public PostProcessor () => EditorApplication.update += DelayedRefresh;

    void OnPreprocessAsset() {
        var π = assetPath;
        if (π.IsPackaged()) return;
        else if (π.IsHowlSource()) ProcessHowlSource(π );
        else if (π.IsCSharpSource()) CheckEdit(π);
        else if (π.IsAssemblyDefinition()) ProcessAssemblyDefinition(π);
    }

    void ProcessHowlSource(string π){
        log.message = $"Build {π.FileName()}"  ;
        Active.Howl.Util.GiveBack.ι.IncrementUseCount();
        // TODO [build = nitpick and build] should be enforced
        // by Howl, not Unity integration.
        Howl.NitPick(π);
        Howl.BuildFile(π);
        needsRefresh = true;
    }

    // No multiple ADB refresh when importing several files (perf.)
    void DelayedRefresh(){
        if(!needsRefresh) return ;
        AssetDatabase.Refresh();
        needsRefresh = false;
    }

    void ProcessAssemblyDefinition(string π) {
        // 🐤 "Don't know what to do with this";
    }

    void CheckEdit(string ㄸ){
        if (!ㄸ.In(Path.buildRoot)) return ;
        var ㅂ = ㄸ.SourcePath();
        if (!ㅂ.Exists()){
            log.message = $"Edited {ㄸ}\n({ㅂ} does not exist)";
            if (ㅂ.DirName().IsDir())
                log.error = "(°ㅂ°╬) ↯ creating C# scripts on the Howl path "
                                                       + "is unsafe";
            else  log.warning = "Edited C# file without counterpart: {π}";
            return ;
        } else if (ㄸ.DateModified() > ㅂ.DateModified()){
            log.error = $"(‡▼益▼) ↯ changes to {ㄸ.FileName()} will be "
                     + "overwritten when you @%#!~ the *.howl source";
        } else if (ㄸ.DateModified() < ㅂ.DateModified()){
            var δ = ㅂ.DateModified() - ㅂ.DateModified();
            log.warning = $"Reimporting {ㄸ.FileName()}, older than its *.howl "
                                                      + "counterpart";
        }
    }

}}
