using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected float fSpeed;

    [SerializeField]
    protected Vector2 v2Direction;

    //Grabs rigidbody from child
    //All children require the line 'r2dCharPhysics = GetComponent<Rigidbody2D>();' in the start function
    protected Rigidbody2D r2dCharPhysics;

    public bool bIsMoving
    {
        get
        {
            return v2Direction.x != 0 || v2Direction.y != 0;
        }
    }

    void Start()
    {

    }

    protected virtual void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        r2dCharPhysics.velocity = v2Direction.normalized * fSpeed;
    }

}
