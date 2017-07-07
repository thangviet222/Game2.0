using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float movementSpeed;

    private InputController inputController;
    private Controller2D controller2D;
    private Vector2 velocity;

    private void Awake()
    {
        inputController = GetComponent<InputController>();
        controller2D = GetComponent<Controller2D>();
    }

    private void FixedUpdate()
    {
        velocity = new Vector2(
            inputController.Direction.x * movementSpeed,
            velocity.y + Physics2D.gravity.y * Time.fixedDeltaTime
        );

        //Debug.DrawRay(transform.position, velocity * Time.fixedDeltaTime, Color.red, 1);

        PlayerStatus playerStatus = controller2D.Move(velocity * Time.fixedDeltaTime);
        Debug.Log("--bot-- "+playerStatus.isCollidingBottom+"--Left-- "+playerStatus.isCollidingLeft+
          "--Right-- "+  playerStatus.isCollidingRight+"--top--"+playerStatus.isCollidingTop);
        transform.position += (Vector3)playerStatus.velocity;
    }
}
