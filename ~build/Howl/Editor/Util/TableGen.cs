using Active.Howl;
using System.Linq;

namespace Active.Howl.Util{
public static class TableGen{

    static int ι;

    const string preamble =
@"# Cosmo Specification
v0.2.10α - © T.E.A de Souza 2020, All Rights Reserved.

An expressive notation drawing from natural scripts,
symbolic formalisms and dingbats.
";
    const string theader  = "|  #  | Sym | Syntax    | Description |";
    const string tformat  = "| :-: | :-: | ---       | ---         |";

    public static void Create(){
        ι = 1;
        "Assets/Howl/Documentation/Cosmo-Spec.md"
        .Write(preamble + Format(Map.@default));
    }

    public static string Format(Map map)
    => (from ρ in map.declarative select Format(ρ)).ToArray().Join("");

    public static string Format(Rep ρ) => Section(ρ.header)
       + (ρ.nospec ? null
       : $"| {ι++} | {ρ.a} | {ρ.b} | {ρ.description} |\n");

    public static string Section(string header){
        return (header == null) ? ""
        : $"\n### {header}\n{theader}\n{tformat}\n";
    }

}}
