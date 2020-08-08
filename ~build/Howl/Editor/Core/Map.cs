using InvOp = System.InvalidOperationException;
using System.Collections;
using System; using System.Collections.Generic; using System.Linq;
using System.Text;

namespace Active.Howl{
public partial class Map : IEnumerable{

    public Rep[] declarative, rules;

    // Factory ------------------------------------------------------

    public static implicit operator Map(Rep[] that)
    => new Map(){ declarative = that, rules = Rep.Reorder(that) };

    // Operators ----------------------------------------------------

    public static string operator * (string x, Map y) => Forw(y.Consolidate(x), y.rules);

    public static string operator / (string x, Map y) => Rev(x, y.rules);

    public static string operator % (string x, Map y) => Rev(x, y.nits);

    public static char[] operator ! (Map m)
    => (from x in m.rules where !x select x.a[0]).ToArray();

    // Functions ----------------------------------------------------

    public void Rebuild(Rep[] that)
    { declarative = that; rules = Rep.Reorder(that); }

    // Get information ----------------------------------------------

    public int count => rules.Length;

    public bool integer{ get{
        var @set = new Dictionary<string, List<Rep>>();
        foreach(var x in rules){
            List<Rep> γ = @set.ContainsKey(x.a)
                          ? @set[x.a] : @set[x.a] = new List<Rep>();
            γ.Add(x);
        }
        bool hasConflicts = false;
        foreach(var z in @set.Values){
            if(z.Count > 1){
                // TODO who should see this?
                UnityEngine.Debug.LogWarning($"[{z[0].a}] has conflicts ({z.Count})");
                hasConflicts = true;
            }
        }
        return !hasConflicts;
    }}

    // TODO: return IEnumerable instead
    public Rep[] nits
    => (from ρ in rules where ρ.nit select ρ).ToArray();

    public Rep[] ForClass(string @class)
    => (from ρ in rules where ρ._class == @class select ρ).ToArray();


    public int this[string key]{get{
        for(int i = 0; i < rules.Length; i++){
            if(rules[i].ValueMatches(key)) return i;
        }
        throw new InvOp("Bad Key");
    }}

    public Rep Rule(string key){
        for(int i = 0; i < rules.Length; i++){
            if(rules[i].ValueMatches(key)) return rules[i];
        }
        throw new InvOp("Bad Key");
    }

    public IEnumerator GetEnumerator() => declarative.GetEnumerator();

    // IMPLEMENTATION -----------------------------------------------

    public static string Forw(string x, Rep[] ρ){
        var ㄸ = new StringBuilder();
        foreach(var θ in x.Break(defs))
            ㄸ.Append(θ.DenotesBlock(defs) ? θ : ForwChunk(θ, ρ));
        return ㄸ.ToString();
    }

    public static string Rev(string x, Rep[] ρ){
        var ㄸ = new StringBuilder();
        foreach(var θ in x.Break(defs))
            ㄸ.Append(θ.DenotesBlock(defs) ? θ : RevChunk(θ, ρ));
        return ㄸ.ToString();
    }

    static string ForwChunk(string x, Rep[] ρ){
        foreach(var r in ρ) x *= r;
        return x;
    }

    static string RevChunk(string x, Rep[] ρ){
        string[] tokens = x.Tokenize();
        List<string> conflicts = null;
        foreach(var r in ρ){
            try{
                tokens /= r;
            }catch(InvOp ex){
                if(conflicts == null) conflicts = new List<string>();
                conflicts.Add(ex.Message);
            }
        }
        if(conflicts != null) throw
            new InvOp("\n" + conflicts.ToArray().Join('\n'));
        return tokens.Join();
    }

    public string Consolidate(string x){
        var ㄸ = new StringBuilder();
        foreach(var θ in x.Break(defs))
            ㄸ.Append(θ.DenotesBlock(defs) ? θ
                     : θ.Consolidate(!this));
        return ㄸ.ToString();
    }

    static void Print(string x) => UnityEngine.Debug.Log(x);

    // ==============================================================

    public static Block.Def[] defs = new Block.Def[]{
        ("\"","\""),  // string literal
        ("/*","*/"),  // C style comment
        "//",         // C++ style comment
        "#",          // Directive
    };

}}
