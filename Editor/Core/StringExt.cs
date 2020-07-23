using System;    using System.Collections.Generic;
using System.IO; using System.Linq;
using System.Text; using System.Text.RegularExpressions;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public static class StringExt{

    static Regex Az09 = new Regex("^[a-zA-Z0-9]*$");

    public static DirectoryInfo MkDir(this ㄹ path)
    => Directory.CreateDirectory(path);

    public static string Ftu(this ㄹ x)
    => x.First().ToString().ToUpper() + x.Substring(1);

    public static ㅇ IsAlphaNumeric(this ㄹ x) => Az09.IsMatch(x);

    public static ᆞ LineCount(this ㄹ x){
        ᆞ n = 0;
        for(ᆞ i = 0; i < x.Length; i++) if(x[i] == '\n') n++;
        return n;
    }

    public static ㄹ Insert(this ㄹ dst, ㄹ src, ㄹ lm, ㄹ rm){
        var l = dst.IndexOf(lm);
        var r = dst.IndexOf(rm);
        if(l < 0){ Warn($"{lm} marker needed"); return null; }
        if(r < 0){ Warn($"{rm} marker needed"); return null; }
        l = dst.IndexOf('\n', l);
        r = dst.LastIndexOf('\n', r);
        if(l < 0){ Warn($"No new line after marker"); return null; }
        if(r < 0){ Warn($"No new line before marker"); return null; }
        var header = dst.Substring(0, l + 1);
        var footer = dst.Substring(r);
        return header + src + footer;
    }

    public static ㄹ[] Lines(this ㄹ self){
        if(self == null) return null;
        if(self.Length == 0) return new ㄹ[]{};
        var ㄸ = new List<ㄹ>();
        var x = new StringBuilder();
        for(ᆞ i = 0; i < self.Length; i++){
            var c = self[i];
            x.Append(c);
            if(c == '\n'){
                ㄸ.Add(x.ToString());
                x.Clear();
            }
        }
        if(x.Length > 0) ㄸ.Add(x.ToString());
        return ㄸ.ToArray();
    }

    public static ㄹ Read(this ㄹ path) => File.ReadAllText(path);

    public static void Del(this ㄹ path) => File.Delete(path);

    public static void Write(this ㄹ path, ㄹ text)
    => File.WriteAllText(path, text);

    public static ㄹ[] ReadLines(this ㄹ path)
    => File.ReadLines(path).ToArray();

    public static ㄹ Reverse(this ㄹ x){
        if(x.Length <= 1) return x;
        char[] ㄸ = x.ToCharArray();
        Array.Reverse(ㄸ);
        return new ㄹ(ㄸ);
    }

    public static ㄹ[] Tokenize(this ㄹ self){
        List<ㄹ> ㄸ = new List<ㄹ>();
        var buffer = new StringBuilder();
        foreach(char c in self){
            if(Char.IsLetterOrDigit(c) || c == '_'){
                buffer.Append(c);
            }else{
                if(buffer.Length>0){
                    ㄸ.Add(buffer.ToString());
                    buffer.Clear();
                }
                ㄸ.Add($"{c}");
            }
        }
        if(buffer.Length>0) ㄸ.Add(buffer.ToString());
        return ㄸ.ToArray();
    }

    static ㅇ Warn(ㄹ msg)
    { UnityEngine.Debug.LogWarning(msg); return false; }

}}
