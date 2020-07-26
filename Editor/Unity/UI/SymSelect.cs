using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
//
using static UnityEngine.GUILayout;
using static UnityEditor.EditorStyles;
using ト = UnityEngine.Vector2; using ソ = UnityEngine.Vector2;
//
using static Active.Howl.UI.Widgets;
using S = Active.Howl.UIStrings;

namespace Active.Howl.UI{
internal class SymSelect{

    static ソ scrollPos;

    internal static void UI(){
        Section(S.ImportConfig);
        Label(S.NotWYSIWYG, miniLabel);
        Ruler();
        ImportConfig.Read();
        scrollPos = BeginScrollView(scrollPos);
        ㅇ didChange = false;
        foreach(var k in Map.@default){
            var rule = k as Rep;
            if(!rule.import) continue;
            Section(rule.header);
            BeginHorizontal();
            ㅇ flag = Toggle(rule.@sel, ~rule, Width(60));
            didChange |= rule.@sel != flag;
            rule.@sel = flag;
            Label(rule.b);
            EndHorizontal();
        }
        EndScrollView();
        if(didChange) ImportConfig.Write();
    }

}}
