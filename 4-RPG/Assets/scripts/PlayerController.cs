using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    private Vector3 min, max;

    //RB.velocity = new vector2 (movement.x, movement.y);

    //[SerializeField]
    //private Vector3 moveDirection;

    [SerializeField]
    private float speed = 10.0f;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;

    void Start()
    {
        r2dCharPhysics = GetComponent<Rigidbody2D>();

        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;

        cam = Camera.main;
    }

    protected override void Update()
    {
        
        GetInput();

        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        //transform.position = transform.position + horizontal * Time.deltaTime;
        base.Update();
    }

    void OnGUI()
    {
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        Vector2 point = new Vector2();

        // compute where the mouse is in world space
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));

        if (Input.GetButton("Fire2"))
        {
            // set the target to the mouse click location
            target = point;
        }
    }

    private void FixedUpdate()
    {
    }

    private void GetInput()
    {

    }

    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        target = gameObject.transform.position;
        Debug.Log("Collide");
    }
}
