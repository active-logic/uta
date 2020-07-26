using System.IO; using System.Linq; using System.Text;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine;
//
using Active.Howl;

namespace Active.Howl.Transitional{
public class Cleaner{

    static ㄹ[] syms = new ㄹ[]{"ㅅ", "ㅇ", "ᆞ", "ㄹ"};
    static ㄹ[,] map = new ㄹ[4, 2]{
        {"ㅅ", "float"},
        {"ㅇ", "bool"},
        {"ᆞ", "int"},
        {"ㄹ", "string"}
    };

    public static void Clean(){
        foreach(var p in FileSystem.Paths("Assets/", "*.cs")){
            var x = CleanAliases(p);
            x = CleanUses(x);
            Debug.Log($"@ {p}\n{x}");
            //p.Write(x);
        }
    }

    static ㄹ CleanUses(ㄹ ㅂ){
        var ㄸ = new StringBuilder();
        foreach(var θ in ㅂ.Break(Map.defs))
            ㄸ.Append(θ.DenotesBlock(Map.defs) ? θ : CleanChunk(θ));
        return ㄸ.ToString();
    }

    static ㄹ CleanChunk(ㄹ ㅂ){
        for(ᆞ i = 0; i < 4; i++){
            ㅂ = ㅂ.Replace(map[i, 0], map[i, 1]);
        }
        return ㅂ;
    }

    static ㄹ CleanAliases(ㄹ file){
        var lines = File.ReadLines(file);
        return (from λ in lines where !IsLegacyAlias(λ)
                select λ).ToArray().Join('\n');
    }

    static ㅇ IsLegacyAlias(ㄹ λ){
        if(!λ.Contains("using")) return false;
        if(!λ.Contains("=")) return false;
        foreach(var s in syms) if(λ.Contains(s)) return true;
        return false;
    }

}}
