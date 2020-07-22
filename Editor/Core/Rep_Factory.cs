//using System.Collections.Generic;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public partial class Rep{

    public Rep(){}

    // TODO: rename 'bridge' to β
    public Rep(ㄹ ㅂ, ㄹ ㄸ, ㄹ name=null, ㄹ px=null, ㄹ alt=null,
               ㅇ? bridge=null, ㅇ ι=false, ㄹ H=null, ㅇ π=true,
               ㅇ ns=false){
        a = ㅂ; b = ㄸ;
        this.label       = name;
        this.bridge      = bridge ?? IsBridging(ㄸ);
        this.prefix      = px;
        this.alt         = alt;
        ignoreConflicts  = ι;
        header           = H;
        import           = π;
        noSnippet        = ns;
    }

    public static implicit operator Rep((ㄹ a, ㄹ b) that)
    => new Rep(){
        a = Validate(that.a),
        b = Validate(that.b),
        bridge = IsBridging(that.b)
    };

    public static implicit operator Rep((ㄹ a, ㄹ b, ㄹ alt) that)
    => new Rep(){
        a = Validate(that.a),
        b = Validate(that.b),
        bridge = IsBridging(that.b),
        alt = that.alt
    };

    public static implicit operator Rep((ㄹ a, ㄹ b, ㄹ alt, ㄹ px)that)
    => new Rep(){
        a      = Validate(that.a),
        b      = Validate(that.b),
        bridge = IsBridging(that.b),
        alt    = that.alt,
        prefix = that.px
    };

    public static implicit operator Rep((ㄹ a, ㄹ b, ㅇ bridge) that)
    => new Rep(){
        a = Validate(that.a),
        b = Validate(that.b),
        bridge = that.bridge
    };

    public static ㅇ IsBridging(ㄹ x)
    => x.Contains(" ") || x.Contains(".");

    public static ㄹ Validate(ㄹ κ){
        if(κ == null) throw new InvOp(Undef);
        var x = κ.Trim();
        if(x == "?" || x == "") throw new InvOp(Undef);
        return κ;
    }

}}
