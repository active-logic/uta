using System; using System.IO; using System.Collections.Generic;
using UnityEngine;  // for frame count

namespace Active.Howl{
public class ImportConfig{

    const string path = "Howl-Sel.bin";
    static int frame = 0;

    public static void Read(){
        if (!path.Exists()) return ;
        // TODO looks like would always return false
        var f = Time.frameCount; if(f != frame) return;
        frame = f;
         SetSelState(Map.@default, path.ReadObject<Dictionary<string,bool>>());
    }

    public static void Write() => path.WriteObject(GetSelState(Map.@default));

    public static void Clear() => File.Delete(path);

    static Dictionary<string,bool> GetSelState(Map map){
        var @out = new Dictionary<string,bool>();
        foreach (var x in map.rules) @out[x.name] = x.@sel;
        return @out;
    }

    static void SetSelState(Map map, Dictionary<string,bool> S){
        bool z;
        foreach (var x in map.rules)
            if (S.TryGetValue(x.name, out z)) x.@sel = z;
    }

}}
