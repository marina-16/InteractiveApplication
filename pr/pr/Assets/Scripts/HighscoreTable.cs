using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    public Text User;
    public Text Time;

    // Start is called before the first frame update
    void Start()
    {
        User.text = PlayerPrefs.GetString("user_name");
        Time.text = PlayerPrefs.GetString("record");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetString("user_name", User.text);
        PlayerPrefs.SetString("record", Time.text);
    }
}
