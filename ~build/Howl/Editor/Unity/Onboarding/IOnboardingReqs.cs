
namespace Active.Howl{
public interface IOnboardingReqs {

    bool InProgress();  bool HasIDE();  bool HasExt();
    bool HasVCS();  bool HereBeHowls(); bool HereBeSharps();

    UserChoice LetsImport();

    void DoImport();   void DoNotImport();   void Validate();

}}
