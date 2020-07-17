using System.Linq; using System.Text;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public partial class Map{

    public Rep[] rules;
    public Reml[] remove;

    public static implicit operator Map(Rep[] that){
        var map = new Map(){ rules = that };
        map.remove = (from x in that select (Reml)$"using {x.a}")
                     .ToArray();
        return map;
    }

    public static char[] operator ! (Map m)
    => (from x in m.rules where !x select x.a[0]).ToArray();

    public static ㄹ operator * (ㄹ x, Map y){
        x = y.Consolidate(x);
        foreach(var k in y.remove) x *= k;
        foreach(var r in y.rules) x *= r;
        return x;
    }

    public static ㄹ operator / (string x, Map y){
        var ㄸ = new StringBuilder();
        foreach(var θ in x.Break(defs))
            ㄸ.Append(θ.DenotesBlock(defs) ? θ : Revert(θ, y));
        return ㄸ.ToString();
    }

    static ㄹ Revert(ㄹ x, Map y){
        var tokens = x.Tokenize();
        foreach(var r in y.rules) tokens /= r;
        return tokens.Join();
    }

    ㄹ Consolidate(ㄹ x){
        var ㄸ = new StringBuilder();
        foreach(var θ in x.Break(defs))
            ㄸ.Append(θ.DenotesBlock(defs) ? θ
                     : x.Consolidate(!this));
        return ㄸ.ToString();
    }

    // ==============================================================

    static Block.Def[] defs = new Block.Def[]{
        ("\"","\""),  // string literal
        ("/*","*/"),  // C style comment
        "//",         // C++ style comment
        "#",          // Directive
    };

}}
