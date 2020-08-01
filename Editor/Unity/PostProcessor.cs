using UnityEditor; using UnityEngine;

namespace Active.Howl{
public class PostProcessor : AssetPostprocessor{

    static int frame; public static bool verbose = true, warn = false;

    void OnPreprocessAsset(){
        var π = assetPath;
        if (π.IsPackaged() || !π.EndsWith(".howl")) return;
        //
        bool export = Config.ι.allowExport && !Howl.importing ;
        if (export){
            Log( $"Export {π.FileName()}");
            Howl.NitPick(π);
            Howl.ExportFile(π);
        } else
            Warn($"Do not export {π.FileName()} - "
               + $"allowExport: {Config.ι.allowExport}, "
               + $"importing: {Howl.importing}");

    }

    void Log(string x) { if (verbose) Debug.Log(x);        }

    void Warn(string x){ if (verbose && warn) Debug.LogWarning(x); }

}}
