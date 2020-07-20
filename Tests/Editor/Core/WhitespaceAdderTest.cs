using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

public class WhiteSpaceAdderTest : TestBase{

    [Test] public void Consolidate(){
        ㄹ ㅂ = "Foo\n//bar";
        var ㄸ = ㅂ.Consolidate(new char[]{'/'});
        //rint($"In {ㅂ}");
        //rint($"Out {ㄸ}");
        o(ㄸ, "Foo\n/ / bar");
    }

}
