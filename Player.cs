using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float acceleration = 3;

    private Rigidbody2D rigidBodyComponent;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var w = Input.GetKey(KeyCode.W) ? 1 : 0;
        var s = Input.GetKey(KeyCode.S) ? -1 : 0;
        var a = Input.GetKey(KeyCode.A) ? 1 : 0;
        var d = Input.GetKey(KeyCode.D) ? -1 : 0;
        var movementVector = new Vector2(-(a + d), w + s);

        rigidBodyComponent.velocity = movementVector * acceleration;
        if (movementVector.magnitude > Mathf.Epsilon)
        {
            var angle = new Vector3(0, 0, movementVector.GetAngle());
            transform.rotation = Quaternion.Euler(angle);
        }
    }
}
