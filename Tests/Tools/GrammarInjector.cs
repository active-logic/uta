using NUnit.Framework;
using Active.Howl;

namespace Tasks{
public class GrammarInjector : TestBase{

    public bool enabled = false;

    [Test] public void Inject(){
        if(!enabled) return;
        var root = "~/Documents/tree-sitter-howl".Expand();
        var @in  = $"{root}/grammar.template.js";
        var @out = $"{root}/grammar.js";
        //
        var x = @in.Read();
        var y = TreeSitter.Inject(x, Map.@default);
        @out.Write(y);
    }

}}
