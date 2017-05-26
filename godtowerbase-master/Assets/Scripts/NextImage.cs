using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextImage : MonoBehaviour {
    public Image image;
    bool check = false;
	// Use this for initialization
	public void changeImage()
    {
        if (check == false)
        {
            check = true;
            image.gameObject.SetActive(true);
        }
        else
        {
            check = false;
            image.gameObject.SetActive(false);
        }
    }
}
