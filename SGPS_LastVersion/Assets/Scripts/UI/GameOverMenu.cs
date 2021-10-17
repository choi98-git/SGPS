using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public string sceneName1 = "GameStage";
    public string sceneName2 = "GameTitle";

    public void ClickLoad()
    {
        SceneManager.LoadScene(sceneName1);
    }

    public void ClickExit()
    {
        SceneManager.LoadScene(sceneName2);
    }
}

