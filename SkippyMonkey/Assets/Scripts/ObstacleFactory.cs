using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour {
    public GameObject obstaclePrefab;
	// Use this for initialization
	void Start () {
        int y = -250;
        while (y < 568)
        {
            int x = Random.Range(-250, 250);
            GameObject newObstacle = Instantiate(obstaclePrefab,
                new Vector3(x, y, 10),
                Quaternion.identity);
            y = y + 200;
        }
    }
	
	
}
