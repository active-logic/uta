using System.Collections.Generic;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine; using UnityEditor;
using static UnityEngine.GUILayout;
using static UnityEditor.EditorStyles;
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
        // Import config
        Header("Import config (C# → Howl)");
        Label("Symbols may look different in the editor",
              miniLabel);
        DrawRuler();
        //Space(5);
        ImportConfigUI();

    }

    void ImportConfigUI(){
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
