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

    static Ed atom = new Atom(), vscode = new VSCode();

    public static bool UI(){
        Section("Snippets");
        BeginHorizontal();
        if(atom.Exists())   TargetUI(atom);
        if(vscode.Exists()) TargetUI(vscode);
        FlexibleSpace();
        EndHorizontal();
        Space(8);
        return true;
    }

    static void TargetUI(Ed ed){
        if (!ed.Exists()) return ;
        Label(ed.Name());
        if (Button(S.MakeSnippets  , Width(50)))
            ed.GenUserSnippets(dry: false);
    }

}}
