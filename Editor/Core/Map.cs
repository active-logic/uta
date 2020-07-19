using System; using System.Collections.Generic; using System.Linq;
using System.Text;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public partial class Map{

    public Rep[] rules;
    public Reml[] remove;

    public static implicit operator Map(Rep[] that){
        var map = new Map(){ rules = that };
        map.remove = GenerateRemoveRules(that);
        return map;
    }

    // TODO this is pretty weak;
    public static Reml[] GenerateRemoveRules(Rep[] that){
        var ㄸ = new List<Reml>();
        foreach(var x in that)
        { ㄸ.Add($"♖ {x.a}"); ㄸ.Add($"using {x.a}"); }
        return ㄸ.ToArray();
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
                     : θ.Consolidate(!this));
        return ㄸ.ToString();
    }

    // ==============================================================

    static Block.Def[] defs = new Block.Def[]{
        ("\"","\""),  // string literal
        ("/*","*/"),  // C style comment
        "//",         // C++ style comment
        "#",          // Directive
    };

    static void Print(ㄹ x) => UnityEngine.Debug.Log(x);

}}
