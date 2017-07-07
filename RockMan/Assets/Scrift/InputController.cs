using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

 public Vector2 Direction { get; private set; }

    private void Update()
    {
        Direction = new Vector2(Input.GetAxis("Horizontal")
            ,Input.GetAxis("Vertical"));
    }
}
