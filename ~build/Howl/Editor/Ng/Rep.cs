using System.Collections.Generic;
using InvOp = System.InvalidOperationException;

namespace Active.Howl{
[System.Serializable]
public partial class Rep{

    const string Undef = "Undefined symbol";

    public string a, b, header, alt, label, prefix, body, _class, _description;

    public bool bridge = false, import = true, noSnippet = false,  ignoreConflicts = false,
        @sel   = true,  nts = false, nospec = false;

    // Operators ----------------------------------------------------

    public static string operator * (string x, Rep y) => x.Replace(y.a, y.b);

    public static string operator / (string x, Rep y){
        if(!y.willImport) return x;
        return y.bridge ? x.Replace(y.b, y.a)
                        : (x.Tokenize() / y).Join();
    }

    public static string[] operator / (string[] tokens, Rep rule) => Rep.Rev(tokens, rule);

    // Prefix with '-' to remove trailing space from snippets
    public static Rep operator - (Rep x){ x.nts = true; return x; }

    // Indicates whether this is a "soft" symbol. When converted, a
    // soft symbol may concatenate with previous/next elements,
    // creating errors.
    // TODO this implementation is incorrect. We should only be
    // looking at first and last char.
    public static bool operator ! (Rep x){
        var  s = x.b;
        return char.IsLetterOrDigit(s[0]) && char.IsLetterOrDigit(s[s.Length-1]);
    }

    /* Editor safe symbolic presentation */
    public static string operator ~ (Rep x) => x.alt ?? x.a;

    // Properties ---------------------------------------------------

    public string name => label ?? b.Trim().Ftu();

    public string description => _description ?? label ?? null;

    public bool nit => !b.IsAlphaNumeric();

    bool willImport => @sel && import;

    // Functions ----------------------------------------------------

    public static string[] DivBridging(string[] tokens, Rep rule){
        string[] lh = rule.b.Tokenize();
        return tokens.Replace(lh, new string[]{rule.a});
    }

    public bool Encloses(Rep that) => this.b.Length == that.b.Length ? false : this.b.Contains(that.b);

    public bool ValueMatches(string that) => b == that;

    override public string ToString() => $"{name} ⌞{~this}⌝ → ⌞{b}⌝";

    // Static -------------------------------------------------------

    public static string[] Rev(string[] tokens, Rep rule, bool ignoreConflicts=true){
        if (!rule.willImport) return tokens;
        if (rule.bridge)      return DivBridging(tokens, rule);
        bool checkConflicts = !(ignoreConflicts
                             || rule.ignoreConflicts
                             || (Config.ι?.ignoreConflicts ?? false));
        for (int i = 0; i < tokens.Length; i++){
            if (tokens[i] == rule.b) tokens[i] = rule.a;
            else if (checkConflicts && (tokens[i] == rule.a))
                throw new InvOp($"{rule.a} in input");
        }
        return tokens;
    }

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
