using UnityEngine;

namespace Active.Howl.Demo{
public class Bouncing: MonoBehaviour{

    void Start(){
        gameObject.AddComponent<Rigidbody>();
        var bouncy = new PhysicMaterial("Bouncy");
        bouncy.bounciness = 1;
        bouncy.bounceCombine = PhysicMaterialCombine.Maximum;
        GetComponent<Collider>().material = bouncy;
        log.message = "The ball is bouncing.";
    }

}}
