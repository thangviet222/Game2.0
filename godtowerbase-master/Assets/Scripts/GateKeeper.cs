using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GateKeeper : MonoBehaviour
{
    public string levelNumber;
    public string password;
    public string nextSceneName;

    public Text levelText;
    public InputField passwordInput;
    public Text accessDeniedText;

    void Update()
    {
        if (Time.timeSinceLevelLoad % 2 < 1)
        {
            levelText.text = "LEVELS";
        }
        else
        {
            levelText.text = levelNumber;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            CheckPassword();
        }
    }

    public void CheckPassword()
    {
        if (string.IsNullOrEmpty(passwordInput.text.Trim()))
            return;

        if (passwordInput.text.Trim() == password)
        {
            TKSceneManager.ChangeScene(nextSceneName);
        }
        else
        {
            passwordInput.text = "";
            accessDeniedText.gameObject.SetActive(true);
        }
    }
}