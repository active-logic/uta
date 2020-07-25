using System.Collections.Generic;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine; using UnityEditor;
using static UnityEngine.GUILayout;
using static UnityEditor.EditorStyles;
using EGU = UnityEditor.EditorGUIUtility;
using EGL = UnityEditor.EditorGUILayout;
using ト = UnityEngine.Vector2; using ソ = UnityEngine.Vector2;
using C = Active.Howl.Config;
using S = Active.Howl.UIStrings;

namespace Active.Howl{
public class Window : EditorWindow{

    const ㄹ Github = "https://github.com/active-logic/howl";
    const ㄹ AssetStore = "https://assetstore.unity.com/packages";
    static Color lightGray = Color.white * 0.5f;
    ソ scrollPos;

    // --------------------------------------------------------------

    [MenuItem("Window/Activ/Howl")] static void Init()
    => ((Window)EditorWindow.GetWindow(typeof(Window))).Show();

    // --------------------------------------------------------------

    void OnGUI(){
        HeaderUI();
        BeginHorizontal();
        ImportUI();
        Space(8);
        ExportUI();
        EndHorizontal();
        SnippetsUI.UI();
        ImportConfigUI();
    }

    // --------------------------------------------------------------

    void HeaderUI(){
        Space(4);
        BeginHorizontal();
        Section("HOWL");
        FlexibleSpace();
        Badge("D", "https://discord.gg/qTbhRmB");
        Badge("G", $"{Github}");
        Badge("?", $"{Github}/blob/master/README.md");
        Badge("(╯°□°)╯ ⌒ $", $"{Github}/blob/master/Support.md", -1);
        EndHorizontal();
        Space(4);
    }

    void ImportUI(){
        BeginVertical();
        Section("Import (C# → Howl)");
        //BeginH();
        if(Button(S.GenSource)) Import();
        BeginHorizontal();
        C.allowImport     = Toggle(C.allowImport, S.EnableImp);
        C.ignoreConflicts = Toggle(C.ignoreConflicts, S.IgConflicts);
        EndHorizontal();
        //EndHorizontal();
        EndVertical();
    }

    void ExportUI(){
        BeginVertical();
        Section("Export (Howl → C#)");
        C.allowExport = Toggle(C.allowExport, S.EnableExp);
        EndVertical();
    }

    void ImportConfigUI(){
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

    // ==============================================================

    static void Badge(ㄹ label, ㄹ ㄸ, ᆞ w = 24){
        ㅇ ㅂ = w > 0 ? Button(label, Width(24)) : Button(label);
        if(ㅂ) Application.OpenURL(ㄸ);
    }

    void Import(){
        if(C.allowImport) Howl.ImportDir("Assets/", verbose: true);
        else              Debug.LogWarning(S.UnlockToEnable);
    }

    static void LinkToAL(ㄹ header){
        BeginHorizontal();
        BeginVertical();
        Label(header, boldLabel);
        Label("Behavior Tree Library for C# 7",
              miniLabel);
        EndVertical();
        FlexibleSpace();
        Badge("GET!",
              $"{AssetStore}/tools/ai/active-logic-151850", -1);
        EndHorizontal();
    }

    void Ruler(int w = 2, int padding = 10){
        var r = EGL.GetControlRect(Height(padding + w));
        r.height = w; r.x -= 2; r.width += 6; r.y += padding/2;
        EditorGUI.DrawRect(r, lightGray);
    }

    public static void Section(ㄹ s){
        if(s == null) return;
        Space(8);
        if(s == "Active Logic") LinkToAL(s);
        else                    Label(s, boldLabel);
    }

}}
