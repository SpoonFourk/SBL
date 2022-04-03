using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float minZoom, maxZoom;
    public float mapWidth, mapHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 UpdateCameraPosition(Vector3 direction)
    {
        return transform.position + direction / 25;
    }
    // Update is called once per frame
    void Update()
    {
        var mousePosition = Input.mousePosition;
        if(mousePosition.x < 1 
        && transform.position.x > -mapWidth/2)
            transform.position = UpdateCameraPosition(Vector3.left);
        if(mousePosition.x > Screen.width - 1
        && transform.position.x < mapWidth/2)
            transform.position = UpdateCameraPosition(Vector3.right);
        if(mousePosition.y < 1
        && transform.position.y > -mapHeight/2)
            transform.position = UpdateCameraPosition(Vector3.down);
        if(mousePosition.y > Screen.height - 1
        && transform.position.y < mapHeight/2)
            transform.position = UpdateCameraPosition(Vector3.up);

        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0)
        {
            GetComponent<Camera>().orthographicSize 
            = Mathf.Clamp(GetComponent<Camera>().orthographicSize - scroll * 5, minZoom, maxZoom);
        }
    }
}
