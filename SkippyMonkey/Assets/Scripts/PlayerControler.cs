using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerControler : MonoBehaviour {

    private static float SCREEN_HALF_WIDTH = 320f;
    public float playerSpeed;
    public float PlayerJumpSpeed;
    private Rigidbody2D rgbody;
    private Animator anim;

    private void Start()
    {
        rgbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rgbody.velocity = rgbody.velocity.WithX(playerSpeed);
        LeanTouch.OnFingerTap += Jump;
    }
    // Update is called once per frame

    private void Update () {
        rgbody.velocity = rgbody.velocity.WithX(playerSpeed);
        if (transform.position.x > SCREEN_HALF_WIDTH)
        {
            transform.position = transform.position.WithX(
                transform.position.x - 2*SCREEN_HALF_WIDTH);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rgbody.velocity = rgbody.velocity.WithY(PlayerJumpSpeed);
            anim.SetBool("isGrounded", false);
        }

    }
    private void OnDestroy()
    {
        LeanTouch.OnFingerTap -= Jump;
    }
    private void Jump(LeanFinger finger)
    {

        rgbody.velocity = rgbody.velocity.WithY(PlayerJumpSpeed);
        anim.SetBool("isGrounded", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("isGrounded", true);
    }
}
