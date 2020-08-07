using System.IO;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class StringBreakerTest : TestBase{

    static Block.Def dqRule            = ("\"", "\""),
                 cStyleCommentRule = ("/*", "*/");

    [Test] public void Break_with_escapes_1(){
        char dq = '"', es = '\\';
        var @in = dq + "Fox" + es + es + dq + " box";
        var parts = @in.Break(dqRule);
        o( parts.Length, 2);
    }

    // ["\" fox]
    [Test] public void Break_with_escapes_2 () => o( "\"\\\" fox".Break(dqRule).Length, 1);

    // ["\\" fox]
    [Test] public void Break_with_escapes_3 () => o( "\"\\\\\" fox".Break(dqRule).Length, 2);

    [Test] public void Break_With_SQDQ([Values("'\"'", "char c = '\"'")] string @in){
        o( @in.Break(dqRule).Length, 1 );
    }

    [Test] public void Break_With_EDQ(){
        char dq = '"', bs = '\\';
        o( ("" + dq + bs + dq + dq).Break(dqRule).Length, 1 );
    }

    [Test] public void Break(){
        var x = "/*abc*/\n#blob\nvars";
        var z = x.Break(cStyleCommentRule, ("#","\n"));
        o(z.Length, 4);
        o(z[0], "/*abc*/");
        o(z[1], "\n");
        o(z[2], "#blob\n");
        o(z[3], "vars");
    }

    [Test] public void DenotesBlock(){
        var defs = new Block.Def[]{ ("/*", "boo") };
        o(  "/*gu-gu".DenotesBlock(defs) );
        o( !"barmaid".DenotesBlock(defs) );
    }

}}
