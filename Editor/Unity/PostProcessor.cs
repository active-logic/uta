using UnityEditor; using UnityEngine;

namespace Active.Howl{
class PostProcessor : AssetPostprocessor{

    void OnPreprocessAsset(){
        if(!Config.allowExport || Howl.importing) return;
        var π = assetPath;
        if(!π.EndsWith(".howl")) return;
        Howl.NitPick(π);
        Howl.ExportFile(π);
    }

}}
