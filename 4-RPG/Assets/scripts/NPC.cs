using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class NPC : Character
{
    #region TODO
    //Track if in combat, friendly, a follower, or neutral
    #endregion
    [BoxGroup("Pathfinding"), SerializeField, LabelText("Random Movement")]
    protected NPCRandomMovement RandomMov;
    [BoxGroup("Pathfinding"), SerializeField, LabelText("Patrol Movement")]
    protected Patrol PatrolMov;
    [BoxGroup("Pathfinding"), SerializeField, LabelText("Follow Movement")]
    protected NPCFollow FollowMov;

    [SerializeField]
    private int MovementType = 0; //0: None //1: Patrol //2: Follow //3: Random

    [SerializeField]
    public int Health = 100; //Stays public so player can grab health of npc and change it

    [SerializeField] //UNIMPLEMENTED
    private int Behavior = 0; //0: None //1: Friendly //2: Enemy

    private void SetMovementType()
    {
        switch (MovementType)
        {
            case 0:
                RandomMov.enabled = false;
                FollowMov.enabled = false;
                PatrolMov.enabled = false;
                break;
            case 1:
                RandomMov.enabled = false;
                FollowMov.enabled = false;
                PatrolMov.enabled = true;
                break;
            case 2:
                RandomMov.enabled = false;
                FollowMov.enabled = true;
                PatrolMov.enabled = false;
                break;
            case 3:
                RandomMov.enabled = true;
                FollowMov.enabled = false;
                PatrolMov.enabled = false;
                break;
            default:
                RandomMov.enabled = false;
                FollowMov.enabled = false;
                PatrolMov.enabled = false;
                break;
        }
    }


    protected override void Update()
    {
        SetMovementType();
    }
}
