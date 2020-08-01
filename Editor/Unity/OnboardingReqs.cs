using FS = Active.Howl.FileSystem;

namespace Active.Howl{

public interface IOnboardingReqs {

    bool HasIDE(); bool HasExt(); bool HasRoot(); bool MayImport();
    bool HasVCS(); bool HereBeHowls();

    void MakeRoot();

}

public class OnboardingReqs : IOnboardingReqs{

    public bool HasIDE      () =>  atom.Exists() || vscode.Exists();
    public bool HasExt      () =>  atom.SupportsHowl() || vscode.SupportsHowl();
    public bool HasRoot     () =>  Path.FindHowlRoot() != null;
    public bool MayImport   () =>  false;
    public bool HasVCS      () =>  FS.FindInParent(Path.howlRoot, ".git") != null;
    public bool HereBeHowls () =>  FS.HasFileOfType("Assets/", "*.howl");

    public void MakeRoot () => Path.AvailHowlRoot();

    static Atom   atom   => new Atom();
    static VSCode vscode => new VSCode();

}

}
