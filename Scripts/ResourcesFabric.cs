using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesFabric : MonoBehaviour
{
    [SerializeField] private int resourcesCount = 16;
    [SerializeField] Text text;
    private bool overflowed;
    [SerializeField] private int secondsWait = 5;
    [SerializeField] private int countAddAfterWait = 3;
    public int resourcesCountInGame = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var len = mousePosition - transform.position;
        if(Input.GetMouseButtonDown(0)
           && resourcesCount > 0
           &&  Mathf.Abs(len.x) < 1
           && Mathf.Abs(len.y) < 1)
        {	
            resourcesCount--;
            if (resourcesCount == 0) overflowed = true;
            if (overflowed)
            {
                Thread.Sleep(secondsWait*1000);
                overflowed = false;
                resourcesCount = countAddAfterWait + 1;
            }
            else
            {
                resourcesCountInGame++;
            }
        }
        text.text = "Ресурсы: " + resourcesCountInGame.ToString();
    }
}