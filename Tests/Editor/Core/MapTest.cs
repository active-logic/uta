using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

public class MapTest : TestBase{

    Map ω;

    [SetUp] public void Setup() => ω = Map.@default;

    [Test] public void FromRepArray(){
        Map x = new Rep[]{ ("a", "b"), ("c", "d") };
        o(x.rules.Length, 2);
        o(x.remove.Length, 4);
        o(x.remove[0].hint, "♖ a");
        o(x.remove[1].hint, "using a");
    }

    [Test] public void Apply()
    => o("⍥ Act()" * ω, "public void Act()");

    [Test] public void Revert()
    => o("public void Act()" / ω, "⍥ Act()");

    // TODO this test causes a conflict that should not be
    // happening.
    // [Test] public void Revert_WithBridgedToken()
    // => o("public static void Act()" / ω, "⃠ ┈ Act()");

    [Test] public void Revert_ConflictThrows(){
        if(Config.ignoreConflicts){
            var ㄸ = "メ.Reach" / ω;
        }else
            Assert.Throws<InvOp>( () => { var ㄸ = "メ.Reach" / ω; } );
    }

    // TODO when Howl imports this test file, escaped '"' causes
    // a conflict
    //[Test] public void Revert_NoConflictInEscapedBlocks(){
    //    var ㄸ = "\"メ.Reach\"" / ω;
    //}

    [Test] public void RemoveLegacyUsingStatements(){
        var π = "Assets/Howl/Editor/Core/FileSystem.cs";
        var x = File.ReadAllText(π);
        var ㄸ = x * Map.@default;
        o(! ㄸ.Contains("using float"));
    }

}
