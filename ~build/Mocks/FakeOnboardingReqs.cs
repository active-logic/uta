using UnityEngine;

namespace Active.Howl.Testing{
[ExecuteInEditMode]
public class FakeOnboardingReqs : MonoBehaviour, IOnboardingReqs{

    public bool inProgress;   public bool InProgress    () =>  inProgress;
    public bool hasIde;       public bool HasIDE        () =>  hasIde;
    public bool hasExt;       public bool HasExt        () =>  hasExt;
    public bool hasRoot;      public bool HasRoot       () =>  hasRoot;
    public bool hasVCS;       public bool HasVCS        () =>  hasVCS;
    public bool hereBeHowls;  public bool HereBeHowls   () =>  hereBeHowls;
    public bool hereBeSharps; public bool HereBeSharps  () =>  hereBeSharps;
    //
    public UserChoice letsImport;  public UserChoice LetsImport () => letsImport;

    public void MakeRoot    () => Log("Should make root");
    public void DoImport    () => Log("Should import files; save choice");
    public void DoNotImport () => Log("Should not import files; save choice");
    public void Validate    () => Log("Should dismiss onboarding panel");

    void OnEnable   () =>  Onboarding.reqs =  this;
    void OnDisable  () =>  Onboarding.reqs = null;

    static void Log(object x) => UnityEngine.Debug.Log(x);

}}
