using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [RequireComponent(typeof(InputController))]
 [RequireComponent(typeof(PlayerController))]
public class Skill_DashOnAir : MonoBehaviour {
    private InputController inputController;
    private PlayerController playerController;
    private void Awake()
    {
        inputController = GetComponent<InputController>();
        playerController = GetComponent<PlayerController>();
        inputController.OnDashPressed += DashOnAir;
    }
    private void OnDestroy()
    {
        inputController.OnJumpPressed -= DashOnAir;
    }
    private void DashOnAir()
    {
        if(!playerController.playerStatus.isCollidingBottom &&
            playerController.airborneSkillAvailable)
        {
            playerController.DashOnAir();   
        }
    }
}
