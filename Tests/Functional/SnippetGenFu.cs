using System.IO;
using UnityEngine;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

namespace Functional{
public class SnippetGenFu : TestBase{

    const ㄹ AutoSnippetsPath
             = "Assets/Howl/Extras/howl-snippets-auto.cson";

    [Test] public void TranslateSnippets(){
        ㄹ ㅂ = "Assets/Howl/Extras/cs-snippets.cson";
        ㄹ ㄸ = "Assets/Howl/Extras/howl-snippets.cson";
        SnippetGen.Export(ㅂ, ㄸ);
        ㄹ[] Λ = ㄸ.ReadLines();
        o( Λ[ 3], "    'body': '☋ '" );
        // NOTE: after translating each '\n' becomes '\\n';
        // apparently harmless.
        o( Λ[27], "    'body': '🍘$1\\n{\\n\\t$0\\n}'" );
    }

    [Test] public void GenSnippets(){
        ㄹ ㄸ = AutoSnippetsPath;
        SnippetGen.Generate(ㄸ);
        ㄹ[] Λ = ㄸ.ReadLines();
        o( Λ[ 0], "  'Using static':" );
        o( Λ[ 1], "    'prefix': 'usings'" );
        o( Λ[ 2], "    'body': '♘ '" );
        // Explicitly disabled rule example
        o( ㄸ.Read().Contains(">()"), false);
        // Explicitly named snippet example
        o( ㄸ.Read().Contains("Point"), true);
    }

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

    [Test] public void SnippetBody(){
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
