using UnityEngine; using UnityEditor; using static UnityEngine.GUILayout;
using static Active.Howl.UI.Widgets; using Active.Howl.Transitional;

namespace Active.Howl.UI{
public class ToolsWindow : EditorWindow{

    [MenuItem("Window/Activ/Howl Utils")] static void Init()
    => EditorWindow.GetWindow<ToolsWindow>("Howl Utils").Show();

    void OnGUI(){
        FlexibleSpace();
        H(
            B("Inject grammar template", InjectGrammarTemplate),
            B("Clean C# Source", Cleaner.Clean)
        );
        FlexibleSpace();
    }

    void InjectGrammarTemplate(){
        Debug.Log("Inject gram");
        var root = "~/Documents/tree-sitter-howl".Expand();
        var @in  = $"{root}/grammar.template.js";
        var @out = $"{root}/grammar.js";
        @out.Write(TreeSitter.Inject(@in.Read(), Map.@default));
    }

}}
