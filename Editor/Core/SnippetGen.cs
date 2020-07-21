using System.Linq;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public class SnippetGen{

    public static void Generate(ㄹ ㅂ, ㄹ ㄸ)
    => (from λ in ㅂ.ReadLines() select Π(λ)).ToArray().Write(ㄸ);

    public static ㄹ Π(ㄹ ㅂ)
    => ㅂ.Contains("'body'") ? ㅂ / Map.@default : ㅂ;

}}
