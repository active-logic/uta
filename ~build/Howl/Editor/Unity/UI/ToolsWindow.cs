# if DEV_MODE

using UnityEngine; using UnityEditor; using static UnityEngine.GUILayout;
using static That.GUI;
using Active.Howl.Transitional;
using Active.Howl.Util;

namespace Active.Howl.UI{
public class ToolsWindow : EditorWindow{

    [MenuItem(S.Menu)] static void Init() => W<ToolsWindow>(S.Title).Show();

    bool OnGUI () => V(
        B(S.Inject, TreeSitter.Inject),
        B(S.Clean, Cleaner.Clean),
        B(S.GenSpec, TableGen.Create));

    class S{
        internal const string Title    = "Howl Utils";
        internal const string Menu     = "Window/Activ/Howl Utils";
        internal const string Inject   = "Inject grammar template";
        internal const string Clean    = "Clean C# source";
        internal const string GenSpec  = "Generate Specification";
    }

}}

#endif
