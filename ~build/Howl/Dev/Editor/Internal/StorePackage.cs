using UnityEditor;

namespace Active.Howl.Util{
[InitializeOnLoad] static class StorePackage{

    static StorePackage () => Active.Howl.UI.ToolsWindow.pkgPrep = Prep;

    internal static void Prep(){
        bool dry = false;
        var ρ = "../UAS/Howl-2018";
        var ㄸ = $"{ρ}/Assets/Howl";
        log.message = "Preparing asset store package";
        //
        $"{ρ}/Howl.cfg".Delete(withMetaFile: true);
        ㄸ.RmDir(withMetaFile: true, dry: dry);
        "Assets/Howl/~build/Howl/Runtime"
            .CopyFiles($"{ㄸ}/Runtime",
                       relTo: "Assets/Howl/~build/Howl/Runtime",
                       mkdir: true, dry: dry, "*.cs");
       "Assets/Howl/~build/Howl/Editor"
            .CopyFiles($"{ㄸ}/Editor",
                       relTo: "Assets/Howl/~build/Howl/Editor",
                       mkdir: true, dry: dry, "*.cs");
        "Assets/Howl/Demo"
            .CopyFiles($"{ㄸ}/Demo",
                       relTo: "Assets/Howl/Demo",
                       mkdir: true, dry: dry, "*.*");
        "Assets/Howl/Z"
            .CopyFiles($"{ㄸ}/Z",
                       relTo: "Assets/Howl/Z",
                       mkdir: true, dry: dry, "*.*");
        "Assets/Howl/Readme.txt"
            .CopyTo($"{ㄸ}/Readme.txt", mkdir: true, dry: dry);
        "Assets/Howl/LICENSE"
            .CopyTo($"{ㄸ}/LICENSE", mkdir: true, dry: dry);
        "Assets/Howl/package.json"
            .CopyTo($"{ㄸ}/package.json", mkdir: true, dry: dry);
    }

}}
