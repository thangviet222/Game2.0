using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeaderController : MonoBehaviour {
    public PlayerController playerController;
    public Text displayScore;
    int score = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController.Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        displayScore.text = "" + ++score;
        Debug.Log(score);
    }
    
}
