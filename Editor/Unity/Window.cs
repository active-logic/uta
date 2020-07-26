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
    => ((Window)EditorWindow.GetWindow(typeof(Window))).Show();

    void OnGUI(){
        HeaderUI();
        BeginHorizontal();
        ImportUI();
        Space(8);
        ExportUI();
        EndHorizontal();
        SnippetsUI.UI();
        SymSelect.UI();
    }

    // --------------------------------------------------------------

    void HeaderUI(){
        Space(4);
        BeginHorizontal();
        Section("HOWL");
        FlexibleSpace();
        Badge("D", "https://discord.gg/qTbhRmB",
                                        bg: DiscordColor, fg: white);
        Badge("G", $"{Github}", bg: black, fg: white);
        Badge("?", $"{Github}/blob/master/README.md",
                                               bg: black, fg: white);
        Badge("(╯°□°)╯ ⌒ $", $"{Github}/blob/master/Support.md", -1,
                                                 bg: red, fg: white);
        EndHorizontal();
        Space(4);
    }

    void ImportUI(){
        BeginVertical();
        Section("Import (C# → Howl)");
        if(Button(S.GenSource)) Import();
        BeginHorizontal();
        C.allowImport     = Toggle(C.allowImport, S.EnableImp);
        C.ignoreConflicts = Toggle(C.ignoreConflicts, S.IgConflicts);
        EndHorizontal();
        EndVertical();
    }

    void ExportUI(){
        BeginVertical();
        Section("Export (Howl → C#)");
        C.allowExport = Toggle(C.allowExport, S.EnableExp);
        EndVertical();
    }

    // ==============================================================

    void Import(){
        if(C.allowImport) Howl.ImportDir("Assets/", verbose: true);
        else              Debug.LogWarning(S.UnlockToEnable);
    }

}}
