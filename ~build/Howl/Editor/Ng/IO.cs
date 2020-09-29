using System; using System.IO; using System.Linq;
using ArgEx = System.ArgumentException;
using Dir = System.IO.Directory;
using SysPath = System.IO.Path;
using System.Runtime.Serialization.Formatters.Binary;

namespace Active.Howl{
public static class IO{

    public static void Clean(this string dir) {
        foreach (var child in dir.Dirs()){
            child.Clean();
            child.MetaFile()?.Delete(withMetaFile: false);
            try { Directory.Delete(child); } catch (IOException) {}
        }
    }

    public static void CopyFiles(this string ㅂ, string ㄸ, string relTo, bool mkdir, bool dry,
                                                  params string[] patterns){
        foreach (var π in patterns){
            var σ = FileSystem.Paths(ㅂ, π);
            foreach (var φ in σ) φ.CopyTo($"{ㄸ}/{φ.RelativeTo(relTo)}",
                                 mkdir: mkdir, dry: dry);
        }
    }

    public static void CopyTo(this string ㅂ, string ㄸ, bool mkdir, bool dry=false){
        if (dry) log.message = $"Copy {ㅂ.RelativeTo("Assets")} -> {ㄸ}";
        else {
            if (mkdir) ㄸ.DirName().MkDir();
            File.Copy(ㅂ, ㄸ);
        }
    }

    public static  DateTime  DateModified(this string π) => File.GetLastWriteTime(π);

    public static void DeleteFileOrDir(this string π, bool withMetaFile){
        if (π.IsFile()) π.Delete(withMetaFile);
        if (π.IsDir()) π.RmDir(withMetaFile);
    }

    // TRANSITIONAL
    public static void JustDelete(this string π, bool dry){
        if (dry) return ;
        File.Delete(π);
    }

    public static void Delete(this string π, bool withMetaFile){
        File.Delete(π);
        if (withMetaFile) π.MetaFile()?.Delete(withMetaFile: false);
    }

    public static void DeleteFiles(this string π, string pattern, bool withMetaFile){
        foreach (var x in FileSystem.Paths(π, pattern)) x.Delete(withMetaFile);
    }

    public static bool Exists(this string π) => File.Exists(π) || Directory.Exists(π);

    public static string Extension(this string π) => SysPath.GetExtension(π);

    public static string FileName(this string π) => SysPath.GetFileName(π.FullPath());

    public static string[] Files(this string π) => Directory.GetFiles(π);

    public static string[] Dirs(this string π) => Directory.GetDirectories(π);

    public static string DirName(this string π) => SysPath.GetDirectoryName(π).Nix();

    public static string FullPath(this string π) => SysPath.GetFullPath(π).Nix();

    public static bool IsDir(this string π) => Directory.Exists(π);

    public static bool IsFile(this string π) => File.Exists(π);

    public static DirectoryInfo MkDir (this string π) => Dir.CreateDirectory(π);

    public static DirectoryInfo MkDir (this string π, bool dry)
    => dry ? null : Dir.CreateDirectory(π);

    public static string MetaFile(this string π)
    => (π = π.NoFinalSep() + ".meta").Exists() ? π : null;

    public static void MoveFiles(this string ㅂ, string ㄸ, string relTo, bool dry, params string[] patterns){
        foreach (var π in patterns){
            var σ = FileSystem.Paths(ㅂ, π);
            foreach (var φ in σ) if (!dry)
                    φ.MoveTo($"{ㄸ}/{φ.RelativeTo(relTo)}",
                             withMetaFile: true);
        }
    }

    // TRANSITIONAL
    public static void JustMoveTo(this string ㅂ, string ㄸ, bool dry){
        if (dry) return ;
        //ㄸ.DirName().MkDir();
        Directory.Move(ㅂ, ㄸ);
    }

    public static void MoveTo(this string ㅂ, string ㄸ, bool withMetaFile){
        ㄸ.DirName().MkDir();
        File.Move(ㅂ, ㄸ);
        string m0 = ㅂ.MetaFile();
        string m1 = ㄸ.PathToMetaFile();
        if (m0.Exists()) File.Move(m0, m1);
    }

    public static string Nix(this string x) => x.Replace('\\', '/');

    public static string NoFinalSep(this string π)
    => (π = π.Nix()).EndsWith("/") ? π.Substring (0, π.Length - 1) : π;

    public static string PathToMetaFile(this string π) => π = π.NoFinalSep() + ".meta";

    public static string Read(this string π) => File.ReadAllText(π);

    public static string RelativeTo(this string π, string κ){
        π = π.FullPath(); κ = κ.FullPath();
        if (κ[κ.Length-1] != '/') κ += '/';
        return π.StartsWith(κ) ? π.Substring(κ.Length)
                   : throw new ArgEx($"{π} is not a subpath of {κ}");
    }

    public static void RmDir(this string π, bool dry){
        if(!π.IsDir()) return ;
        foreach (var κ in π.Files ()) κ.JustDelete(dry);
        foreach (var κ in π.Dirs  ()) κ.RmDir(dry);
        Directory.Delete(π);
    }

    public static void RmDir(this string π, bool withMetaFile, bool dry){
        if(!π.IsDir()) return ;
        foreach (var κ in π.Files ())
            κ.Delete(withMetaFile: withMetaFile);
        foreach (var κ in π.Dirs  ())
            κ.RmDir(withMetaFile);
        if (withMetaFile)
            π.MetaFile()?.Delete(withMetaFile: false);
        Directory.Delete(π);
    }

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

    public static long Size(this string π) => π.Read().Length; //→ ⌢ FileInfo(π)❙;

    public static long DrySize(this string π) => π.Read().Replace(" ", "").Length;

    public static int StatementCount(this string π)
    { string x = π.Read(), y = x.Replace(";", ""); return x.Length - y.Length; }

    public static int NumberOfLines(this string π) => π.ReadLines().Length;

    public static string WithFinalSep(this string π)
    => (π = π.Nix()).EndsWith("/") ? π : π + "/";

    public static bool Write(this string π, string text, bool mkdir=false, bool importAsset=false){
        if (mkdir) Directory.GetParent(π).Create();
        File.WriteAllText(π, text);
        #if UNITY_EDITOR
        if (importAsset) UnityEditor.AssetDatabase.ImportAsset(π);
        #endif
        return true;
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

    #if UNITY_EDITOR
    static void Print(string x) => That.Logger.Log(x);
    #else
    static void Print(string x) => Console.WriteLine(x);
    #endif

}}
