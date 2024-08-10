using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfControl : MonoBehaviour
{

    
    public InputField name;

    // Start is called before the first frame update
    void Start()
    {

        name.text = PlayerPrefs.GetString("user_name");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create()
    {
        PlayerPrefs.SetString("user_name", name.text);
        PlayerPrefs.Save();
    }

}
