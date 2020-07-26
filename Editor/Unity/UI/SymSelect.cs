using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
//
using static UnityEngine.GUILayout;
using static UnityEditor.EditorStyles;
using ソ = UnityEngine.Vector2;
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
        scrollPos = BeginScrollView(scrollPos);
        //
        ImportConfig.Read();
        ㅇ dirty = false;
        foreach(var k in Map.@default){
            ItemUI(k as Rep, ref dirty);
        }
        if(dirty) ImportConfig.Write();
        //
        EndScrollView();
    }

    static void ItemUI(Rep ρ, ref ㅇ dirty){
        if(Skip(ρ)) return;
        Section(ρ.header);
        BeginHorizontal();
        ㅇ flag = Toggle(ρ.@sel, ~ρ, Width(60));
        dirty |= ρ.@sel != flag;
        ρ.@sel = flag;
        Label(ρ.name);
        EndHorizontal();
    }

    static ㅇ Skip(Rep ρ) => !ρ.import && ρ.noSnippet;

}}
