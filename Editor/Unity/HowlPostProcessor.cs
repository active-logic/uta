using UnityEditor; using UnityEngine;

namespace Active.Howl{
class PostProcessor : AssetPostprocessor{

    void OnPreprocessAsset(){
        var π = assetPath;
        if(π.EndsWith(".howl") && π.IndexOf("Howl.Howl/") < 0){
            Howl.ExportFile(π);
        }
    }

}}
