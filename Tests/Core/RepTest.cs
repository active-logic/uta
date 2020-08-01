using System.IO;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class RepTest : TestBase{

    // Test factory methods ----------------------------------------

    [Test] public void FromTuple()
    { Rep x = ("a", "b"); o(x.a, "a"); o(x.b, "b"); }

    [Test] public void FromBinaryTuple_Bridging(){
        Rep x = ("🍩", "Class ");
        o( x.bridge, true );
    }

    [Test] public void FromTernaryTuple_Bridging(){
        Rep x = ("🍘", "class ", alt: "x");
        o( x.bridge, true );
    }

    [Test] public void FromNew_ImplicitBridging(){
        var x = new Rep("⍥", "public void", px: "pv");
        o( x.bridge, true);
    }

    [Test] public void FromTuple_badDef(){
        Assert.Throws<InvOp>(() => { Rep x = ((string)null, "x"); });
        Assert.Throws<InvOp>(() => { Rep x = ("x",(string)null); });
    }

    [Test] public void Mul(){
        Rep x = ("⦿", "void");
        o("⦿ Act()" * x, "void Act()");
    }

    [Test] public void Minus(){
        Rep x = ("⦿", "void");
        o(x.nts, false);
        o((-x).nts, true);
    }

    [Test] public void Nit() => o( new Rep("≥", ">=").nit, true );

    [Test] public void Encloses(){
        Rep x = ("P", "public"), y = ("PS", "public static");
        o(x.Encloses(y), false);
        o(y.Encloses(x), true);
    }

    [Test] public void Encloses_MustBeWider(){
        Rep x = ("A", "public"), y = ("B", "public");
        o(x.Encloses(y), false);
        o(y.Encloses(x), false);
    }

    [Test] public void Name_1(){
        Rep x = ("-", "namespace ");
        o(x.name, "Namespace");
    }

    [Test] public void Name_2(){
        Rep x = ("-", "using static");
        o(x.name, "Using static");
    }

    [Test] public void Div(){
        Rep x = ("⦿", "void");
        o("void Act()" / x, "⦿ Act()");
    }

    [Test] public void Div2(){
        Rep x = ("⍥", "public void");
        o("public void Act()" / x, "⍥ Act()");
    }

    [Test] public void Div_ConflictThrows(){
        System.Action act = () => {
            var ㄸ = "メ.Reach".Tokenize() / (Rep)("メ", "Vector3");
        };
        if(Config.ι.ignoreConflicts){
            act();
        }else Assert.Throws<InvOp>( () => act() );

    }

    [Test] public void Div_bridged(){
        Rep x = ("!", "public static");
        o("public static void" / x, "! void");
    }

    [Test] public void Div_tokenized(){
        Rep x = ("ᆞ", "int");
        o("Print(foo); int z;" / x, "Print(foo); ᆞ z;");
    }

    [Test] public void DivArray_bridged(){
        Rep x = ("!", "public static");
        o(new string[]{"public", " ", "static"} / x, new string[]{"!"});
    }

    [Test] public void DivArray_tokenized(){
        Rep x = ("ᆞ", "int");
        o(new string[]{"Print", " ", "void"} / x,
          new string[]{"Print", " ", "void"});
    }

    [Test] public void Validate(){
        Assert.Throws<InvOp>( () => Rep.Validate(null) );
        Assert.Throws<InvOp>( () => Rep.Validate("?") );
        Assert.Throws<InvOp>( () => Rep.Validate("") );
        Assert.Throws<InvOp>( () => Rep.Validate(" ") );
    }

    [Test] public void ToString_(){
        Rep x = ("ᆞ", "int");
        o( x.ToString(), "Int ⌞ᆞ⌝ → ⌞int⌝" );
    }

}}
