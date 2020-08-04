using System.Linq;

namespace Active.Howl{
public static class WhiteSpaceAdder{

    static int index;
    static string ㅂ;

    public static string Consolidate(this string ㅂ, char[] S){
        index = 0;
        WhiteSpaceAdder.ㅂ = ㅂ;
        return (from c in ㅂ select Consolidate(c, S))
               .ToArray().Join();
    }

    static string Consolidate(char c, char[] S){
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
