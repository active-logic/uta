using UnityEditor; using UnityEngine;

namespace Active.Howl{
public class PostProcessor : AssetPostprocessor {

    public static bool verbose = true;

    void OnPreprocessAsset(){ // sss
        var π = assetPath;
        if(!π.EndsWith(".howl"))  return;
        bool export = Config.allowExport && !Howl.importing;
        if(export){
            Log( $"Export {π.FileName()}");
            Howl.NitPick(π);
            Howl.ExportFile(π);
        }else{
            Warn($"Do not export {π.FileName()} - "
               + $"allowExport: {Config.allowExport}, "
               + $"importing: {Howl.importing}");
        }
    }

    void Log(string x) { if(verbose) Debug.Log(x);        }
    void Warn(string x){ if(verbose) Debug.LogWarning(x); }

}}
