using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesFabric : MonoBehaviour
{
    [SerializeField] Text text;
    private bool overflowed;
    [SerializeField] private int secondsWait = 5;
    [SerializeField] private int countAddAfterWait = 3;
    private float lastTime;
    public static int resourcesCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        var timeNow = Time.realtimeSinceStartup;
        Debug.Log(timeNow - lastTime);
        if(timeNow - lastTime > secondsWait)
        {
            lastTime = timeNow;
            resourcesCount ++;
        }
        text.text = "Ресурсы: " + resourcesCount.ToString();
    }
}