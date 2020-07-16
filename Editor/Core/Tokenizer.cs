using System; using System.Collections.Generic;
using System.Text;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public static class Tokenizer{

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
