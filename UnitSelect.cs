using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour
{
    private Vector2 startPosition, endPosition;
    private Color original, clear, curColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            startPosition = Camera.main.ScreenToWorldPoint(input.mousePosition);
        }
    }
}
