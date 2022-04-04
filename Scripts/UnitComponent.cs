using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    [SerializeField] private UnitType _type;
    private float acceleration = 3;
    private Rigidbody2D rigidBodyComponent;
    public int id {get; private set; }
    public string iconName {get; private set; }
    public string type {get; private set; }
    private bool used;
    private Vector2 finishPosition = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
        iconName = _type.ToString();
		id = iconName.GetHashCode();
        UnitSelect.AddUnit(this);
    }

    public void Deselect()
    {
        used = false;
    }

    public void Select()
    {
        used = true;
    }
    // Update is called once per frame
    async void Update()
    {
        var startPosition = rigidBodyComponent.position;
        if(Input.GetMouseButton(0)
        && used)
        {
            finishPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        var a = finishPosition - startPosition;
        if(a.magnitude < 0.1
        || finishPosition == Vector2.zero)
        {
            rigidBodyComponent.velocity = Vector2.zero;
            return;
        }
        rigidBodyComponent.velocity = a.normalized * acceleration;
    }
}
