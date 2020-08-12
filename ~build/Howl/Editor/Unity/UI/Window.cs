using UnityEngine; using UnityEditor; using static UnityEngine.Color; using static That.GUI;
using S = Active.Howl.UIStrings.Main;

namespace Active.Howl.UI {
public class Window : EditorWindow{

    static Color DiscordColor = new Color(0.16f, 0.37f, 0.90f);

    [MenuItem("Window/Activ/Howl")]
    static void Init () => EditorWindow.GetWindow<Window>("HOWL").Show();

    bool OnGUI () => HeaderUI() && ( Onboarding.UI() || Settings() );

    bool Settings
    () => DevUI() && ImportUI() && ExportUI() && IDEs.UI() && Symset.UI();

    bool HeaderUI
       () => Br(4)
       && H( Hd("HOWL"), repoSize, flex,
            Badge("D", S.Discord, bg: DiscordColor, fg: white),
            Badge("G", S.Github, bg: black, fg: white),
            Badge("?", S.Documentation, bg: black, fg: white),
            Badge ("(╯°□°)╯ ⌒ $", S.Support, -1, bg: red, fg: white) )
       && Hr(padding: 3, count: 3);

    bool DevUI
       () => H( Hd(S.H_Develop), flex, Tg(S.ShowTips, ref cg.showTips))
       && H( B(S.Btn_Refresh, Howl.Refresh),
            B(S.Btn_Rebuild, Howl.Rebuild), flex )
       && Tip(S.DevInfo)
       && Br(4);

    bool ImportUI
       () => H(Hd(S.H_Import), flex, Tg(S.EnableImp, ref cg.allowImport))
       && Br(4)
       && when(cg.allowImport)[
           H( B(S.Btn_ImportAll, Howl.ImportAll), Br(),
               Tg(S.IgConflicts, ref cg.ignoreConflicts), flex), Br()]
       && Tip(S.ImportAllNotice)
       && Br(4);

    bool ExportUI
       () => H(Hd(S.H_Export), flex, Tg(S.EnableExp, ref cg.allowExport))
       && Br(4)
       && when(cg.allowExport)[
           H( B(S.Btn_ExportAll, Howl.ExportAll), flex )]
       && Tip(S.ExportAllNotice);

    bool Tip(string text) => cg.showTips ? P(text) : true;

    // --------------------------------------------------------------

    bool repoSize => P($"{(float)locCache:#,0} loc [{fmtDeltaLoc}]");

    string fmtDeltaLoc{
        get{
            int δ = locCache - Config.ι.linesOfCode;
            return δ == 0 ? "" : δ > 0 ? $"+ {δ}" : $"- {-δ}";
        }
    }

    Cache<int> locCache = new Cache<int>( () => Stats.loc, 1000);

    Config cg => Config.ι;

}}
