using UnityEngine;

namespace Active.Howl.Testing{
public class FakeOnboardingReqs : MonoBehaviour, IOnboardingReqs{

    public bool hasIde;       public bool HasIDE       () =>  hasIde;
    public bool hasExt;       public bool HasExt       () =>  hasExt;
    public bool hasRoot;      public bool HasRoot      () =>  hasRoot;
    public bool mayImport;    public bool MayImport    () =>  mayImport;
    public bool hasVCS;       public bool HasVCS       () =>  hasVCS;
    public bool hereBeHowls;  public bool HereBeHowls  () =>  hereBeHowls;

}}
