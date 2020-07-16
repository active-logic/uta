using System; using System.IO;
using System.Collections.Generic; using System.Linq;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
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
                        select f.FullName);
        }
        catch (UnauthorizedAccessException e){ Warn(e.Message); }
        catch (DirectoryNotFoundException  e){ Warn(e.Message); }
        foreach (var x in dir.GetDirectories())
            Traverse(x, pattern, ㄸ);
    }

    static void Warn(string x) => Debug.LogWarning(x);

}}
