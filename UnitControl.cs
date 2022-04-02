using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour
{
    private float acceleration = 3;
    private Rigidbody2D rigidBodyComponent;
    private Vector2 finishPosition = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    async void Update()
    {
        var startPosition = rigidBodyComponent.position;
        if(Input.GetMouseButton(0))
        {
            finishPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        var a = finishPosition - startPosition;
        rigidBodyComponent.velocity = a.normalized * acceleration;
        if(Mathf.Abs(a.x) < 0.1 
        && Mathf.Abs(a.y) < 0.1)
        {
            rigidBodyComponent.velocity = Vector2.zero;
        }
    }
}
