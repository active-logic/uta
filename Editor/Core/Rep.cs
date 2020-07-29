using System.Collections.Generic;
using InvOp = System.InvalidOperationException;

namespace Active.Howl{
[System.Serializable]
public partial class Rep{

    const string Undef = "Undefined symbol";

    public string a, b, header, alt, label, prefix, body, _class;

    public bool bridge    = false,  import = true,
              noSnippet = false,  ignoreConflicts = false,
              @sel       = true,  nts = false;

    // Operators ----------------------------------------------------

    public static string operator * (string x, Rep y) => x.Replace(y.a, y.b);

    public static string operator / (string x, Rep y){
        if(!y.willImport) return x;
        return y.bridge ? x.Replace(y.b, y.a)
                        : (x.Tokenize() / y).Join();
    }

    public static string[] operator / (string[] tokens, Rep rule){
        if(!rule.willImport) return tokens;
        if(rule.bridge) return (tokens.Join() / rule).Tokenize();
        for(int i = 0; i < tokens.Length; i++){
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

    public static bool operator ! (Rep x)
    => x.a.Length == 1 && x.b.IsAlphaNumeric();

    /* Editor safe symbolic presentation */
    public static string operator ~ (Rep x)
    => x.alt ?? x.a;

    // Properties ---------------------------------------------------

    public string name => label ?? b.Trim().Ftu();

    public bool nit => !b.IsAlphaNumeric();

    bool willImport => @sel && import;

    // Functions ----------------------------------------------------

    public bool Encloses(Rep that)
        => this.b.Length == that.b.Length ? false
        : this.b.Contains(that.b);

    public bool ValueMatches(string that) => b == that;

    void Print(string x) => UnityEngine.Debug.Log(x);

    override public string ToString() => $"{name} ⌞{~this}⌝ → ⌞{b}⌝";

    // Static -------------------------------------------------------

    public static Rep[] Reorder(Rep[] x){
        var ㄸ = new List<Rep>();
        foreach(var ρ in x){
            bool added = false;
            for(int i = 0; i < ㄸ.Count; i++){
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
