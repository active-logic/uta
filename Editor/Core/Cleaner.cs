using System.IO; using System.Linq; using System.Text;
using UnityEngine;
using Active.Howl;

namespace Active.Howl.Transitional{
public class Cleaner{

    static string[] syms = new string[]{"float", "bool", "int", "string"};
    static string[,] map = new string[4, 2]{
        {"float", "float"},
        {"bool", "bool"},
        {"int", "int"},
        {"string", "string"}
    };

    public static void Clean(){
        UnityEngine.Debug.Log("Clean C# src");
        foreach(var p in FileSystem.Paths("Assets/", "*.cs")){
            var x = p.Read();
            var y = CleanAliases(p);
            y = CleanUses(y) + "\n";
            if(x != y){
                Debug.LogWarning($"Dirty: {p}");
            }
            //Debug.Log($"@ {p}\n{x}");
            //p.Write(y);
        }
    }

    static string CleanUses(string ㅂ){
        var ㄸ = new StringBuilder();
        foreach(var θ in ㅂ.Break(Map.defs))
            ㄸ.Append(θ.DenotesBlock(Map.defs) ? θ : CleanChunk(θ));
        return ㄸ.ToString();
    }

    static string CleanChunk(string ㅂ){
        for(int i = 0; i < 4; i++){
            ㅂ = ㅂ.Replace(map[i, 0], map[i, 1]);
        }
        return ㅂ;
    }

    static string CleanAliases(string file)
    => (from λ in file.Readlines() where !IsLegacyAlias(λ) select λ).ToArray().Join('\n');

    static bool IsLegacyAlias(string λ){
        if(!λ.Contains("using")) return false;
        if(!λ.Contains("=")) return false;
        foreach(var s in syms) if(λ.Contains(s)) return true;
        return false;
    }

}}
