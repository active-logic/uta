using InvOp = System.InvalidOperationException;

// TODO instead of adding tuple ops define flags, like this:
// [a, b] -b -ι -H -π -ns

namespace Active.Howl{
public partial class Rep{

    public Rep(){}

    // TODO: rename 'bridge' to β
    public Rep(string ㅂ, string ㄸ, string name=null, string px=null, string alt=null, bool? bridge=null,
           bool ι=false, string H=null, bool π=true, bool ns=false, bool q=false, string desc=null){
        a = ㅂ; b = ㄸ;
        this.label       = name;
        this.bridge      = bridge ?? IsBridging(ㄸ);
        this.prefix      = px;
        this.alt         = alt;
        nospec        = q;
        ignoreConflicts  = ι;
        header           = H;
        import           = π;
        noSnippet        = ns;
        _description = desc;
    }

    public static implicit operator Rep((string a, string b) that)
    => new Rep(){
        a = Validate(that.a),
        b = Validate(that.b),
        bridge = IsBridging(that.b)
    };

    public static implicit operator Rep((string a, string b, string alt) that)
    => new Rep(){
        a = Validate(that.a),
        b = Validate(that.b),
        bridge = IsBridging(that.b),
        alt = that.alt
    };

    public static implicit operator Rep((string a, string b, string alt, string px) that)
    => new Rep(){
        a      = Validate(that.a),
        b      = Validate(that.b),
        bridge = IsBridging(that.b),
        alt    = that.alt,
        prefix = that.px
    };

    public static implicit operator Rep((string a, string b, bool bridge) that)
    => new Rep(){
        a = Validate(that.a),
        b = Validate(that.b),
        bridge = that.bridge
    };

    public static bool IsBridging(string x)
    => x.Contains(" ") || x.Contains(".");

    public static string Validate(string κ){
        if(κ == null) throw new InvOp(Undef);
        var x = κ.Trim();
        if(x == "?" || x == "") throw new InvOp(Undef);
        return κ;
    }

}}
