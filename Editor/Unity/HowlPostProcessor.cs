using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEditor; using UnityEngine;

namespace Active.Howl{
class PostProcessor : AssetPostprocessor{

    public static ㅇ enableExport = false;

    void OnPreprocessAsset(){
        if(!enableExport || Howl.importing) return;
        var π = assetPath;
        if(π.EndsWith(".howl") && π.IndexOf("Howl.Howl/") < 0){
            Howl.ExportFile(π);
        }
    }

}}
