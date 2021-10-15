using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public GameObject transitionZone;
    public GameObject Manager;
    public GameObject ConvoManager;
    
    private BoxCollider2D transition;

    void Start(){
        ConvoManager.GetComponent<InkManager>().InitializeConversation();
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
