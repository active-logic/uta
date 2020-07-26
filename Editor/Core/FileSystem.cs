using System; using System.IO;
using System.Collections.Generic; using System.Linq;
using UnityEngine;

namespace Active.Howl{
public static class FileSystem{

    public static List<string> Paths(string root, string pattern){
        var ㄸ = new List<string>();
        Traverse(new DirectoryInfo(root), pattern, ㄸ);
        return ㄸ;
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

    static void Warn(string x) => Debug.LogWarning(x);

}}
