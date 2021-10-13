using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AstroMover : MonoBehaviour
{
    [SerializeField] private GameObject Manager;
    private InkManager DManager;
    
    public string NextScene;
    private float _mouseXPosition;
    private bool isMoving;

    void Start(){
        DManager = Manager.GetComponent<InkManager>();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseXPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            isMoving = true;
        }

        if(isMoving && this.transform.position.x != _mouseXPosition)
        {
            this.transform.position = new Vector2(Mathf.Lerp(this.transform.position.x, _mouseXPosition, 0.001f), this.transform.position.y);
        } else
            isMoving = false;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Gateway")
            SceneManager.LoadScene(NextScene);
        else if(other.tag == "Alien"){
            Debug.Log("Were doin this scene");
            DManager.InitializeConversation();
        }
    }
}
