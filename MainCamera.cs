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
        mapWidth /= 2;
        mapHeight /= 2;
    }

    private Vector3 UpdateCameraPosition(Vector3 direction)
    {
        return transform.position + direction / 25;
    }
    // Update is called once per frame
    void Update()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0)
        {
            GetComponent<Camera>().orthographicSize 
            = Mathf.Clamp(GetComponent<Camera>().orthographicSize - scroll * 5, minZoom, maxZoom);
        }

        var leftDownAngle = Camera.main.ScreenToWorldPoint(Vector2.zero);
        var rightUpAngle = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var mousePosition = Input.mousePosition;
        if(mousePosition.x < 1 
        && leftDownAngle.x > -mapWidth
        || rightUpAngle.x > mapWidth)
            transform.position = UpdateCameraPosition(Vector3.left);
        if(mousePosition.x > Screen.width - 1
        && rightUpAngle.x < mapWidth
        || leftDownAngle.x < -mapWidth)
            transform.position = UpdateCameraPosition(Vector3.right);
        if(mousePosition.y < 1
        && leftDownAngle.y > -mapHeight
        || rightUpAngle.y > mapHeight)
            transform.position = UpdateCameraPosition(Vector3.down);
        if(mousePosition.y > Screen.height - 1
        && rightUpAngle.y < mapHeight
        || leftDownAngle.y < -mapHeight)
            transform.position = UpdateCameraPosition(Vector3.up);
    }
}
