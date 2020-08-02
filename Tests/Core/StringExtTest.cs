using System.IO;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class StringExtTest : TestBase{

    [Test] public void Comment () => o( "Foo".Comment(), "// Foo\n");

    [Test] public void Insert(){
        var x = "Foo |=\n"
              + "------\n"
              + "=| Bar\n";
        var y = x.Insert("Hot potatoes\n& fries", "|=", "=|");
        var z = "Foo |=\n"
              + "Hot potatoes\n"
              + "& fries\n"
              + "=| Bar\n";
        //rint($"OUTPUT\n{y}");
        o(y, z);
    }

    //Expected: "Foo |=\nHot potatoes\n& fries\n=| Bar\n"
    //But was:  "Foo |=Hot potatoes\n& fries\n=| Bar\n"

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

    [Test] public void ReadLines(){
        string π = "Assets/Howl/Extras/cs-snippets.cson";
        string[] x = π.ReadLines();
        o(x[0], "'.source.cs':");
        o(x[1], "  'Abstract':");
        o(x.Length, 142);
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

    [Test] public void Tokenize_With_at(){
        var x = "Foo.@bar".Tokenize();
        o(x.Length, 3);
        o(x[0], "Foo");
        o(x[1], ".");
        o(x[2], "@bar");
    }
}}
