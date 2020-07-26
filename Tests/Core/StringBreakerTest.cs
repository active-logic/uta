using System.IO;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class StringBreakerTest : TestBase{

    [Test] public void Break(){
        var x = "/*abc*/\n#blob\nvars";
        var z = x.Break(("/*", "*/"), ("#","\n"));
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
