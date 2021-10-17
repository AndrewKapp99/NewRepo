using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public GameObject transitionZone;
    public GameObject Manager;
    public GameObject ConvoManager;
    
    private BoxCollider2D transition;
    private string nextScene;
    void Start(){
        ConvoManager.GetComponent<InkManager>().InitializeConversation();
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Gateway"){
            nextScene = other.gameObject.GetComponent<TriggerManager>().SceneGate;
            Manager.GetComponent<TransitionManager>().changeScene(nextScene);
        }  
        else if(other.gameObject.tag == "Alien")
        {
            Debug.Log("Were in this.");
            Manager.GetComponent<InkManager>().InitializeConversation();
        }
    }
}
