using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool IsDone;
    public bool TimeDown = true;
    public int Hour = 0;
    public int Min = 2;
    public int Secound = 30;
    public Text Timers;





    private void Start()
    {
        //Timers = GetComponent<Text>();
        print (Timers);
        print(PlayerPrefs.GetString ("record"));
    }

    private void Update()
    {
        if (Hour <= 0 && Min <= 0 && Secound <= 0)
        {
            IsDone = true;

            if (SceneManager.GetActiveScene().name == "Scene2")
            {
                SceneManager.LoadScene(4);
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }
        if (IsDone == false)
        {
            if (Hour <10 && Secound < 10 && Min < 10)
            {
                Timers.text = "0"+ Hour + ":0" + Min + ":0" + Secound;
            }
            else if (Hour < 10 && Min < 10)
            {
                Timers.text = "0" + Hour + ":0" + Min + ":" + Secound;
            }
            else if (Hour < 10)
            {
                Timers.text = "0" + Hour + ":" + Min + ":" + Secound;
            }
            else if (Min < 10)
            {
                Timers.text = Hour + ":0" + Min + ":" + Secound;
            }
            else if (Secound < 10)
            {
                Timers.text = Hour + ":" + Min + ":0" + Secound;
            }
            else
            {
                Timers.text = Hour + ": " + Min + ":" + Secound;
            }
            if (TimeDown == true)
            {
                Invoke("Time", 1f);
                TimeDown = false;
            }
            if (Secound > 60)
            {
                Min++;
                Secound = 1;
            }
            if (Min > 60)
            {
                Hour++;
                Min = 0;
            }
            if (Secound < 0)
            {
                Min--;
                Secound = 59;
            }
            if (Min < 0)
            {
                Hour--;
                Min = 59;
            }
        }
        
        
    }
    void Time()
    {
        Secound--;
        TimeDown = true;
    }
    public void Records()
    {
        PlayerPrefs.SetString ("record", Timers.text);
        //PlayerPrefs.SetInt("record_hour", RecTime.text);
        //PlayerPrefs.SetInt("record_minute", RecTime.text);
        //PlayerPrefs.SetInt("record_secound", RecTime.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);

    }
}
