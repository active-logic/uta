using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

using UnityEngine; using UnityEditor;
using static UnityEngine.GUILayout;

namespace Active.Howl{
public class Window : EditorWindow{

    [MenuItem("Window/Howl")] static void Init()
    => ((Window)EditorWindow.GetWindow(typeof(Window))).Show();

    void OnGUI(){
        Label("Howl", EditorStyles.boldLabel);
        if(Button("Generate Howl source")) Howl.ImportDir("Assets/");
    }

}}
