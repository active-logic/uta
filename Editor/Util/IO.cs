using System;
using System.IO; using System.Linq; using Dir = System.IO.Directory;
using SysPath = System.IO.Path;
using System.Runtime.Serialization.Formatters.Binary;

namespace Active.Howl{

public static class IO{

    public static  DateTime DateModified(this string π) => File.GetLastWriteTime(π);

    public static void Delete(this string π) => File.Delete(π);

    public static void RmDir(this string π){
        if(!π.IsDir()) return ;
        foreach (var κ in π.Files ()) κ.Delete();
        foreach (var κ in π.Dirs  ()) κ.RmDir();
        string μ = $"{π}.meta";  if (μ.Exists()) μ.Delete();
        Directory.Delete(π);
    }

    // TODO add test
    public static bool Exists(this string π) => File.Exists(π) || Directory.Exists(π);

    public static string FileName(this string π) => SysPath.GetFileName(π);

    public static string[] Files(this string π) => Directory.GetFiles(π);

    public static string[] Dirs(this string π) => Directory.GetDirectories(π);

    public static string DirName(this string π) => SysPath.GetDirectoryName(π).Nix();

    public static bool IsDir(this string π) => Directory.Exists(π);

    public static DirectoryInfo MkDir (this string π) => Dir.CreateDirectory(π);

    public static string Read(this string π) => File.ReadAllText(π);

    public static string[] ReadLines(this string π) => File.ReadLines(π).ToArray();

    public static  T ReadObject<T>(this string π){
        var φ = new BinaryFormatter();
        var s    = new FileStream(π,  FileMode.Open, FileAccess.Read);
        var @out = φ.Deserialize(s);
        s.Close();
        return (T)@out;
    }

    public static  T ReadObject<T>(this string π, T @default)
    => π.Exists() ? π.ReadObject<T>() : @default;

    public static void Write(this string π, string text, bool mkdir=false, bool importAsset=false){
        if (mkdir) Directory.GetParent(π).Create();
        File.WriteAllText(π, text);
        if (importAsset) UnityEditor.AssetDatabase.ImportAsset(π);
    }

    public static void Write(this string π, string text, System.DateTime date){
        Directory.GetParent(π).Create();
        File.WriteAllText(π, text);
        File.SetLastWriteTime(π, date);
    }

    public static  void WriteObject(this string π, object @out){
        var φ = new BinaryFormatter();
        var s = new FileStream(π, FileMode.Create, FileAccess.Write);
        φ.Serialize(s, @out);
        s.Close();
    }

    static void Print(string x) => UnityEngine.Debug.Log(x);

}}
