using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

public class TokenizerTest : TestBase{

    [Test] public void Tokenize(){
        var x = "Foo.bar".Tokenize();
        o(x.Length, 3);
        o(x[0], "Foo");
        o(x[1], ".");
        o(x[2], "bar");
    }

}
