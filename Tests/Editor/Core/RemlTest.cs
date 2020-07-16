using System.IO;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

public class RemlTest : TestBase{

    [Test] public void Mul(){
        Reml x = "using float";
        o("foo\nusing float = foo;\n" * x,
          "foo\n");
    }

}
