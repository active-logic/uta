using FS = Active.Howl.FileSystem;

namespace Active.Howl{
public class OnboardingReqs : IOnboardingReqs{

    public bool inProgress;
    public Cache<bool> ready;

    public OnboardingReqs(){
        ready = new Cache<bool>( φ: () => HasIDE() && HasExt() && HasRoot()
                              && HasVCS() && !mayImport,
                           expiry: 5f);
    }

    public bool ReadyForUse () => ready;

    // <IOnboardingReqs> --------------------------------------------

    public bool  InProgress   () =>  inProgress || (inProgress = !ReadyForUse());
    public bool  HasIDE       () =>  atom.Exists() || vscode.Exists();
    public bool  HasExt       () =>  atom.SupportsHowl() || vscode.SupportsHowl();
    public bool  HasRoot      () =>  Path.FindHowlRoot() != null;
    public bool  HasVCS       () =>  FS.FindInParent(Path.howlRoot, ".git") != null;
    public bool  HereBeHowls  () =>  FS.HasFileOfType("Assets/", "*.howl");
    public bool  HereBeSharps () =>  FS.HasFileOfType("Assets/", "*.cs");
    //
    public UserChoice LetsImport () => Config.ι.sel_importFiles;

    public void MakeRoot () => Path.AvailHowlRoot();

    public void DoImport(){
        Howl.ImportDir("Assets/", verbose: true);
        Config.ι.sel_importFiles = UserChoice.Yes;
    }

    public void DoNotImport () => Config.ι.sel_importFiles = UserChoice.No;

    public void Validate () => inProgress = false;

    // --------------------------------------------------------------

    bool mayImport => (LetsImport() == UserChoice.Undecided)
                   && HereBeSharps() && !HereBeHowls();

    Atom   atom   => new Atom();

    VSCode vscode => new VSCode();

}}
