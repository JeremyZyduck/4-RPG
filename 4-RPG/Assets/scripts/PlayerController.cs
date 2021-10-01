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
    private void CheckHealth()
    {
        if (Health <= 0)
        {
            deathAnim.Play("Death");
            if (!deathAnim.IsPlaying("Death"))
            {
                gameObject.SetActive(false);
            }
        }
    }

    #region DEFAULT
    void Start()
    {
        r2dCharPhysics = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        CheckHealth();
        base.Update();
    }
    #endregion
}
