using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public GameObject transitionZone;
    public GameObject Manager;
    
    private BoxCollider2D transition;

    void Start(){
        //transition = transitionZone.GetComponent<BoxCollider2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Entered");
        Manager.GetComponent<TransitionManager>().changeScene();
    }
}
