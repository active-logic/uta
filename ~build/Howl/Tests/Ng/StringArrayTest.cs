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

    [Test] public void Replace () => o(
        new string[]{"a", "b", "c", "d"}.Replace(
            new string[]{"b", "c"},
            new string[]{"e"}
        ),
        new string[]{"a", "e", "d"}
    );

    [Test] public void Matches () => o( new string[]{"a", "b", "c", "d"}.Matches(
        new string[]{"b", "c"}, 1
    ));

    [Test] public void RemoveRange(){
        var x = new string[]{"a", "b", "c", "d"};
        StringArray.RemoveRange(ref x, 1, 2);
        o(x.Length, 2);
        o(x, new string[]{"a", "d"});
    }

    [Test] public void ReplaceRange(){
        var x = new string[]{"a", "b", "c", "d"};
        StringArray.ReplaceRange(ref x, 1, 2, new string[]{"e"});
        o(x, new string[]{"a", "e", "d"});
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
