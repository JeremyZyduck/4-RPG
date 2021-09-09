#region USING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
#endregion
/*<SUMMARY>
 *All shared functions of characters.
<USE>
 *All characters(NPCs and Player Character).
</USE>
</SUMMARY>*/
public abstract class Character : MonoBehaviour
{
    #region TODO
    //Refactor this and the playerController.cs to allow for movement on all users of this class
    //Track health
    //Track if in combat, friendly, a follower, or neutral
    #endregion
    #region MOVEMENT
    [BoxGroup("Movement"), SerializeField, LabelText("Speed")]
    protected float fSpeed;
    #endregion
    #region PHYSICS OBJECT
    //Grabs rigidbody from child
    //All children require the line 'r2dCharPhysics = GetComponent<Rigidbody2D>();' in the start function
    [BoxGroup("Player"), SerializeField, PropertyOrder(-3), LabelText("Rigidbody")]
    protected Rigidbody2D r2dCharPhysics;
    #endregion
    #region DEFAULT
    void Start()
    {
    }

    protected virtual void Update()
    { 
    }

    private void FixedUpdate()
    {
    }
    #endregion
}
