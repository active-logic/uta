namespace Active.Howl.Util{
static class StorePackage{

    internal static void Prep(){
        bool dry = false;
        var ㄸ = "../UAS/Howl-2018/Assets/Howl";
        log.message = "Preparing asset store package";
        //
        $"{ㄸ}/../~build".RmDir(withMetaFile: true);
        ㄸ.RmDir(withMetaFile: true);
        //
        "Assets/Howl/~build/Howl/Runtime"
            .CopyFiles($"{ㄸ}/Runtime",
                       relTo: "Assets/Howl/~build/Howl/Runtime",
                       mkdir: true, dry: dry, "*.cs");
       "Assets/Howl/~build/Howl/Editor"
            .CopyFiles($"{ㄸ}/Editor",
                       relTo: "Assets/Howl/~build/Howl/Editor",
                       mkdir: true, dry: dry, "*.cs");
        "Assets/Howl/~build/Howl/Demo"
                .CopyFiles($"{ㄸ}/../~build/Howl/Demo",
                       relTo: "Assets/Howl/~build/Howl/Demo",
                       mkdir: true, dry: dry, "*.*");
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
        "Assets/Howl/package.json"
            .CopyTo($"{ㄸ}/package.json", mkdir: true, dry: dry);
    }

}}
