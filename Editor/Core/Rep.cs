using System.Collections.Generic;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
[System.Serializable]
public class Rep{

    const string Undef = "Undefined symbol";

    public ㄹ a, b, header, alt;
    public ㅇ import = true, @sel = true;
    public ㅇ bridge, ignoreConflicts;

    // Factor -------------------------------------------------------

    public Rep(){}

    public Rep(ㄹ ㅂ, ㄹ ㄸ, ㅇ bridge=false, ㅇ ι=false, ㄹ H=null, ㅇ π=true){
        a = ㅂ; b = ㄸ; this.bridge = bridge; header = H;
        ignoreConflicts = ι; import = π;
    }

    public static implicit operator Rep((ㄹ a, ㄹ b) that)
    => new Rep(){
        a = Validate(that.a),
        b = Validate(that.b),
        bridge = that.b.Contains(" ") || that.b.Contains(".")
    };

    public static implicit operator Rep((ㄹ a, ㄹ b, ㄹ alt) that)
    => new Rep(){
        a = Validate(that.a),
        b = Validate(that.b),
        alt = that.alt,
    };

    public static implicit operator Rep((ㄹ a, ㄹ b, ㅇ bridge) that)
    => new Rep(){
        a = Validate(that.a),
        b = Validate(that.b),
        bridge = that.bridge
    };

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

    public static ㅇ operator ! (Rep x)
    => x.a.Length == 1 && x.b.IsAlphaNumeric();

    public static ㄹ operator ~ (Rep x)
    => x.alt ?? x.a;

    // --------------------------------------------------------------

    ㅇ willImport => @sel && import;

    // Functions ----------------------------------------------------

    public ㅇ Encloses(Rep that)
        => this.b.Length == that.b.Length ? false
        : this.b.Contains(that.b);

    public static ㄹ Validate(ㄹ κ){
        if(κ == null) throw new InvOp(Undef);
        var x = κ.Trim();
        if(x == "?" || x == "") throw new InvOp(Undef);
        return κ;
    }

    public ㅇ ValueMatches(ㄹ that) => b == that;

    override public ㄹ ToString() => $"{a} (=>) {b}";

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
