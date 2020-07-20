using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine; using UnityEditor;
using static UnityEngine.GUILayout;

namespace Active.Howl{
public class Window : EditorWindow{

    [MenuItem("Window/Activ/Howl")] static void Init()
    => ((Window)EditorWindow.GetWindow(typeof(Window))).Show();

    void OnGUI(){
        Label("Howl", EditorStyles.boldLabel);
        BeginHorizontal();
        if(Button("Generate Howl source")){
            if(Config.allowImport) Howl.ImportDir("Assets/");
            else Debug.LogWarning("Unlock to enable (C# → Howl)");
        }
        Config.allowImport = !Toggle(!Config.allowImport, "lock");
        EndHorizontal();
        Config.allowExport = Toggle(Config.allowExport,
                                    "Enable export (Howl → C#)");
        Config.lockCsFiles = UpdateLockCsFiles();
    }

    ㅇ UpdateLockCsFiles(){
        ㅇ locked = Config.lockCsFiles;
        ㅇ doLock = Toggle(locked, "Lock C# files");
        if(doLock != locked){
            Locker.Apply("Assets/", ".cs", doLock);
        }
        return doLock;
    }

}}
