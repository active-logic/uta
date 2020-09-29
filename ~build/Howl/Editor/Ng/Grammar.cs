using System.Linq;
using InvOp = System.InvalidOperationException;

namespace Active.Howl{
public class Grammar{

    // cd to tree-sitter-howl, then:
    // In: grammar.template.js, Out: grammar.js
    public static bool Inject(string ㅂ, string ㄸ){
        That.Logger.Log("Injecting grammar template");
        ㄸ.Write(Grammar.Inject(ㅂ.Read(), Map.@default));
        return true;
    }

    public static string Inject(string jsGram, Map map, bool raise = true){
        foreach(Classifier x in Classifier.all){
            var tag = Tag(x);
            if(jsGram.Contains(tag)){
                jsGram = jsGram.Replace(tag, Format(x, map));
            }else{
                jsGram = InjectEach(jsGram, x, map, raise);
            }
        }
        return jsGram;
    }

    public static string InjectEach(string jsGram, Classifier x,
                                    Map map, bool raise = true){
        foreach(Rep rule in map.ForClass(x)){
            var tag = Tag(rule);
            if(jsGram.Contains(tag)){
                jsGram = jsGram.Replace(tag, $"'{rule.a}'");
            }else if(raise) throw
                new InvOp($"Template needs {tag} or {Tag(x)}");
        }
        return jsGram;
    }

    public static string Tag(Classifier x) => $"__{x}__";

    public static string Tag(Rep x) => $"__%{x.b}%__";

    public static string Format(Classifier x, Map map)
    => (from ρ in map.ForClass(x) select $"'{ρ.a}'")
       .ToArray().Join(", ");

}}
