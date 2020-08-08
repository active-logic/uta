/*
⊐̥ System.Environment;
⊐ UnityEditor; ⊐ UnityEngine;
⊐̥ UnityEngine.GUILayout;
⊐ EGU = UnityEditor.EditorGUIUtility;
⊐ EGL = UnityEditor.EditorGUILayout;
⊐̥ Active.Howl.SnippetGen;
⊐̥ Active.Howl.UI.Widgets;
*/
using static That.GUI;
using S = Active.Howl.UIStrings;

namespace Active.Howl.UI{
public static class IDEs{

    static Ed atom = new Atom(), vscode = new VSCode();

    public static bool UI
        () => Hd("Code Editors")
        && EditorUI(atom)
        && EditorUI(vscode)
        && Br();

    static bool EditorUI(Ed ed){
        if (!ed.Exists()) return true;
        else
        return H( P(ed.Name()),
              B(S.MakeSnippets, () => ed.GenUserSnippets(dry:false)),
              ed.CanHideBuildDir() ?
                Tg("Hide build dir", ed.HideBuildDir,
                   ed.IsBuildDirHidden) : true,
              flex);
    }

}}
