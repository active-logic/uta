using System; using System.Collections.Generic; using System.Linq;
using System.Text; using System.Text.RegularExpressions;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public static class StringExt{

    static Regex Az09 = new Regex("^[a-zA-Z0-9]*$");

    public static ㅇ IsAlphaNumeric(this ㄹ x) => Az09.IsMatch(x);

    public static ᆞ LineCount(this ㄹ x){
        ᆞ n = 0;
        for(ᆞ i = 0; i < x.Length; i++) if(x[i] == '\n') n++;
        return n;
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

}}
