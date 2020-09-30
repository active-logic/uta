using System; using System.Linq; using System.Text;
using System.Collections.Generic;

namespace Active.Howl{

// TODO APIs are unclear
public class SnippetGen{

    public static string Le = "(⊃｡•́‿•̀｡)⊃", Ri = "⊂(･ω･*⊂)";

    public static Snippet[] Create(){
        var S = new HashSet<string>();
        return (
            from ρ in Map.@default.declarative
            where (HasValidSnippet(ρ) && Unique(ρ, S))
            select (Snippet)(Name(ρ), Prefix(ρ), Body(ρ))
        ).ToArray();
    }

    // C# snippets (.cson) => Howl snippets
    public static void Export(string ㅂ, string ㄸ)
    => (from λ in ㅂ.ReadLines() select Export(λ)).ToArray().Write(ㄸ);

    // --------------------------------------------------------------

    public static bool HasValidSnippet(Rep ρ){
        if(ρ.noSnippet || !ρ.sel) return false;
        bool hasPrefix = Prefix(ρ).Length > 0;
        if(!hasPrefix){
            That.Logger.Err($"Empty prefix ――――――――――――――――― {ρ}");
            return false;
        }
        return true;
    }

    public static bool Unique(Rep ρ, HashSet<string> S){
        var n = Name(ρ); if(S.Contains(n)){
            That.Logger.Err($"Drop duplicate snippet ――――――― {ρ}");
            return false;
        }  S.Add(n); return true;
    }

    static string Export(string ㅂ)
    => ㅂ.Contains("'body'") ? ㅂ / Map.@default : ㅂ;

    // --------------------------------------------------------------

    public static string Name(Rep ρ) => ρ.name;

    public static string Prefix(Rep ρ){
        if(ρ.prefix != null) return ρ.prefix;
        string ㄸ = ToPrefix(ρ.b);
        return ㄸ.Length > 0 ? ㄸ
               : ρ.label != null ? LabelToPrefix(ρ.label) : "";
    }

    public static string Body(Rep ρ)
    => (ρ.body ?? ρ.a) + (ρ.nts ? null : " ");

    // --------------------------------------------------------------

    static string LabelToPrefix(string label)
    => label != null ? ToPrefix(label).ToLower() : null;

    public static string ToPrefix(string x){
        var buf = new StringBuilder(); int S = 0; foreach(char c in x){
            if(Char.IsLetterOrDigit(c)){
                if(S == 0) S = 1; buf.Append(c); if(S == 2) break;
            }else if(S == 1) S = 2;
        } return buf.ToString();
    }

}}
