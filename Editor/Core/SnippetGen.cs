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
         where HasValidSnippet(ρ) && Unique(ρ, S)
         select GenSnippet(ρ)).ToArray().Write(ㄸ);
   }

    // C# snippets (.cson) => Howl snippets
    public static void Export(ㄹ ㅂ, ㄹ ㄸ)
    => (from λ in ㅂ.ReadLines() select Export(λ))
       .ToArray().Write(ㄸ);

    // --------------------------------------------------------------

    public static ㅇ HasValidSnippet(Rep ρ){
        if(ρ.noSnippet) return false;
        ㅇ hasPrefix = Prefix(ρ).Length > 0;
        if(!hasPrefix){
            Warn($"Empty prefix ――――――――――――――――――――――――― {ρ}");
            return false;
        }
        return true;
    }

    public static ㅇ Unique(Rep ρ, HashSet<ㄹ> S){
        var n = Name(ρ); if(S.Contains(n)){
            Warn($"Drop duplicate snippet ――――――――――――――― {ρ}");
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

    public static ㄹ Prefix(Rep ρ){
        ㄹ ㄸ = ToPrefix(ρ.b);
        return ㄸ.Length > 0 ? ㄸ
               : ρ.label != null ? LabelToPrefix(ρ.label) : "";
    }

    static ㄹ Body(Rep ρ) => ρ.a + ' ';

    // --------------------------------------------------------------

    static ㄹ LabelToPrefix(ㄹ label)
    => label != null ? ToPrefix(label).ToLower() : null;

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
