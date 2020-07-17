using System.Linq;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public static class WhiteSpaceAdder{

    static ᆞ index;
    static ㄹ ㅂ;

    public static ㄹ Consolidate(this ㄹ ㅂ, char[] S){
        index = 0;
        WhiteSpaceAdder.ㅂ = ㅂ;
        return (from c in ㅂ select Consolidate(c, S))
               .ToArray().Join();
    }

    static ㄹ Consolidate(char c, char[] S){
        index++;
        var ㄸ = $"{c}";
        if(index == ㅂ.Length) return ㄸ;
        var next = ㅂ[index];
        // Check if 'c' is a soft symbol; if not, just return it.
        if(!S.Contains(c)) return ㄸ;
        // Letter/char after soft symbol needs space; likewise
        // when soft symbols follow in sequence
        if(char.IsLetterOrDigit(next)
                  || S.Contains(next)) return ㄸ + ' ';
        // Non word char after soft symbol needs no extra space
        return ㄸ;
    }

}}
