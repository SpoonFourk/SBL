using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour, IEnumerable
{
    [SerializeField] private UnitType type;
    internal UnitComponent previousComponent;
    internal UnitComponent nextComponent;
    private float acceleration = 3;
    private Rigidbody2D rigidBodyComponent;
    private bool used;
    private Vector2 finishPosition = Vector2.zero;
    private new SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        UnitSelect.AddUnit(this);
    }

    public IEnumerator<UnitComponent> GetEnumerator()
    {
        yield return this;
        var pathItem = previousComponent;
            while (pathItem != null)
            {
                yield return pathItem;
                pathItem = pathItem.previousComponent;
            }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public void Deselect()
    {
        used = false;
        renderer.material.color = Color.white;
    }

    public void Select()
    {
        used = true;
        renderer.material.color = Color.green;
    }
    // Update is called once per frame
    void Update()
    {
        var startPosition = rigidBodyComponent.position;
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, MainCamera.leftX + 1, MainCamera.rightX - 1),
            Mathf.Clamp(transform.position.y, MainCamera.leftY + 1, MainCamera.rightY - 1),
            transform.position.z
        );
        if(Input.GetMouseButtonDown(1)
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
