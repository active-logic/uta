using System.Collections.Generic;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine; using UnityEditor;
using static UnityEngine.GUILayout;
using static UnityEditor.EditorStyles;
using static System.Environment;
using EGU = UnityEditor.EditorGUIUtility;
using EGL = UnityEditor.EditorGUILayout;
using ト = UnityEngine.Vector2; using ソ = UnityEngine.Vector2;
using C = Active.Howl.Config;
using S = Active.Howl.UIStrings;

namespace Active.Howl{
public class Window : EditorWindow{

    const ㄹ Github = "https://github.com/active-logic/howl";
    static Color lightGray = Color.white * 0.5f;
    ソ scrollPos;

    // --------------------------------------------------------------

    [MenuItem("Window/Activ/Howl")] static void Init()
    => ((Window)EditorWindow.GetWindow(typeof(Window))).Show();

    // --------------------------------------------------------------

    void OnGUI(){
        HeaderUI();
        ImportUI();
        ExportUI();
        ExportSnippetsUI();
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
        Badge("(╯°□°)╯ ⌒ $", $"{Github}/Support.md", -1);
        EndHorizontal();
        Space(8);
    }

    void ImportUI(){
        BeginHorizontal();
        if(Button(S.GenSource)) Import();
        C.allowImport     = Toggle(C.allowImport, S.EnableImp);
        C.ignoreConflicts = Toggle(C.ignoreConflicts, S.IgConflicts);
        EndHorizontal();
    }

    void ExportUI(){
        Section("Export...");
        C.allowExport = Toggle(C.allowExport, S.EnableExp);
        C.lockCsFiles = UpdateLockCsFiles();
    }

    void ExportSnippetsUI(){
        Section("Snippets (Atom editor)");
        BeginHorizontal();
        var atomPath = EditorPrefs.GetString("AtomPath", @"~/.atom");
        var w = EGU.labelWidth; EGU.labelWidth = 72;
        var ㄸ = EGL.TextField(".atom/ path", atomPath);
        EGU.labelWidth = w;
        if(ㄸ != atomPath) EditorPrefs.SetString("AtomPath", ㄸ);
        if(Button(S.GenSnippets, Width(96))) GenSnippets(atomPath);
        EndHorizontal();
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

    void Badge(ㄹ label, ㄹ ㄸ, ᆞ w = 24){
        ㅇ ㅂ = w > 0 ? Button(label, Width(24)) : Button(label);
        if(ㅂ) Application.OpenURL(ㄸ);
    }

    void GenSnippets(ㄹ path){
        ㄹ usr = GetFolderPath(SpecialFolder.Personal);
        path = path.Replace("~", usr);
        SnippetGen.ToUserSnippets(path + "/snippets.cson");
    }

    void Import(){
        if(C.allowImport) Howl.ImportDir("Assets/", verbose: true);
        else              Debug.LogWarning(S.UnlockToEnable);
    }

    void Ruler(int w = 2, int padding = 10){
        var r = EGL.GetControlRect(Height(padding + w));
        r.height = w; r.x -= 2; r.width += 6; r.y += padding/2;
        EditorGUI.DrawRect(r, lightGray);
    }

    void Section(ㄹ s){
        if(s == null) return; Space(8); Label(s, boldLabel);
    }

    ㅇ UpdateLockCsFiles(){
        ㅇ locked = C.lockCsFiles;
        ㅇ doLock = Toggle(locked, S.LockCsFiles);
        if(doLock != locked){
            Locker.Apply("Assets/", ".cs", doLock);
        }
        return doLock;
    }

}}
