using System.IO; using System.Text;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine;

namespace Active.Howl{
public class Config{

    const ㄹ Template = "c0i0e0l0";
    const ㄹ Path = "Howl.cfg";
    public static ㄹ cache;
    public static ᆞ frame = 0;

    public static ㅇ ignoreConflicts
    {
      get => Get("c");
      set{
        Debug.Log($"Set ig to {value}");
        Debug.Log($"Previous config {Read()}");
        Set("c", value);
        Debug.Log($"New config{Read()}");
      }
    }

    public static ㅇ allowImport
    { get => Get("i"); set => Set("i", value); }

    public static ㅇ allowExport
    { get => Get("e"); set => Set("e", value); }

    public static ㅇ lockCsFiles
    { get => Get("l"); set => Set("l", value); }

    static ㅇ Get(ㄹ flag){
        ㄹ flags = Read();
        ᆞ i = flags.IndexOf(flag);
        return flags[i + 1] == '1';
    }

    static void Set(ㄹ flag, ㅇ value){
        ㄹ flags = Read();
        ᆞ i = flags.IndexOf(flag);
        var mutable = new StringBuilder(flags);
        mutable[i + 1] = value ? '1' : '0';
        Debug.Log($"Write config value [{mutable.ToString()}] ({mutable.ToString().Length})");
        Write(mutable.ToString());
    }

    static ㄹ Read(){
        try{
            if(Time.frameCount == frame && cache != null){
                Debug.Log("Get value from cache: "+cache);
                return cache;
            }
            cache = File.ReadAllText(Path);
            return cache.Length == Template.Length ? cache
                   : (cache = Template);
        }catch(FileNotFoundException){
            return Template;
        }
    }

    static void Write(ㄹ str) => File.WriteAllText(Path, cache = str);

}}
