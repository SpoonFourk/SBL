using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    private float acceleration = 3;
    private Rigidbody2D rigidBodyComponent;
    public int id {get; private set; }
    public string type {get; private set; }
    public bool used {get;private set;}
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
    }
}
