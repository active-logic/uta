using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public class Rep{

    const string Undef = "Undefined symbol";

    public ㄹ a, b;
    ㅇ bridge, ignoreConflicts;

    public Rep(){}

    public Rep(ㄹ ㅂ, ㄹ ㄸ, ㅇ bridge=false, ㅇ ι=false){
        a = ㅂ; b = ㄸ; this.bridge = bridge;
        this.ignoreConflicts = ι;
    }

    public static implicit operator Rep((ㄹ a, ㄹ b) that)
    => new Rep(){ a = Validate(that.a), b = Validate(that.b),
                  bridge = that.b.Contains(" ") || that.b.Contains(".")};

    public static implicit operator Rep((ㄹ a, ㄹ b, ㅇ bridge) that)
    => new Rep(){ a = Validate(that.a), b = Validate(that.b),
                  bridge = that.bridge };

    public static ㄹ operator * (ㄹ x, Rep y) => x.Replace(y.a, y.b);

    public static ㄹ operator / (ㄹ x, Rep y)
    => y.bridge ? x.Replace(y.b, y.a) : (x.Tokenize() / y).Join();

    public static ㄹ[] operator / (ㄹ[] tokens, Rep rule){
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

    public static ㄹ Validate(ㄹ κ){
        if(κ == null) throw new InvOp(Undef);
        var x = κ.Trim();
        if(x == "?" || x == "") throw new InvOp(Undef);
        return κ;
    }

}}
