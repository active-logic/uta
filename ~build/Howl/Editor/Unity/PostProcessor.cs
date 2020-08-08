using UnityEditor; using UnityEngine;

namespace Active.Howl{
public class PostProcessor : AssetPostprocessor{

    public static bool verbose = false, warn = true;

    void OnPreprocessAsset(){
        var π = assetPath;
        if (π.IsCSharpSource()) {
            CheckEdit(π); return ;
        } else if (π.IsPackaged() || !π.EndsWith(".howl")) return;
        if (Config.ι.allowExport){
            log.message = $"Export {π.FileName()}";
            Howl.NitPick(π) ;
            Howl.BuildFile(π);
            AssetDatabase.ImportAsset(π.BuildPath());
        }
        else if (!Config.ι.allowExport ) log.message = $"Cannot convert {π}\n"
                   + "Please enable export in the Howl Window";
        else
          log.warning = $"Cannot convert {π} while Unity is importing assets";
    }

    void CheckEdit(string ㄸ){
        if (!ㄸ.In(Path.buildRoot)) return ;
        var ㅂ = ㄸ.SourcePath();
        if (!ㅂ.Exists()){
            log.message = $"Edited {ㄸ}";
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
