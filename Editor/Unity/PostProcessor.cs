using UnityEditor; using UnityEngine;

namespace Active.Howl{
public class PostProcessor : AssetPostprocessor{

    static int nextId = 0;
    static int φ;
    public static bool verbose = true, warn = true;
    //
    int id;

    public  PostProcessor() => id = nextId++;

    void OnPreprocessAsset(){
        φ = Time.frameCount;
        var π = assetPath;
        if (π.IsCSharpSource()){
            CheckEdit(π); return ;
        } else if (π.IsPackaged() || !π.EndsWith(".howl")) return;
        //
        bool export = Config.ι.allowExport && !Howl.importing;
        if (export){
            Log($"Export {π.FileName()} via #{id} (φ.{φ})" );
            Howl.NitPick(π);
            Howl.ExportFile(π);
            AssetDatabase.ImportAsset(π);
        }
        else if (!Config.ι.allowExport )
            Warn( $"Cannot convert {π}\n"
                 + "Please enable export in the Howl Window");
        else
            Warn( $"Cannot convert {π}\n"
                 + "while Unity is importing assets");
    }

    void CheckEdit(string ㄸ){
        var ㅂ = ㄸ.InPath();
        if (!ㅂ.Exists()){
            if (ㅂ.DirName().IsDir())
                Err("(°ㅂ°╬) ↯ creating C# scripts on the Howl path is unsafe");
            else
                Log("Edited C# file without counterpart: {π}");
            return ;
        } else if (ㄸ.DateModified() > ㅂ.DateModified()){
            Err( $"(‡▼益▼) ↯ changes to {ㄸ.FileName()} will be "
                + "overwritten when you @%#!~ the *.howl source");
        } else if (ㄸ.DateModified() < ㅂ.DateModified()){
            var δ = ㅂ.DateModified() - ㅂ.DateModified();
            Warn($"Reimporting {ㄸ.FileName()}, which is older than its *.howl counterpart");
        }
    }

    void Log(string x) { if (verbose) Debug.Log(x); }

    void Warn(string x){ if (warn) Debug.LogWarning(x); }

    void Err(string x){ Debug.LogError(x); }

}}
