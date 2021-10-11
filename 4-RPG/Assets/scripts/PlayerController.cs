#region USING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
#endregion
/*<SUMMARY>
 *All required functions unique to the player character.
<USE>
 *Player Object.
</USE>
</SUMMARY>*/
public class PlayerController : Character
{
    #region TODO
    //Clean up setting astar and the rigidbody
    #endregion
    [SerializeField]
    public int Health = 100; //Stays public so enemies can change it

    [SerializeField]
    private Animation deathAnim;

    [SerializeField]
    public int AnimationState = 0;

    [SerializeField]
    public int CurrentAnimation = 0;

    public Animator playerAnimator;

    protected bool isPathEmpty
    {
        get
        {
            if (path == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void ChangeAnimation()
    {
        /*if (!isPathEmpty)
        {
            AnimationState = 1;
        }
        else if (Health <= 0)
        {
            AnimationState = 2;
        }
        else
        {
            AnimationState = 0;
        }*/
    }

    #region DEFAULT
    void Start()
    {
        r2dCharPhysics = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }


    public void ChangeAnim()
    {
        playerAnimator.SetBool("AnimationChange", true);
        playerAnimator.SetInteger("AnimationState", AnimationState);
        CurrentAnimation = AnimationState;
    }

    protected override void Update()
    {
        if (Health <= 0)
        {
            AnimationState = 2;
        }

        if (AnimationState != CurrentAnimation)
        {
            ChangeAnim();
        }
        else
        {
            playerAnimator.SetBool("AnimationChange", false);
        }
       
        base.Update();
    }
    #endregion
}
