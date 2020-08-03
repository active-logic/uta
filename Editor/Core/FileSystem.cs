using System; using System.IO; using Ex = System.Exception;
using System.Collections.Generic; using System.Linq;
using UnityEngine;

namespace Active.Howl{
public static class FileSystem{

    public static string FindInParent(string root, string pattern)
    => DoFindInParent(new DirectoryInfo(root), pattern);

    public static bool HasFileOfType(string root, string pattern)
    => FindAny(new DirectoryInfo(root), pattern);

    public static List<string> Paths(string root, string pattern){
        var ㄸ = new List<string>();
        Traverse(new DirectoryInfo(root), pattern, ㄸ);
        return ㄸ;
    }

    public static string Path(string root, string pattern){
        var ㄸ = Paths(root, pattern);
        if(ㄸ.Count > 1) throw new Ex($"Only zero or one '{pattern}'");
        return ㄸ.Count == 0 ? null : ㄸ[0];
    }

    static void Traverse(DirectoryInfo dir, string pattern, List<string> ㄸ){
        try{
            ㄸ.AddRange(from f in dir.GetFiles(pattern)
                        select f.FullName.Nix());
        }
        catch (UnauthorizedAccessException e){ Warn(e.Message); }
        catch (DirectoryNotFoundException  e){ Warn(e.Message); }
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

    static bool FindAny(DirectoryInfo dir, string pattern){
        try {
            if(dir.GetFiles(pattern).Length > 0) return true;
        }
        catch (UnauthorizedAccessException) {}
        catch (DirectoryNotFoundException)  {}
        foreach (var x in dir.GetDirectories())
            if(FindAny(x, pattern)) return true;
        return false;
    }

    static void Warn(string x) => Debug.LogWarning(x);

}}
