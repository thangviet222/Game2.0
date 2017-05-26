using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextImageLV4 : MonoBehaviour {
    public Image image;
    bool check = false;
    public GameObject gameobject;
    public void changeImage()
    {
        if (check == false)
        {
            check = true;
            image.gameObject.SetActive(true);
            gameobject.SetActive(false);
        }
        else
        {
            check = false;
            image.gameObject.SetActive(false);
            gameobject.SetActive(true);

        }
    }
	
}
