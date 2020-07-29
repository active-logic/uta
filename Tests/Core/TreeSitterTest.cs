using System.IO;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class TreeSitterTest : TestBase{

    Map map = new Rep[]{
        Classifier.o * ("+", "plus"),
        Classifier.o * ("-", "minus")
    };

    [Test] public void Inject(){
        var g = "These (__Op__) are operators";
        var @out = TreeSitter.Inject(g, map, raise: false);
        o( @out, "These ('+', '-') are operators");
    }

    [Test] public void Inject_Finely(){
        var g = "__%plus%__ and __%minus%__ are operators";
        var @out = TreeSitter.Inject(g, map, raise: false);
        o( @out, "'+' and '-' are operators");
    }

    [Test] public void InjectEach(){
        var g = "__%plus%__ and __%minus%__ are operators";
        var @out = TreeSitter.InjectEach(
            g, Classifier.o, map, raise: true);
        o( @out, "'+' and '-' are operators");
    }

    [Test] public void Inject_Failed(){
        var g = "These (__Bo__) are operators";
        string @out;
        Assert.Throws<InvOp>(
            () => @out = TreeSitter.Inject(g, map)
        );
    }

    [Test] public void Format(){
        var @out = TreeSitter.Format(Classifier.o, map);
        o( @out, "'+', '-'");
    }

    [Test] public void Tag_ForClass()
    => o( TreeSitter.Tag(Classifier.o), "__Op__" );

    [Test] public void Tag_ForRule()
    => o( TreeSitter.Tag(new Rep("o", "bool")), "__%bool%__" );

}}
