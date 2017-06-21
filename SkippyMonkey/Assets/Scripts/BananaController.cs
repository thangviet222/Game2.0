using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BananaController : MonoBehaviour {
    public GameObject banana;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        banana.SetActive(false); 
        
    }
    

}
