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
    private Vector2 currentPos;

    void Start(){
        DManager = Manager.GetComponent<InkManager>();
        currentPos = (Vector2)GetComponent<Transform>().position;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && DManager.isTalking == false)
        {
            _mouseXPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            Debug.Log(_mouseXPosition);
            isMoving = true;
        }

        if(isMoving && GetComponent<Transform>().position.x != _mouseXPosition)
        {
            float step = 10f*Time.deltaTime;
            Debug.Log(currentPos.x);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_mouseXPosition, currentPos.y), step);
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
