using System.Linq;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public static class WhiteSpaceAdder{

    public static ㄹ Consolidate(this ㄹ ㅂ, char[] S)
    => (from c in ㅂ select Consolidate(c, S))
       .ToArray().Join();

    static ㄹ Consolidate(char c, char[] S)
    => $"{c}" + (S.Contains(c) ? " " : null);

}}
