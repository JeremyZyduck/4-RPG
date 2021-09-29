using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class NPC : Character
{
    [BoxGroup("Pathfinding"), SerializeField, LabelText("Random Movement")]
    protected NPCRandomMovement RandomMov;
    [BoxGroup("Pathfinding"), SerializeField, LabelText("Patrol Movement")]
    protected Patrol PatrolMov;
    [BoxGroup("Pathfinding"), SerializeField, LabelText("Follow Movement")]
    protected NPCFollow FollowMov;
    [SerializeField]
    private int MovementType = 0; //0: None //1: Patrol //2: Follow //3: Random

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
