using static System.Environment;
using UnityEditor; using UnityEngine;
using static UnityEngine.GUILayout;
using EGU = UnityEditor.EditorGUIUtility;
using EGL = UnityEditor.EditorGUILayout;
using S = Active.Howl.UIStrings;
using static Active.Howl.SnippetGen;
using static Active.Howl.UI.Widgets;

namespace Active.Howl.UI{
public static class SnippetsUI{

    public static void UI(){
        Section("Snippets");
        TargetUI(new Atom());
        TargetUI(new VSCode());
    }

    static void TargetUI(Ed ed){
        BeginHorizontal();
        //
        string ㅂ = ed.UserSnippetsPath(expand: false);
        float w = EGU.labelWidth; EGU.labelWidth = 56;
        string ㄸ = EGL.TextField(ed.Name(), ㅂ);
        EGU.labelWidth = w;
        //
        if(ㄸ != ㅂ) ed.SetUserSnippetsPath(ㄸ);
        if(Button(S.MakeSnippets  , Width(50)))
                                    ed.GenUserSnippets(dry: false);
        EndHorizontal();
    }

}}
