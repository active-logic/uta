using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEditor; using UnityEngine;

namespace Active.Howl{
class PostProcessor : AssetPostprocessor{

    void OnPreprocessAsset(){
        if(!Config.allowExport || Howl.importing) return;
        var π = assetPath;
        if(!π.EndsWith(".howl")) return;
        Howl.NitPick(π);
        if(IsHowlProject(π)){
          // TODO - enable with verbosity
          // Debug
          // .Log($"(,•֊•„) cannot override Howl project source {π}");
        }else{
            Howl.ExportFile(π);
        }
    }

    ㅇ IsHowlProject(ㄹ π) => π.Contains("Howl.Howl/");

}}
