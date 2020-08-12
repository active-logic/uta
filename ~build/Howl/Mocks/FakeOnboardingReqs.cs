using UnityEngine;

namespace Active.Howl.Testing{
[ExecuteInEditMode]
public class FakeOnboardingReqs : MonoBehaviour, IOnboardingReqs{

    public bool inProgress;   public bool InProgress    () =>  inProgress;
    public bool hasIde;       public bool HasIDE        () =>  hasIde;
    public bool hasExt;       public bool HasExt        () =>  hasExt;
    public bool hasVCS;       public bool HasVCS        () =>  hasVCS;
    public bool hereBeHowls;  public bool HereBeHowls   () =>  hereBeHowls;
    public bool hereBeSharps; public bool HereBeSharps  () =>  hereBeSharps;
    //
    public UserChoice letsImport;  public UserChoice LetsImport () => letsImport;

    public void MakeRoot    () =>  UnityEngine.Debug.Log("Should make root");
    public void DoImport    () =>  UnityEngine.Debug.Log("Should import files; save choice");
    public void DoNotImport () =>  UnityEngine.Debug.Log("Should not import files; save choice");
    public void Validate    () =>  UnityEngine.Debug.Log("Should dismiss onboarding panel");

    void OnEnable   () =>  Onboarding.reqs = this;
    void OnDisable  () =>  Onboarding.reqs = null;

}}
