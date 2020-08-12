using static That.GUI;
using S = Active.Howl.UIStrings.Main;

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
