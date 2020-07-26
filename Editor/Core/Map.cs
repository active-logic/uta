using InvOp = System.InvalidOperationException;
using System.Collections;
using System; using System.Collections.Generic; using System.Linq;
using System.Text;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public partial class Map : IEnumerable{

    public Rep[] declarative, rules;

    // Factory ------------------------------------------------------

    public static implicit operator Map(Rep[] that)
    => new Map(){ declarative = that, rules = Rep.Reorder(that) };

    // Operators ----------------------------------------------------

    public static ㄹ operator * (ㄹ x, Map y){
        x = y.Consolidate(x);
        foreach(var r in y.rules) x *= r;
        return x;
    }

    public static ㄹ operator / (ㄹ x, Map y) => Rev(x, y.rules);

    public static ㄹ operator % (ㄹ x, Map y) => Rev(x, y.nits);

    public static char[] operator ! (Map m)
    => (from x in m.rules where !x select x.a[0]).ToArray();

    // Functions ----------------------------------------------------

    public void Rebuild(Rep[] that)
    { declarative = that; rules = Rep.Reorder(that); }

    // Get information ----------------------------------------------

    public ᆞ count => rules.Length;

    public ㅇ integer{ get{
        var @set = new Dictionary<ㄹ, List<Rep>>();
        foreach(var x in rules){
            List<Rep> γ = @set.ContainsKey(x.a)
                          ? @set[x.a] : @set[x.a] = new List<Rep>();
            γ.Add(x);
        }
        ㅇ hasConflicts = false;
        foreach(var z in @set.Values){
            if(z.Count > 1){
                UnityEngine.Debug.Log(
                    $"[{z[0].a}] has conflicts ({z.Count})");
                hasConflicts = true;
            }
        }
        return !hasConflicts;
    }}

    // TODO: return IEnumerable instead
    public Rep[] nits => (from ρ in rules where ρ.nit
                                          select ρ).ToArray();

    public ᆞ this[ㄹ key]{get{
        for(ᆞ i = 0; i < rules.Length; i++){
            if(rules[i].ValueMatches(key)) return i;
        }
        throw new InvOp("Bad Key");
    }}

    public Rep Rule(ㄹ key){
        for(ᆞ i = 0; i < rules.Length; i++){
            if(rules[i].ValueMatches(key)) return rules[i];
        }
        throw new InvOp("Bad Key");
    }

    public IEnumerator GetEnumerator()
    => declarative.GetEnumerator();

    // IMPLEMENTATION -----------------------------------------------

    public static ㄹ Rev(ㄹ x, Rep[] ρ){
        var ㄸ = new StringBuilder();
        foreach(var θ in x.Break(defs))
            ㄸ.Append(θ.DenotesBlock(defs) ? θ : RevChunk(θ, ρ));
        return ㄸ.ToString();
    }

    static ㄹ RevChunk(ㄹ x, Rep[] ρ){
        ㄹ[] tokens = x.Tokenize();
        List<ㄹ> conflicts = null;
        foreach(var r in ρ){
            try{
                tokens /= r;
            }catch(InvOp ex){
                if(conflicts == null) conflicts = new List<ㄹ>();
                conflicts.Add(ex.Message);
            }
        }
        if(conflicts != null) throw
            new InvOp("\n" + conflicts.ToArray().Join('\n'));
        return tokens.Join();
    }

    ㄹ Consolidate(ㄹ x){
        var ㄸ = new StringBuilder();
        foreach(var θ in x.Break(defs))
            ㄸ.Append(θ.DenotesBlock(defs) ? θ
                     : θ.Consolidate(!this));
        return ㄸ.ToString();
    }

    static void Print(ㄹ x) => UnityEngine.Debug.Log(x);

    // ==============================================================

    static Block.Def[] defs = new Block.Def[]{
        ("\"","\""),  // string literal
        ("/*","*/"),  // C style comment
        "//",         // C++ style comment
        "#",          // Directive
    };

}}
