using System.IO; using System;

namespace Active.Howl {
public static class StringArray {

    public static string Join(this string[] x) => string.Join("", x);

    public static string Join(this string[] x, char c = '\n')
    => string.Join(c.ToString(), x);

    public static string Join(this string[] x, string s)
    => string.Join(s, x);

    public static string[] Replace(this string[] x, string[] lh, string[] lr){
        for (int i = 0; i < x.Length; i++){
            if (x.Matches(lh, i)){
                ReplaceRange(ref x, i, lh.Length, lr);
                i += lr.Length;
            }
        } return x;
    }

    public static bool Matches(this string[] x, string[] y, int n){
        if    (n + y.Length > x.Length) return false;
        else for (int i = 0; i < y.Length; i++) if (x[n + i] != y[i]) return false;
        return true;
    }

    public static void ReplaceRange(ref string[] x, int i, int len, string[] y){
        Array.Copy(x, i + len, x, i, x.Length - (i + len));
        Array.Resize(ref x, x.Length - len + y.Length);
        Array.Copy(x, i, x, i + y.Length, x.Length - (i + y.Length));
        Array.Copy(y, 0, x, i, y.Length);
    }

    public static void RemoveRange(ref string[] x, int i, int len){
        Array.Copy(x, i + len, x, i, x.Length - (i + len));
        Array.Resize(ref x, x.Length - len);
        That.Logger.Log("Length of array now " + x.Length);
    }

    // TODO should be an IO, not string ext function.
    public static void Write(this string[] ㅂ, string path, char sep = '\n')
    => File.WriteAllText(path, ㅂ.Join(sep)
                               + (sep == '\n' ? "\n" : null));

    public static string ToString(this string[] Λ) => Λ.Join(", ");

}}
