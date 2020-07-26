using UnityEngine;
using System; using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Active.Howl{
public class ImportConfig{

    const string path = "Howl-Symbols.bin";
    static BinaryFormatter φ = new BinaryFormatter();
    static int frame = 0;

    public static void Read(){
        var f = Time.frameCount; if(f == frame) return;
        try{
            frame = f;
            var rules = Read(path);
            Map.@default.Rebuild(rules);
        }catch(System.IO.FileNotFoundException){}
    }

    public static void Write()
    => Write(Map.@default.declarative, path);

    public static void Clear() => File.Delete(path);

    // --------------------------------------------------------------

    static Rep[] Read(string path){
        var s = new FileStream(path, FileMode.Open,
                                     FileAccess.Read);
        var map = (Rep[])φ.Deserialize(s);
        s.Close();
        return map;
    }

    static void Write(Rep[] rules, string path){
        var formatter = new BinaryFormatter();
        var s = new FileStream(path, FileMode.Create,
                                     FileAccess.Write);
        φ.Serialize(s, rules);
        s.Close();
    }

}}
