using FS = Active.Howl.FileSystem;

namespace Active.Howl{
public class OnboardingReqs : IOnboardingReqs{

    public bool inProgress;
    public Cache<bool> ready;
    public Cache<bool> hasGit;

    public OnboardingReqs(){
        ready = new Cache<bool>( φ: () => HasIDE() && HasExt() && HasVCS()
                                && !mayImport, expiry: 5f);
        hasGit = new Cache<bool>( φ: HasGit, expiry: 10f);
    }

    public bool ReadyForUse () => ready;

    // <IOnboardingReqs> --------------------------------------------

    public bool  InProgress   () =>  inProgress || (inProgress = !ReadyForUse());
    public bool  HasIDE       () =>  Atom.ι.Exists() || VSCode.ι.Exists();
    public bool  HasExt  () =>  Atom.ι.SupportsHowl() || VSCode.ι.SupportsHowl();
    public bool  HereBeHowls  () =>  FS.Match("*.howl", Path.assets);
    public bool  HereBeSharps () =>  FS.Match("*.cs", Path.assets);
    public bool  HasVCS       () =>  hasGit;

    public UserChoice LetsImport () => Config.ι.sel_importFiles;

    public void DoImport(){
        Howl.ImportDir("Assets/", verbose: true);
        Config.ι.sel_importFiles = UserChoice.Yes;
    }

    public void DoNotImport () => Config.ι.sel_importFiles = UserChoice.No;

    public void Validate () => inProgress = false;

    // --------------------------------------------------------------

    public static  bool HasGit () => FS.FindInParent(Path.howlRoot, ".git") != null
                 || FS.Match(".git", Path.assets, files:false, dirs: true);

    bool mayImport => (LetsImport() == UserChoice.Undecided)
                   && HereBeSharps() && !HereBeHowls();

}}
