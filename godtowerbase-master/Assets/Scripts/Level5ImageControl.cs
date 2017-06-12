using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Level5ImageControl : EventTrigger {

	// Use this for initialization
	private void Start () {
        transform.localPosition = new Vector3(
            Random.Range(-277.5f, 277.5f),
            Random.Range(-194, 244),
            0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
