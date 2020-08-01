using UnityEngine; using UnityEditor;
using static UnityEngine.GUILayout;
using static UnityEngine.Color;
using EGU = UnityEditor.EditorGUIUtility;
using EGL = UnityEditor.EditorGUILayout;
using static Active.Howl.UI.Widgets;
using C = Active.Howl.Config;
using S = Active.Howl.UIStrings;

namespace Active.Howl.UI{
public class Window : EditorWindow{

    static Color DiscordColor = new Color(0.16f, 0.37f, 0.90f);
    const string Github = "https://github.com/active-logic/howl";

    // --------------------------------------------------------------

    [MenuItem("Window/Activ/Howl")] static void Init()
    => EditorWindow.GetWindow<Window>("HOWL").Show();

    bool OnGUI() => HeaderUI() && Onboarding.UI() || Settings();

    bool Settings(){

        BeginHorizontal();
         ImportUI(); Space(8); ExportUI();
        EndHorizontal();
        SnippetsUI.UI();
        SymSelectUI.UI();
        return true;
    }

    // --------------------------------------------------------------

    bool HeaderUI(){
        Space(4);
        BeginHorizontal();
        Section("HOWL");
        FlexibleSpace();
        Badge("D", "https://discord.gg/qTbhRmB",
                                        bg: DiscordColor, fg: white);
        Badge("G", $"{Github}", bg: black, fg: white);
        Badge("?", $"{Github}/blob/master/README.md",
                                               bg: black, fg: white);
        Badge ("(╯°□°)╯ ⌒ $", $"{Github}/blob/master/Support.md", -1,
                                                 bg: red, fg: white);
        EndHorizontal();
        Space(4);
        return true;
    }

    void ImportUI() {
        BeginVertical ();
        Section( "Import (C# => Howl)");
        if(Button(S.GenSource)) Import();
        BeginHorizontal();
        Config.ι.allowImport
            = Toggle(Config.ι.allowImport, S.EnableImp);
        Config.ι.ignoreConflicts
            = Toggle(Config.ι.ignoreConflicts, S.IgConflicts);
        EndHorizontal();
        EndVertical();
    }

    void ExportUI(){
        BeginVertical();
        Section("Export (Howl => C#)");
        Config.ι.allowExport
            = Toggle(Config.ι.allowExport, S.EnableExp);
        EndVertical();
    }

    // ==============================================================

    void Import(){
        if(Config.ι.allowImport) Howl.ImportDir("Assets/", verbose: true);
        else              Debug.LogWarning(S.UnlockToEnable);
    }

    // ==============================================================

}}
