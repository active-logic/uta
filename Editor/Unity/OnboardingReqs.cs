using FS = Active.Howl.FileSystem;

namespace Active.Howl{

public interface IOnboardingReqs {

    bool HasIDE(); bool HasExt(); bool HasRoot(); bool MayImport();
    bool HasVCS(); bool HereBeHowls(); bool HereBeSharps();
    //
    UserChoice LetsImport();

    void MakeRoot();
    void DoImport();
    void DoNotImport();

}

public class OnboardingReqs : IOnboardingReqs{

    public bool  HasIDE       () =>  atom.Exists() || vscode.Exists();
    public bool  HasExt       () =>  atom.SupportsHowl() || vscode.SupportsHowl();
    public bool  HasRoot      () =>  Path.FindHowlRoot() != null;
    public bool  MayImport    () =>  false;
    public bool  HasVCS       () =>  FS.FindInParent(Path.howlRoot, ".git") != null;
    public bool  HereBeHowls  () =>  FS.HasFileOfType("Assets/", "*.howl");
    public bool  HereBeSharps () =>  FS.HasFileOfType("Assets/", "*.cs");
    //
    public UserChoice LetsImport () => Config.ι.sel_importFiles;

    public void MakeRoot    () => Path.AvailHowlRoot();

    public void DoImport(){
        Howl.ImportDir("Assets/", verbose: true);
        Config.ι.sel_importFiles = UserChoice.Yes;
    }

    public void DoNotImport () => Config.ι.sel_importFiles = UserChoice.No;

    static Atom   atom   => new Atom();
    static VSCode vscode => new VSCode();

}

}
