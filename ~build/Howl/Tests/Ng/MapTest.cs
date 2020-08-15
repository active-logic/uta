using System.IO; using System.Linq;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class MapTest : TestBase{

    Map ω;

    [SetUp] public void Setup(){
        #if UNITY_EDITOR
        ImportConfig.Clear();
        #endif
        ω = Map.@default;
    }

    [Test] public void FromRepArray(){
        Map x = new Rep[]{ ("a", "b"), ("c", "d") };
        o(x.rules.Length, 2);
    }

    [Test] public void Apply()
    => o("▷ Act()" * ω, "public action Act()");

    [Test] public void Apply_withCompactModifiers_1()
    => o("‒⁺" * ω, "public override");

    [Test] public void Apply_withCompactModifiers_2()
    => o("‒̥⁺" * ω, "public static override");

    [Test] public void Apply_quoted()
    => o("\"(╯°□°)╯\"" * ω, "\"(╯°□°)╯\"");

    [Test] public void Apply_2 () => o("Badge(\"(╯°□°)╯ ⌒ $\"" * ω,
                   "Badge(\"(╯°□°)╯ ⌒ $\"");

    [Test] public void Consolidate () => o( ω.Consolidate("‒○"), "‒ ○" );

    // Does not acknowledge litterals, have to use segmented form
    [Test] public void Consolidate_usesSegmentedForm () =>
    o( ω.Consolidate("A \"litt/eral\" string"),
       "A \"litt/eral\" string");

    [Test] public void Consolidate_cmbVariants () => o( ω.Consolidate("‒̥○"), "‒̥ ○" );

    [Test] public void Revert()
    => o( "public action Act()" / ω, "▷ Act()" );

    [Test] public void Revert_bridging_token_honors_word_boundaries()
    => o( "public Big.Values" / ω, "‒ Big.Values" );

    [Test] public void NitPick () => o(">=" % ω, "≥");

    [Test] public void NitPick_honors_word_boundaries(){
        o("[i].Value.Matches(key)" % ω, "[i]ᖾ.Matches(key)");
        o("[i].ValueMatches(key)" % ω, "[i].ValueMatches(key)");
    }

    [Test] public void Nits(){
        o( ω.nits.Contains(ω.Rule(">=")) );
    }

    [Test] public void Op_Soft(){
        var Λ = !ω;
        That.Logger.Log(Λ);
    }

    [Test] public void Revert_class_rule(){
         o( "class Foo" / ω, "○ Foo" );
    }

    // TODO this test causes a conflict that should not be
    // happening.
    // [Test] public void Revert_WithBridgedToken()
    // => o("public static void Act()" / ω, "⃠ ┈ Act()");

    #if UNITY_EDITOR
    [Test] public void Revert_ConflictThrows(){
        if(Config.ι.ignoreConflicts){
            var ㄸ = "メ.Reach" / ω;
        }else
            Assert.Throws<InvOp>( () => { var ㄸ = "メ.Reach" / ω; } );
    }
    #endif
    
    // TODO when Howl imports this test file, escaped '"' causes
    // a conflict
    //[Test] public void Revert_NoConflictInEscapedBlocks(){
    //    var ㄸ = "\"メ.Reach\"" / ω;
    //}

}}
