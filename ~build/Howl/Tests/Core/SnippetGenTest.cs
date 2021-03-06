using System.IO;
using UnityEngine;
using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class SnippetGenTest : TestBase{

    Rep UsingRule = ("♘", "using static");

    const string AutoSnippetsPath
             = "Assets/Howl/Extras/howl-snippets-auto.cson";

    [Test] public void Create(){
        var ㄸ = SnippetGen.Create();
        o( ㄸ[0].name, "Using");
        o( ㄸ[0].prefix, "using");
        o( ㄸ[0].body, "⊐ ");
        o( ㄸ.Length > 100);
    }

    [Test] public void Create_WithExclusions(){
        var map = Map.@default;
        map.Rule("that").sel = false;
        var ㄸ = SnippetGen.Create();
        foreach(var k in ㄸ)
            o(k.prefix.Contains("that"), false);
    }

    [Test] public void Name()
    => o( SnippetGen.Name(UsingRule), "Using static" );

    [Test] public void Prefix()
    => o( SnippetGen.Prefix(UsingRule), "usings" );

    [Test] public void Body_()
    => o( SnippetGen.Body(UsingRule), "♘ " );

    // TODO broken test
    /*
    [Test] public void TranslateSnippets(){
        string ㅂ = "Assets/Howl/Extras/cs-snippets.cson";
        string ㄸ = "Assets/Howl/Extras/howl-snippets.cson";
        SnippetGen.Export(ㅂ, ㄸ);
        string[] Λ = ㄸ.ReadLines();
        o( Λ[ 3], "    'body': 'ᴬ '" );
        // NOTE: after translating each '\n' becomes '\\n';
        // apparently harmless.
        o( Λ[27], "    'body': '○$1\\n{\\n\\t$0\\n}'" );
    }*/

    [Test] public void Prefix_Explicit(){
        var ρ = ("(ɔ˘з˘)ɔ", "catch", name: "Got U", px: "got");
        o( SnippetGen.Prefix(ρ), "got");
    }

    [Test] public void Prefix_AutoFromName1(){
        var ρ = new Rep("☰", "==", bridge: true, name: "Eq");
        o( SnippetGen.Prefix(ρ), "eq");
    }

    [Test] public void Prefix_AutoFromName2(){
        var ρ = new Rep("→", "=>", bridge: true, name: "As (=>)");
        o( SnippetGen.Prefix(ρ), "as");
    }

    [Test] public void Body_Explicit(){
        var ρ = ("𝑎", "Action") * Body.B("𝑎<${0:T}>");
        o( SnippetGen.Body(-ρ), "𝑎<${0:T}>");
    }

    [Test] public void Body_SpacingControl(){
        var ρ = new Rep("⤴", "if");
        o( SnippetGen.Body(ρ), "⤴ ");
        o( SnippetGen.Body(-ρ), "⤴");
    }

    [Test] public void ToPrefix(){
        o( SnippetGen.ToPrefix("  using"), "using");
        o( SnippetGen.ToPrefix("using"), "using");
        o( SnippetGen.ToPrefix("using static"), "usings");
        o( SnippetGen.ToPrefix(" \nusing static"), "usings");
    }

}}
