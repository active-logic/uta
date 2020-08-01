
namespace Active.Howl{
public interface IOnboardingReqs {

    bool InProgress();  bool HasIDE();  bool HasExt();
    bool HasRoot();     bool HasVCS();  bool HereBeHowls();
    bool HereBeSharps();

    UserChoice LetsImport();

    void MakeRoot();   void DoImport();   void DoNotImport();
    void Validate();

}}
