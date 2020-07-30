using UnityEngine;
using System; using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Active.Howl{
public class ImportConfig{

    const string path = "Howl-Sel.bin";
    static BinaryFormatter φ = new BinaryFormatter();
    static int frame = 0;

    public static void Read(){
        var f = Time.frameCount; if(f != frame) return;
        try {
            frame = f;
            SetSelState(Map.@default, ReadSelState(path));
        } catch (System.IO.FileNotFoundException){}
    }

    public static void Write() => WriteSelState(GetSelState(Map.@default), path);

    public static void Clear() => File.Delete(path);

    // --------------------------------------------------------------

    static Dictionary<string,bool> GetSelState(Map map){
        Dictionary<string,bool> @out = new Dictionary<string,bool>();
        foreach (var x in map.rules) @out[x.name] = x.@sel;
        return @out;
    }

    static void SetSelState(Map map, Dictionary<string,bool> S){
        bool z; foreach (var x in map.rules)
                if (S.TryGetValue(x.name, out z)) x.@sel = z;
    }

    static Dictionary<string,bool> ReadSelState(string path){
        var s    = new FileStream(path, FileMode.Open, FileAccess.Read);
        var @out = (Dictionary<string,bool>)φ.Deserialize(s);
        s.Close();
        return @out;
    }

    static void WriteSelState(Dictionary<string,bool> @in, string path){
        var formatter = new BinaryFormatter();
        var s = new FileStream(path, FileMode.Create, FileAccess.Write);
        φ.Serialize(s, @in);
        s.Close();
    }

}}
