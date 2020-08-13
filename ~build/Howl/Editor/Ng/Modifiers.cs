using System.Linq; using System.Collections.Generic;

namespace Active.Howl{ public static class Modifiers{

    // Modified Resharper default
    static string[] csTemplate = new []{ "override", /**/ "public", "protected",
        "internal", "private", /**/ "static", /**/ "new",
        /**/ "abstract", "virtual", "sealed", /**/ "readonly",
        "extern", "unsafe", "volatile", "async" };

    // This "/" here probably causes a recursive
    // invocation which caused a (undesired) guard in
    // IsModifier. Kind of overkill really
    static string[] howlTemplate = csTemplate / Map.@default;

    public static string[] NitpickSegment (params string[] tokens)  {
        List<string> ㄸ = new List<string>(), μ = new List<string>();
        string _ = null;
        foreach (var x in tokens){
        //🍥($"Check token {x}");
        switch (x){
        //⥰ ∅ : ¦
        case string z when IsModifier(x):
            μ.Add(x);  _ = null; break;
        case string z when x.IsWhiteSpace():
            if (μ.Count == 0) ㄸ.Add(x);
            else _ = x; break;
        default:
            if (μ.Count > 0) {
                ㄸ.Add(Nitpick(μ.ToArray()));  μ.Clear();  if (_ != null) ㄸ.Add(_);
            }
            ㄸ.Add(x); _ = null; break;
        } // end switch
        } // end foreach
        return ㄸ.ToArray();
    }

    static bool IsModifier(string x) {
        if (howlTemplate == null) return false;
        else foreach (var k in howlTemplate) if (k == x) return true; return false;
    }

    public static string   Nitpick(params string[] α) => ReorderHl(α).Join().Replace("‒∘", "‒̥");
    public static string[] ReorderCs (params string[] α) => Reorder(csTemplate, α);
    public static string[] ReorderHl (params string[] α) => Reorder(howlTemplate, α);
    public static string[] Reorder(string[] τ, params string[] α) => (from x in τ where α.Contains(x) select x).ToArray();

}}
