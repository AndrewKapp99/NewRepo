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
        if(other.gameObject.tag == "Gateway")
            Manager.GetComponent<TransitionManager>().changeScene();
        else if(other.gameObject.tag == "Alien")
        {
            Debug.Log("Were in this.");
            Manager.GetComponent<InkManager>().InitializeConversation();
        }
    }
}
