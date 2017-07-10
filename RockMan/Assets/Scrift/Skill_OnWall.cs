using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(PlayerController))]
public class Skill_OnWall : MonoBehaviour
{
    private InputController inputController;
    private PlayerController playerController;
    private void Awake()
    {
        inputController = GetComponent<InputController>();
        playerController = GetComponent<PlayerController>();
        
    }

    private void FixedUpdate()
    {
        if(playerController.playerStatus.isCollidingLeft || playerController.playerStatus.isCollidingRight)
        {
            playerController.OnWall();
        }
    }
}
