using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class RepTest : TestBase{

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

    [Test] public void FromTuple()
    { Rep x = ("a", "b"); o(x.a, "a"); o(x.b, "b"); }

    [Test] public void FromTuple_badDef(){
        Assert.Throws<InvOp>(() => { Rep x = ((ㄹ)null, "x"); });
        Assert.Throws<InvOp>(() => { Rep x = ("x",(ㄹ)null); });
    }

    [Test] public void Mul(){
        Rep x = ("⦿", "void");
        o("⦿ Act()" * x, "void Act()");
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
        if(Config.ignoreConflicts){
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
        o(new ㄹ[]{"public", " ", "static"} / x, new ㄹ[]{"!"});
    }

    [Test] public void DivArray_tokenized(){
        Rep x = ("ᆞ", "int");
        o(new ㄹ[]{"Print", " ", "void"} / x,
          new ㄹ[]{"Print", " ", "void"});
    }

    [Test] public void Validate(){
        Assert.Throws<InvOp>( () => Rep.Validate(null) );
        Assert.Throws<InvOp>( () => Rep.Validate("?") );
        Assert.Throws<InvOp>( () => Rep.Validate("") );
        Assert.Throws<InvOp>( () => Rep.Validate(" ") );
    }

}}
