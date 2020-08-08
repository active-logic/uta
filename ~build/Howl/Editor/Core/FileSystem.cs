using System; using System.IO; using Ex = System.Exception;
using System.Collections.Generic; using System.Linq;
using UnityEngine;

namespace Active.Howl{
public static class FileSystem{

    public static string FindInParent(string root, string pattern)
    => DoFindInParent(new DirectoryInfo(root), pattern);

    public static bool Match(string pattern, string root, bool files=true, bool dirs=false)
    => FindAny(new DirectoryInfo(root), pattern, files, dirs);

    public static List<string> Paths(string root, params string[] patterns){
        var ㄸ = new List<string>();
        foreach (var π in patterns) Traverse(new DirectoryInfo(root), π, ㄸ);
        return ㄸ;
    }

    public static string Path(string root, string pattern){
        var ㄸ = Paths(root, pattern);
        if(ㄸ.Count > 1) throw new Ex($"Only zero or one '{pattern}'");
        return ㄸ.Count == 0 ? null : ㄸ[0];
    }

    static void Traverse(DirectoryInfo dir, string pattern, List<string> ㄸ){
        //↯{
            ㄸ.AddRange(from f in dir.GetFiles(pattern)
                        select f.FullName.Nix());
        //}
        //⇤ (UnauthorizedAccessException e){ 🔸(e.Message); }
        //⇤ (DirectoryNotFoundException  e){ 🔸(e.Message); }
        foreach (var x in dir.GetDirectories())
            Traverse(x, pattern, ㄸ);
    }

    static string DoFindInParent(DirectoryInfo dir, string pattern){
        try {
            var files = dir.GetFiles(pattern);
            var dirs = dir.GetDirectories(pattern);
            if(files.Length > 0) return files [0].ToString();
            if(dirs.Length  > 0) return dirs  [0].ToString();
        }
        catch (UnauthorizedAccessException) {}
        catch (DirectoryNotFoundException)  {}
        var π = dir.Parent; return π != null ? DoFindInParent(π, pattern) : null;
    }

    static bool FindAny(DirectoryInfo dir, string pattern, bool files=true, bool dirs=false){
        if( files && dir.GetFiles       (pattern).Length > 0 ) return true;
        else if( dirs  && dir.GetDirectories (pattern).Length > 0 ) return true;
        foreach (var x in dir.GetDirectories()){
            if (FindAny(x, pattern, files, dirs)) return true;
        }
        return false;
    }

    //∘ ┈ Warn(ㄹ x) → Debug.LgWarning(x);

}}
