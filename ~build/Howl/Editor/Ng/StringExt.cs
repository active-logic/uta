using System;    using System.Collections.Generic;
using System.IO; using System.Linq;
using System.Text; using System.Text.RegularExpressions;

namespace Active.Howl{
public static class StringExt{

    static Regex Az09 = new Regex("^[a-zA-Z0-9]*$");

    public static string Comment(this string x) => $"// {x}\n";

    public static string Ftu(this string x) => x.First().ToString().ToUpper() + x.Substring(1);

    public static bool IsAlphaNumeric(this string x) => Az09.IsMatch(x);

    public static bool IsWhiteSpace(this string x) => x != null && string.IsNullOrWhiteSpace(x);

    public static int LineCount(this string x){
        int n = 0;
        for(int i = 0; i < x.Length; i++) if(x[i] == '\n') n++;
        return n;
    }

    public static string Insert(this string dst, string src, string lm, string rm){
        var l = dst.IndexOf(lm);
        var r = dst.IndexOf(rm);
        if(l < 0){ That.Logger.Warn($"{lm} marker needed"); return null;  }
        if(r < 0){ That.Logger.Warn($"{rm} marker needed"); return null; }
        l = dst.IndexOf('\n', l);
        r = dst.LastIndexOf('\n', r) ;
        if(l < 0){ That.Logger.Warn($"No new line after marker"); return null; }
        if(r < 0){ That.Logger.Warn($"No new line before marker"); return null; }
        var header = dst.Substring(0, l + 1);
        var footer = dst.Substring(r);
        return header + src + footer;
    }

    public static string Left(this string x, char c, bool trim = true){
        var z = x.IndexOf(c);
        return x.Substring(0, z).Trim();
    }

    public static string[] Lines(this string self){
        if(self == null) return null;
        if(self.Length == 0) return new string[]{};
        var ㄸ = new List<string>();
        var x = new StringBuilder();
        for(int i = 0; i < self.Length; i++){
            var c = self[i];
            x.Append(c);
            if(c == '\n'){
                ㄸ.Add(x.ToString());
                x.Clear();
            }
        }
        if(x.Length > 0) ㄸ.Add(x.ToString());
        return  ㄸ.ToArray();
    }

    public static bool Matches(this string x, string y, int at){
        var w = at + y.Length;
        if (w > x.Length) return false;
        var z = x.Substring(at, y.Length);
        return z == y;
    }

    public static string Reverse(this string x){
        if(x.Length <= 1) return x;
        char[] ㄸ = x.ToCharArray();
        Array.Reverse(ㄸ);
        return new string(ㄸ);
    }

    public static string Right(this string x, char c, bool trim = true){
        var z = x.IndexOf(c);
        return x.Substring(z + 1).Trim();
    }

    public static string[] Tokenize(this string self){
        List<string> ㄸ = new List<string>();
        var buffer = new StringBuilder();
        foreach(char c in self){
            if(Char.IsLetterOrDigit(c)
               || c == '_'
               || (buffer.Length == 0 && c == '@'))
            {
                buffer.Append(c);
            }else{
                if(buffer.Length > 0){
                    ㄸ.Add(buffer.ToString());
                    buffer.Clear();
                }
                ㄸ.Add($"{c}");
            }
        }
        if(buffer.Length>0) ㄸ.Add(buffer.ToString());
        return ㄸ.ToArray();
    }

}}
