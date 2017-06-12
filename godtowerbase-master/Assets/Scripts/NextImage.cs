using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextImage : MonoBehaviour {
    public Image image;
    bool check = false;
    public List<GameObject> hints;
    public Button nexthintButoon;
    // Use this for initialization
    private int currentHintIndex = 0;
    private void Start()
    {
        if (hints.Count > 1)
        {
            nexthintButoon.gameObject.SetActive(true);
        }
    }
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

    public void OnHintButtonClicked()
    {
        currentHintIndex = (currentHintIndex + 1) % hints.Count;
        if (currentHintIndex == hints.Count - 1)
        {
          nexthintButoon.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
           nexthintButoon.transform.localScale=Vector3.one;
        }
        for (int i = 0; i < hints.Count; i++)
        {
            hints[i].SetActive(i == currentHintIndex);
        }
    }
}
