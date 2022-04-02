using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float minZoom;
    public float maxZoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Input.mousePosition;
        if(mousePosition.x < 1)
            transform.position = transform.position + Vector3.left / 25;
        if(mousePosition.x > Screen.width - 1)
            transform.position = transform.position + Vector3.right / 25;
        if(mousePosition.y < 1)
            transform.position = transform.position + Vector3.down / 25;
        if(mousePosition.y > Screen.height - 1)
            transform.position = transform.position + Vector3.up / 25;

        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0)
        {
            GetComponent<Camera>().orthographicSize 
            = Mathf.Clamp(GetComponent<Camera>().orthographicSize - scroll * 5, minZoom, maxZoom);
        }
    }
}
