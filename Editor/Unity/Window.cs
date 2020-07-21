using System.Collections.Generic;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine; using UnityEditor;
using static UnityEngine.GUILayout;
using static UnityEditor.EditorStyles;
using EGU = UnityEditor.EditorGUIUtility;
using ト = UnityEngine.Vector2; using ソ = UnityEngine.Vector2;
using C = Active.Howl.Config;
using S = Active.Howl.UIStrings;

namespace Active.Howl{
public class Window : EditorWindow{

    ソ scrollPos;

    [MenuItem("Window/Activ/Howl")] static void Init()
    => ((Window)EditorWindow.GetWindow(typeof(Window))).Show();

    void OnGUI(){
        Header("Howl");
        BeginHorizontal();
        // Import related
        if(Button(S.GenSource)) Import();
        C.allowImport     = Toggle(C.allowImport, S.EnableImp);
        C.ignoreConflicts = Toggle(C.ignoreConflicts, S.IgConflicts);
        EndHorizontal();
        // Export related
        Header("Export...");
        C.allowExport = Toggle(C.allowExport, S.EnableExp);
        C.lockCsFiles = UpdateLockCsFiles();
        ExportSnippetsUI();
        ImportConfigUI();
        DrawRuler();
    }

    void ImportConfigUI(){
        Header("Import config (C# → Howl)");
        Label("Symbols may look different in the editor",
              miniLabel);
        DrawRuler();
        ImportConfig.Read();
        scrollPos = BeginScrollView(scrollPos);
        ㅇ didChange = false;
        foreach(var k in Map.@default){
            var rule = k as Rep;
            if(!rule.import) continue;
            Header(rule.header);
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

    void ExportSnippetsUI(){
        Header("Snippets (Atom editor)");
        BeginHorizontal();
        var atomPath = EditorPrefs.GetString("AtomPath", @"~/.atom");
        var w = EGU.labelWidth; EGU.labelWidth = 72;
        var ㄸ = EditorGUILayout.TextField(".atom/ path", atomPath);
        EGU.labelWidth = w;
        if(ㄸ != atomPath) EditorPrefs.SetString("AtomPath", ㄸ);
        if(Button(S.GenSnippets, Width(96))) GenSnippets(atomPath);
        EndHorizontal();
    }

    // --------------------------------------------------------------

    void GenSnippets(ㄹ path){
        ㄹ usr = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
        path = path.Replace("~", usr);
        SnippetGen.ToUserSnippets(path + "/snippets.cson");
    }

    void Header(ㄹ s)
    { if(s == null) return; Space(8); Label(s, boldLabel); }

    void Import(){
        if(C.allowImport)
            Howl.ImportDir("Assets/", verbose: true);
        else
            Debug.LogWarning(S.UnlockToEnable);
    }

    public static void DrawRuler(int thickness = 2, int padding = 10)
    {
        Rect r = EditorGUILayout
                 .GetControlRect(GUILayout.Height(padding+thickness));
        r.height = thickness;
        r.y += padding/2;
        r.x -= 2; r.width += 6;
        EditorGUI.DrawRect(r, Color.gray);
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
