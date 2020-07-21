using System; using System.Linq; using System.Text;
using System.Collections.Generic;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public class SnippetGen{

    // Mechanically generate .cson snippets
    public static void Generate(ㄹ ㄸ){
        var S = new HashSet<ㄹ>();
        (from ρ in Map.@default.declarative
         where !ρ.noSnippet && Unique(ρ, S)
         select GenSnippet(ρ)).ToArray().Write(ㄸ);
   }

    // C# snippets (.cson) => Howl snippets
    public static void Export(ㄹ ㅂ, ㄹ ㄸ)
    => (from λ in ㅂ.ReadLines() select Export(λ))
       .ToArray().Write(ㄸ);

    // --------------------------------------------------------------

    public static bool Unique(Rep x, HashSet<string> S){
        var n = Name(x); if(S.Contains(n)){
            Warn($"Drop duplicate snippet ――――――――――――――― {x}");
            return false;
        }  S.Add(n); return true;
    }

    static ㄹ GenSnippet(Rep ρ) =>
        $"  '{Name(ρ)}':\n"
      + $"    'prefix': '{Prefix(ρ)}'\n"
      + $"    'body': '{Body(ρ)}'";

    static ㄹ Export(ㄹ ㅂ)
    => ㅂ.Contains("'body'") ? ㅂ / Map.@default : ㅂ;

    // --------------------------------------------------------------

    static ㄹ Name(Rep ρ) => ρ.name;

    static ㄹ Prefix(Rep ρ){
        return ToPrefix(ρ.b);
    }

    static ㄹ Body(Rep ρ) => ρ.a + ' ';

    // --------------------------------------------------------------

    public static ㄹ ToPrefix(ㄹ x){
        var buf = new StringBuilder(); ᆞ S = 0; foreach(char c in x){
            if(Char.IsLetterOrDigit(c)){
                if(S == 0) S = 1; buf.Append(c); if(S == 2) break;
            }else if(S == 1) S = 2;
        } return buf.ToString();
    }

    static ㅇ Warn(ㄹ msg)
    { UnityEngine.Debug.LogWarning(msg); return false; }

}}
