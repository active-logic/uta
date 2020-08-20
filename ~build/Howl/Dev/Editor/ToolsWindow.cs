# if DEV_MODE  // For Github/UPM users, not UAS

using UnityEngine; using UnityEditor; using static That.GUI;
using Active.Howl.Transitional; using Active.Howl.Util; using Active.Howl.Test;

namespace Active.Howl.UI{
public class ToolsWindow : EditorWindow{

    public static System.Action pkgPrep;

    [MenuItem(S.Menu)] static void Init() => W<ToolsWindow>(S.Title).Show();

    bool OnGUI () => V(
        Hd("Grammar"),
        B(S.Inject, TreeSitter.Inject),
        B(S.GenSpec, TableGen.Create),
        GiveBackMon.UI(),
        Hd("Misc."),
        @if(pkgPrep != null)?[ B(S.PrepPkg, pkgPrep) ],
        when(false)[ B(S.Clean, Cleaner.Clean) ]
    );

    class S{
        internal const string Title    = "Howl Utils";
        internal const string Menu     = "Window/Activ/Howl Utils";
        internal const string Inject   = "Inject grammar.js";
        internal const string Clean    = "Clean C# source";
        internal const string PrepPkg  = "Update store package";
        internal const string GenSpec  = "Generate Specification";
    }

}}

#endif
