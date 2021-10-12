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

    bool facingRight = true;

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

    void Flip()
    {
        // Switch the way the player is labeled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
       
        if (dir.x > 0 && facingRight)
        {
            Flip();
        }
        else if (dir.x < 0 && !facingRight)
        {
            Flip();
        }

        base.Update();
    }
    #endregion
}
