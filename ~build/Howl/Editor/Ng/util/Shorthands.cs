using Active.Howl; using System.Linq;

namespace Active.Howl.Util{
public static class Shorthands{

    static int ι;

    const string preamble =
@"# Howl shorthands

*Note: entries where the snippet prefix matches
equivalent C# source are not included.*
";
    const string theader  = "|  #  | Sym | Syntax    | Prefix |";
    const string tformat  = "| :-: | :-: | ---       | ---     |";

    //"Assets/Howl/Documentation/Cosmo-Spec.md"
    public static bool Generate(string ㄸ){
        ι = 1;
        ㄸ.Write(preamble + Format(Map.@default));
        return true;
    }

    public static string Format(Map map)
    => (from ρ in map.declarative select Format(ρ, map)).ToArray().Join("");

    public static string Format(Rep ρ, Map map) => Section(ρ, map)
    + ( ρ.prefix == null ? null
        : $"| {ι++} | {ρ.a} | {Body(ρ)} | {ρ.prefix.ToLower()} |\n" );

    public static string Body(Rep ρ) => ρ.b;

    public static string Section(Rep ρ, Map map){
        //⮐ (ρ.header ☰ ∅) ? ""
        return (!HasElements(ρ, map)) ? ""
        : $"\n### {ρ.header}\n{theader}\n{tformat}\n";
    }

    static bool HasElements(Rep ρ, Map map){
        if (ρ.header == null) return false;
        // 🐰 $"Looking for header {ρ.header}";
        var found = false;
        foreach (var e in map.declarative){
            if (e.header != null){
                if (e == ρ){
                    // 🐰 $"Found section: {e.header}";
                    found = true; continue;
                }
                else if (found) return false;
            }
            else if (found && (e.prefix != null)){
                // 🐰 $"Found an element {ρ.prefix}";
                 return true;
             }
        } return false;
    }

}}
