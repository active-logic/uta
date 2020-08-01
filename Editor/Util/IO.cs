using System.IO; using System.Linq; using Dir = System.IO.Directory;
using SysPath = System.IO.Path;
using System.Runtime.Serialization.Formatters.Binary;

namespace Active.Howl{

public static class IO{

    public static void Del(this string path) => File.Delete(path);

    public static bool Exists(this string x) => File.Exists(x);

    public static void Delete(this string x) => File.Delete(x);

    public static string FileName(this string π) => SysPath.GetFileName(π);

    public static string DirName(this string π) => SysPath.GetDirectoryName(π).Nix();

    public static bool IsDir(this string x) => Directory.Exists(x);

    public static DirectoryInfo MkDir (this string path) => Dir.CreateDirectory(path);

    public static string Read(this string path) => File.ReadAllText(path);

    public static string[] ReadLines(this string path) => File.ReadLines(path).ToArray();

    public static  T ReadObject<T>(this string path){
        var φ = new BinaryFormatter();
        var s    = new FileStream(path,  FileMode.Open, FileAccess.Read);
        var @out = φ.Deserialize(s);
        s.Close();
        return (T)@out;
    }

    public static  T ReadObject<T>(this string path, T @default)
    => path.Exists() ? path.ReadObject<T>() : @default;

    public static void Write(this string path, string text, bool mkdir=false, bool importAsset=false){
        if (mkdir) Directory.GetParent(path).Create();
        File.WriteAllText(path, text);
        if (importAsset) UnityEditor.AssetDatabase.ImportAsset(path);
    }

    public static  void WriteObject(this string path, object @out){
        var φ = new BinaryFormatter();
        var s = new FileStream(path, FileMode.Create, FileAccess.Write);
        φ.Serialize(s, @out);
        s.Close();
    }

}}
