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
        ImportUI();
        ExportUI();
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
        Ruler(padding: 3);
        Ruler(padding: 3);
        Ruler(padding: 3);
        Space(6);
        return true;
    }

    void ImportUI() {
        BeginHorizontal();
        Section("Import (C# => Howl)");
        FlexibleSpace();
        Config.ι.allowImport
            = Toggle(Config.ι.allowImport, S.EnableImp);
        EndHorizontal();
        Space(4);
        //
        EditorGUI.BeginDisabledGroup(!Config.ι.allowImport);
        BeginHorizontal();
        if(Button(S.GenSource)) Import();
        Space(8);
        Config.ι.ignoreConflicts
            = Toggle(Config.ι.ignoreConflicts, S.IgConflicts);
        FlexibleSpace();
        EndHorizontal();
        Space(8);
        EditorGUI.EndDisabledGroup();
    }

    void ExportUI(){
        BeginHorizontal();
        Section("Export (Howl => C#)");
        FlexibleSpace();
        Config.ι.allowExport
            = Toggle(Config.ι.allowExport, S.EnableExp);
        EndHorizontal();
        Space(4);
        //
        EditorGUI.BeginDisabledGroup(!Config.ι.allowExport);
        BeginHorizontal();
        if(Button(S.Rebuild)) Rebuild();
        FlexibleSpace();
        EndHorizontal();
        EditorGUI.EndDisabledGroup();
    }

    // --------------------------------------------------------------

    // TODO
    void Rebuild(){}

    void Import() => Howl.ImportDir("Assets/", verbose: true);

}}
