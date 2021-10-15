using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Convo : MonoBehaviour
{
    [SerializeField] private GameObject _ship;
    [SerializeField] private Image _landing;
    [SerializeField] private GameObject DManager;
    private Vector2 _mousePosition;
    private bool isMoving;

    void Update(){
        if (Input.GetMouseButtonDown(0) && !DManager.GetComponent<InkManager>().isTalking)
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }

        if(isMoving && (Vector2)_ship.GetComponent<Transform>().position != _mousePosition)
        {
            float step = 10f*Time.deltaTime;
            _ship.GetComponent<Transform>(). position = Vector2.MoveTowards(_ship.GetComponent<Transform>().position, _mousePosition, step);
        } else
            isMoving = false;
    }
}
