using System.Linq; using System.Text;

namespace Active.Howl{
public static class WhiteSpaceAdder{

    static int index;
    static string ㅂ;

    public static string Consolidate(this string ㅂ, char[] S){
        index = 0;
        WhiteSpaceAdder.ㅂ = ㅂ;
        return (from c in ㅂ select Consolidate(c, S)).ToArray().Join();
    }

    public static string Consolidate(this string x, string[] S){
        var @out = new StringBuilder();
        for(int i = 0; i < x.Length; i++){
            bool didMatch = false;
            foreach(var s in S){
                var n = s.Length;
                if(x.Matches(s, at: i)){
                    @out.Append(s);
                    if(i + n < x.Length
                                && !IsBreakingChar(x[i + n])){
                        @out.Append(' ');
                    }
                    didMatch = true;
                    i += n - 1;  // -1 because iteration adds 1
                    break;
                }
            }
            if(!didMatch) @out.Append(x[i]);
        }
        return @out.ToString();
    }

    // TODO probably also win line endings
    static bool IsBreakingChar(char c){
        return " \n/()\"':,.;<>~!@#$%^&*|+=[]{}`?-…".Contains(c);
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
