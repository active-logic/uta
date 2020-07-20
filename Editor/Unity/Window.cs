using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine; using UnityEditor;
using static UnityEngine.GUILayout;
using C = Active.Howl.Config;
using S = Active.Howl.UIStrings;

namespace Active.Howl{
public class Window : EditorWindow{

    [MenuItem("Window/Activ/Howl")] static void Init()
    => ((Window)EditorWindow.GetWindow(typeof(Window))).Show();

    void OnGUI(){
        Label("Howl", EditorStyles.boldLabel);
        BeginHorizontal();
        // Import related
        if(Button(S.GenSource)) Import();
        C.allowImport     = Toggle(C.allowImport, S.EnableImp);
        C.ignoreConflicts = Toggle(C.ignoreConflicts, S.IgConflicts);
        EndHorizontal();
        // Export related
        C.allowExport = Toggle(C.allowExport, S.EnableExp);
        C.lockCsFiles = UpdateLockCsFiles();
    }

    void Import(){
        if(C.allowImport)
            Howl.ImportDir("Assets/", verbose: true);
        else
            Debug.LogWarning(S.UnlockToEnable);
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
