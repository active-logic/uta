using System.IO; using System.Linq;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class MapTest : TestBase{

    Map ω;

    [SetUp] public void Setup(){
        ImportConfig.Clear();
        ω = Map.@default;
    }

    [Test] public void FromRepArray(){
        Map x = new Rep[]{ ("a", "b"), ("c", "d") };
        o(x.rules.Length, 2);
    }

    [Test] public void Apply()
    => o("▷ Act()" * ω, "public action Act()");

    [Test] public void Revert()
    => o( "public action Act()" / ω, "▷ Act()" );

    [Test] public void NitPick(){
        o(">=" % ω, "≥");
    }

    [Test] public void Nits(){
        o( ω.nits.Contains(ω.Rule(">=")) );
    }

    [Test] public void Revert_class_rule(){
        o( "class Foo" / ω, "○ Foo" );
    }

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

}}
