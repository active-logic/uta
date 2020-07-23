using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using static System.Environment;
using UnityEditor; using UnityEngine;
using static UnityEngine.GUILayout;
using EGU = UnityEditor.EditorGUIUtility;
using EGL = UnityEditor.EditorGUILayout;
using static Active.Howl.Window; using static Active.Howl.SnippetGen;
using S = Active.Howl.UIStrings;

namespace Active.Howl{
public static class SnippetsUI{

    public static void UI(){
        Section("Snippets");
        TargetUI(new Atom());
        TargetUI(new VSCode());
    }

    static void TargetUI(Ed ed){
        BeginHorizontal();
        //
        ㄹ ㅂ = ed.UserSnippetsPath(expand: false);
        ㅅ w = EGU.labelWidth; EGU.labelWidth = 56;
        ㄹ ㄸ = EGL.TextField(ed.Name(), ㅂ);
        EGU.labelWidth = w;
        //
        if(ㄸ != ㅂ) ed.SetUserSnippetsPath(ㄸ);
        if(Button(S.MakeSnippets  , Width(50)))
            ed.GenUserSnippets(dry: false);
        if(Button(S.RemoveSnippets, Width(50))) ed.RemUserSnippets();
        EndHorizontal();
    }

}}