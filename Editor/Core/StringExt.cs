using System; using System.Collections.Generic;
using System.Text;
using System.Linq;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public static class StringExt{

    public static ㅇ DenotesCStyleComment(this ㄹ x)
    => x.StartsWith("/*");

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

    public static ㅇ StartsWith(this ㄹ x, ㄹ y, ㅇ trim)
    => (x = trim ? x.Trim() : x).StartsWith(y);

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
