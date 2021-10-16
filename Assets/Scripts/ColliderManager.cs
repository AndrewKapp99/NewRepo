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
        if(ConvoManager.GetComponent<InkManager>().playerData.lastSceneName == "EarthScene"){
            GetComponent<Transform>().localPosition = new Vector2(-7.51f, -2.45f);
        }
        else if(ConvoManager.GetComponent<InkManager>().playerData.lastSceneName == "JupiterScene")
            GetComponent<Transform>().localPosition = new Vector2(3.08f, -2.45f);


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
