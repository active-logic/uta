using System.IO;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class StringArrayTest : TestBase{

    const string π = "ArrayTest.txt";

    [Test] public void Join(){
        var x = new string[]{"Foo", "Bar"}.Join('\n');
        o( x, "Foo\nBar");
    }

    [Test] public void Write_Lines(){
        new string[]{"Foo", "Bar"}.Write(π);
        o( File.ReadAllText(π), "Foo\nBar\n" );
        File.Delete(π);
    }

    [Test] public void Write_WithSep(){
        new string[]{"Foo", "Bar"}.Write(π, '-');
        o( File.ReadAllText(π), "Foo-Bar" );
        File.Delete(π);
    }

}}
