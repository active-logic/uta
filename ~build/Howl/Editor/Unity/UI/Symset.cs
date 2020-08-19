using UnityEngine; using static UnityEngine.GUILayout; using static UnityEditor.EditorStyles;
using static Active.Howl.UI.Widgets;
using S = Active.Howl.UIStrings.Main;

namespace Active.Howl.UI{
internal class Symset {

    static Vector2 scrollPos;

    internal static bool UI(){
        BeginHorizontal();
        Section(S.SymsetConfig, bottom: 0);
        FlexibleSpace();
        if (Button(S.Btn_ApplyNotation)) Howl.ReApply();
        EndHorizontal();
        if (Config.ι.showTips)Label(S.SymsetNote);
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
        return true;
    }

    static void ItemUI(Rep ρ, ref bool dirty){
        if(Skip(ρ)) return;
        Section(ρ.header);
        BeginHorizontal();
        var  style = toggle;
        style.richText = true;
        bool flag = Toggle(ρ.@sel, ρ.alt != null
                                ? $"<color=brown>{ρ.alt}</color>"
                                : ρ.a, Width(60)
                                /*, EditorStyles.richText */ );
        dirty |= ρ.@sel != flag;
        ρ.@sel = flag;
        Label(ρ.name);
        EndHorizontal();
    }

    static bool Skip(Rep ρ) => !ρ.import && ρ.noSnippet;

}}
