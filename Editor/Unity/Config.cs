using System.IO; using System.Text;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine;

namespace Active.Howl{
public class Config{

    const ㄹ Path = "Howl.cfg";

    public static ㅇ allowImport
    { get => Get("i"); set => Set("i", value); }

    public static ㅇ allowExport
    { get => Get("e"); set => Set("e", value); }

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
        Write(mutable.ToString());
    }

    static ㄹ Read(){
        try{
            return File.ReadAllText(Path);
        }catch(FileNotFoundException){
            return "i0e0";
        }
    }

    static void Write(ㄹ str) => File.WriteAllText(Path, str);

}}
