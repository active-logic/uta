using UnityEditor; using UnityEngine;

namespace Active.Howl{
public class PostProcessor : AssetPostprocessor {

    public static bool verbose = true;  static int frame;

    void OnPreprocessAsset(){
        AvailRoot();
        var π = assetPath;
        if (π.IsPackaged() || !π.EndsWith(".howl")) return;
        //
        bool export = Config.allowExport && !Howl.importing ;
        if (export){
            Log( $"Export {π.FileName()}");
            Howl.NitPick(π);
            Howl.ExportFile(π);
        } else {
            Warn($"Do not export {π.FileName()} - "
               + $"allowExport: {Config.allowExport}, "
               + $"importing: {Howl.importing}");
        }
    }

    void AvailRoot(){
        var φ = Time.frameCount;
        if (frame != φ) Path.AvailHowlRoot();
        frame = φ;
    }

    void Log(string x) { if (verbose) Debug.Log(x);        }

    void Warn(string x){ if (verbose) Debug.LogWarning(x); }

}}
