using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class StringArrayTest : TestBase{

    const ㄹ π = "ArrayTest.txt";

    [Test] public void Write_Lines(){
        new ㄹ[]{"Foo", "Bar"}.Write(π);
        o( File.ReadAllText(π), "Foo\nBar\n" );
        File.Delete(π);
    }

    [Test] public void Write_WithSep(){
        new ㄹ[]{"Foo", "Bar"}.Write(π, '-');
        o( File.ReadAllText(π), "Foo-Bar" );
        File.Delete(π);
    }

}}
