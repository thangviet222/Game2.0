using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewBanana : MonoBehaviour {

    public GameObject banana;
	// Update is called once per frame
	void Update () {
        if (banana.transform.position.y > Camera.main.transform.position.y + Camera.main.orthographicSize)
        {
            if (!banana.activeInHierarchy)
            {
                banana.SetActive(true);
            }
        }
    }
}
