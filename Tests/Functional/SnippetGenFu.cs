using System.IO;
using UnityEngine;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

public class SnippetGenFu : TestBase{

    [Test] public void GenSnippets(){
        ㄹ ㅂ = "Assets/Howl/Extras/cs-snippets.cson";
        ㄹ ㄸ = "Assets/Howl/Extras/howl-snippets.cson";
        SnippetGen.Generate(ㅂ, ㄸ);
        ㄹ[] Λ = ㄸ.ReadLines();
        o( Λ[ 3], "    'body': '☋ '" );
        // NOTE: after translating each '\n' becomes '\\n';
        // apparently harmless.
        o( Λ[27], "    'body': '🍘$1\\n{\\n\\t$0\\n}'" );
    }
    
}
