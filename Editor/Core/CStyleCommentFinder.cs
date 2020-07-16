using System.Collections.Generic;
using System.Text;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public static class CStyleCommentFinder{

    public static ㄹ[] AroundCStyleComments(this ㄹ x){
        var ㄸ = new List<ㄹ>();
        var buffer = new StringBuilder();
        var inComment = false;
        for(ᆞ i = 0; i < x.Length; i++){
            if(!inComment && StartsComment(x, i)){
                Flush(buffer, ㄸ);
                inComment = true;
                buffer.Append(x[i]);
            }else if(inComment && EndsComment(x, i)){
                buffer.Append(x[i]);
                Flush(buffer, ㄸ);
                inComment = false;
            }else{
                buffer.Append(x[i]);
            }
        }
        Flush(buffer, ㄸ);
        return ㄸ.ToArray();
    }

    public static ㅇ StartsComment(ㄹ x, ᆞ i){
        if(x[i++] != '/') return false;
        if(i >= x.Length) return false;
        return x[i] == '*';
    }

    public static ㅇ EndsComment(ㄹ x, ᆞ i){
        if(x[i--] != '/') return false;
        if(i < 0) return false;
        return x[i] == '*';
    }

    public static void Flush(StringBuilder buf, List<ㄹ> ㄸ){
        if(buf.Length == 0) return;
        ㄸ.Add(buf.ToString());
        buf.Clear();
    }

}
}
