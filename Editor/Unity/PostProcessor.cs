using UnityEditor; using UnityEngine;

namespace Active.Howl{
public class PostProcessor : AssetPostprocessor{

    static int frame;  public static bool verbose = true, warn = true;

    void OnPreprocessAsset(){
        var π = assetPath;
        if (π.IsPackaged() || !π.EndsWith(".howl")) return;
        //
        bool export = Config.ι.allowExport && !Howl.importing ;
        if (export){
            Log($"Export {π.FileName()}");
            Howl.NitPick(π);
            Howl.ExportFile(π);
        }
        else if (!Config.ι.allowExport )
            Warn($"Cannot convert {π}\nPlease enable export in the Howl Window");
        else
            Warn($"Cannot convert {π} while Unity is importing assets");
    }

    void Log(string x) { if (verbose) Debug.Log(x); }

    void Warn(string x){ if (warn) Debug.LogWarning(x); }

}}
