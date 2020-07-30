//
using static UnityEngine.GUILayout;
using static UnityEditor.EditorStyles;
using ソ = UnityEngine.Vector2;
//
using static Active.Howl.UI.Widgets;
using S = Active.Howl.UIStrings;

namespace Active.Howl.UI{
internal class SymSelectUI{

    static ソ scrollPos;

    internal static void UI(){
        Section(S.ImportConfig);
        Label(S.NotWYSIWYG, miniLabel);
        Ruler();
        scrollPos = BeginScrollView(scrollPos);
        //
        ImportConfig.Read();
        bool dirty = false;
        foreach(var k in Map.@default){
            ItemUI(k as Rep, ref dirty);
        }
        if(dirty) ImportConfig.Write();
        //
        EndScrollView();
    }

    static void ItemUI(Rep ρ, ref bool dirty){
        if(Skip(ρ)) return;
        Section(ρ.header);
        BeginHorizontal();
        bool flag = Toggle(ρ.@sel, ~ρ, Width(60));
        dirty |= ρ.@sel != flag;
        ρ.@sel = flag;
        Label(ρ.name);
        EndHorizontal();
    }

    static bool Skip(Rep ρ) => !ρ.import && ρ.noSnippet;

}}
