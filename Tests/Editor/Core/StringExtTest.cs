using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

public class StringExtTest : TestBase{

    [Test] public void Lines(){
        var x = "Foo\nbar\n".Lines();
        o(x.Length, 2);
        o(x[0], "Foo\n");
        o(x[1], "bar\n");
    }

    [Test] public void LineCount(){
        o("Foo\nbar\n".LineCount(), 2);
    }

    [Test] public void Lines_doubleSpaced(){
        var x = "Foo\n\nbar\n".Lines();
        o(x.Length, 3);
        o(x[0], "Foo\n");
        o(x[1], "\n");
        o(x[2], "bar\n");
    }

    [Test] public void Lines_noTrailingNewLine(){
        var x = "Foo\nbar".Lines();
        o(x.Length, 2);
        o(x[0], "Foo\n");
        o(x[1], "bar");
    }

    [Test] public void Reverse(){
        o("".Reverse(), "");
        o("a".Reverse(), "a");
        o("abc".Reverse(), "cba");
    }

    [Test] public void Tokenize(){
        var x = "Foo.bar".Tokenize();
        o(x.Length, 3);
        o(x[0], "Foo");
        o(x[1], ".");
        o(x[2], "bar");
    }

}
