using UnityEngine; using UnityEditor;
using static UnityEngine.GUILayout;
using static UnityEngine.Color;
using EGU = UnityEditor.EditorGUIUtility;
using EGL = UnityEditor.EditorGUILayout;
using static Active.Howl.UI.Widgets;
using C = Active.Howl.Config;
using S = Active.Howl.UIStrings;
using static UnityEditor.EditorStyles;
using static That.GUI;

namespace Active.Howl.UI {
public class Window : EditorWindow{

    static Color DiscordColor = new Color(0.16f, 0.37f, 0.90f);

    [MenuItem("Window/Activ/Howl")]
    static void Init () => EditorWindow.GetWindow<Window>("HOWL").Show();

    bool OnGUI () => HeaderUI() && ( Onboarding.UI() || Settings() );

    bool Settings () => DevUI() && ImportUI() && ExportUI() && SnippetsUI.UI()
                  && SymSelectUI.UI();

    bool HeaderUI
       () => Br(4)
       && H( Hd("HOWL"), flex,
            Badge("D", S.Discord, bg: DiscordColor, fg: white),
            Badge("G", S.Github, bg: black, fg: white),
            Badge("?", S.Documentation, bg: black, fg: white),
            Badge ("(╯°□°)╯ ⌒ $", S.Support, -1, bg: red, fg: white) )
       && Hr(padding: 3, count: 3);

    bool DevUI
       () => H( Hd(S.H_Develop), flex, Tg(S.ShowTips, ref cg.showTips))
       && H( B(S.Refresh, Howl.Refresh),
            B(S.Rebuild, Howl.Rebuild), flex )
       && Tip(S.DevInfo) //∧ Br(4)
       //∧ H(B(S.Btn_ApplyNotation, Howl.ReApply), flex)
       //∧ P(S.ApplyNotationNotice)
       && Br(4);

    bool ImportUI
       () => H(Hd(S.H_Import), flex, Tg(S.EnableImp, ref cg.allowImport))
       && Br(4)
       && when(cg.allowImport)[
           H( B(S.ImportAll, Howl.Import), Br(),
               Tg(S.IgConflicts, ref cg.ignoreConflicts), flex), Br()]
       && Tip(S.ImportAllNotice)
       && Br(4);

    bool ExportUI
       () => H(Hd(S.H_Export), flex, Tg(S.EnableExp, ref cg.allowExport))
       && Br(4)
       && when(cg.allowExport)[
           H( B(S.Btn_ExportAll, Howl.Export), flex )]
       && Tip(S.ExportAllNotice);

    bool Tip(string text) => cg.showTips ? P(text) : true;

    // --------------------------------------------------------------

    Config cg => Config.ι;

}}
