using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class load_scen : MonoBehaviour
{
    public void LoadScene(int Game)
    {
        SceneManager.LoadScene(Game);
    }

    public void LoadScene1(int Game)
    {
        StartCoroutine(LoadSceneCor(Game));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

    }

    IEnumerator LoadSceneCor(int SceneID)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(SceneID);
    }

    public void Exit() {

        Application.Quit();
    }
}
