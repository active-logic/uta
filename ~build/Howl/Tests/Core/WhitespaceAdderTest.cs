using System.IO;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class WhiteSpaceAdderTest : TestBase{

    [Test] public void Consolidate(){
        string ㅂ = "Foo\n//bar";
        var ㄸ = ㅂ.Consolidate(new char[]{'/'});
        //rint($"In {ㅂ}");
        //rint($"Out {ㄸ}");
        o(ㄸ, "Foo\n/ / bar");
    }

}}
