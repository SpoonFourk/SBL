using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelect : MonoBehaviour
{
    [SerializeField] private int maxUnits = 100;
    [SerializeField] private Image mainRect;
    private Rect rect;
    private Vector2 startPosition, endPosition;
    private Color original, clear, curColor;
    private bool canDraw;
    private Sprite[] unitImage;
	private static UnitComponent[] _unit;
	private static List<UnitComponent> unitSelected;
	private static int _unitCount;
	private static UnitSelect _internal;

	public static UnitSelect Internal
	{
		get{ return _internal; }
	}
    // Start is called before the first frame update
    public static void AddUnit(UnitComponent comp) // добавить нового юнита
	{
		for(int i = 0; i < _unit.Length; i++)
		{
			if(_unit[i] == null)
			{
				_unit[i] = comp;
				_unitCount++;
				break;
			}
		}
	}
    void Start()
    {
        _internal = this;
		_unitCount = 0;
		_unit = new UnitComponent[maxUnits];
		unitSelected = new List<UnitComponent>();
		original = mainRect.color;
        Debug.Log(mainRect.color);
		clear = original;
		clear.a = 0;
		curColor = clear;
		mainRect.color = clear;
    }

    void Awake()
	{
		
	}

    void Draw() // рисуем рамку
	{
		endPosition = Input.mousePosition;
		if(startPosition == endPosition || !canDraw) 
            return;

		curColor = original;

		rect = new Rect(Mathf.Min(endPosition.x, startPosition.x),
			Screen.height - Mathf.Max(endPosition.y, startPosition.y),
			Mathf.Max(endPosition.x, startPosition.x) - Mathf.Min(endPosition.x, startPosition.x),
			Mathf.Max(endPosition.y, startPosition.y) - Mathf.Min(endPosition.y, startPosition.y)
		);

		mainRect.rectTransform.sizeDelta = new Vector2(rect.width, rect.height);

		mainRect.rectTransform.anchoredPosition = new Vector2(rect.x + mainRect.rectTransform.sizeDelta.x/2, 
			Mathf.Max(endPosition.y, startPosition.y) - mainRect.rectTransform.sizeDelta.y/2);
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            rect = new Rect();
            startPosition = Input.mousePosition;
            canDraw = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            curColor = clear;
            canDraw = false;
        }

        Draw();

        mainRect.color = Color.Lerp(mainRect.color, curColor, 10 * Time.deltaTime);
    }
}
