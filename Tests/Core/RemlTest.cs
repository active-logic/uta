using System.IO;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class RemlTest : TestBase{

    [Test] public void Mul(){
        Reml x = "using float";
        o("foo\nusing float = foo;\n" * x,
          "foo\n");
    }

    [Test] public void Mul_NeedsEquals(){
        Reml x = "using Foo";
        o("using Foo;\n" * x,
          "using Foo;\n");
    }

}}