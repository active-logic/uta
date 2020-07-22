using System.Collections.Generic;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
[System.Serializable]
public partial class Rep{

    const string Undef = "Undefined symbol";

    public ㄹ a, b, header, alt, label, prefix;

    public ㅇ bridge    = false,  import = true,
              noSnippet = false,  ignoreConflicts = false,
              @sel       = true,  nts = false;

    // Operators ----------------------------------------------------

    public static ㄹ operator * (ㄹ x, Rep y) => x.Replace(y.a, y.b);

    public static ㄹ operator / (ㄹ x, Rep y){
        if(!y.willImport) return x;
        return y.bridge ? x.Replace(y.b, y.a)
                        : (x.Tokenize() / y).Join();
    }

    public static ㄹ[] operator / (ㄹ[] tokens, Rep rule){
        if(!rule.willImport) return tokens;
        if(rule.bridge) return (tokens.Join() / rule).Tokenize();
        for(ᆞ i = 0; i < tokens.Length; i++){
            if(tokens[i] == rule.a && !rule.ignoreConflicts
                                   && !Config.ignoreConflicts)
            {
                var prev = i > 1 ? tokens[i - 2] : null;
                if(prev != "using")
                    throw new InvOp($"{rule.a} in input");
            }
            if(tokens[i] == rule.b)
                tokens[i] = rule.a;
        }
        return tokens;
    }

    // Prefix with '-' to remove trailing space from snippets
    public static Rep operator - (Rep x){ x.nts = true; return x; }

    public static ㅇ operator ! (Rep x)
    => x.a.Length == 1 && x.b.IsAlphaNumeric();

    /* Editor safe symbolic presentation */
    public static ㄹ operator ~ (Rep x)
    => x.alt ?? x.a;

    // Properties ---------------------------------------------------

    public ㄹ name => label ?? b.Trim().Ftu();

    public ㅇ nit => !b.IsAlphaNumeric();

    ㅇ willImport => @sel && import;

    // Functions ----------------------------------------------------

    public ㅇ Encloses(Rep that)
        => this.b.Length == that.b.Length ? false
        : this.b.Contains(that.b);

    public ㅇ ValueMatches(ㄹ that) => b == that;

    void Print(ㄹ x) => UnityEngine.Debug.Log(x);

    override public ㄹ ToString() => $"{name} ⌞{~this}⌝ → ⌞{b}⌝";

    // Static -------------------------------------------------------

    public static Rep[] Reorder(Rep[] x){
        var ㄸ = new List<Rep>();
        foreach(var ρ in x){
            ㅇ added = false;
            for(ᆞ i = 0; i < ㄸ.Count; i++){
                if(ρ.Encloses(ㄸ[i])){
                    ㄸ.Insert(i, ρ);
                    added = true;
                    break;
                }
            }
            if(!added) ㄸ.Add(ρ);
        }
        return ㄸ.ToArray();
    }

}}
