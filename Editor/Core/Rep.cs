using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public class Rep{

    const string Undef = "Undefined symbol";

    public ㄹ a, b;
    ㅇ bridge;

    public static implicit operator Rep((ㄹ a, ㄹ b) that)
    => new Rep(){ a = Validate(that.a), b = Validate(that.b),
                  bridge = that.b.Contains(" ")};

    public static implicit operator Rep((ㄹ a, ㄹ b, ㅇ bridge) that)
    => new Rep(){ a = Validate(that.a), b = Validate(that.b),
                  bridge = that.bridge };

    public static ㄹ operator * (ㄹ x, Rep y) => x.Replace(y.a, y.b);

    public static ㄹ operator / (ㄹ x, Rep y)
    => y.bridge ? x.Replace(y.b, y.a) : (x.Tokenize() / y).Join();

    public static ㄹ[] operator / (ㄹ[] x, Rep y){
        if(y.bridge) return (x.Join() / y).Tokenize();
        for(ᆞ i = 0; i < x.Length; i++) if(x[i] == y.b) x[i] = y.a;
        return x;
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
