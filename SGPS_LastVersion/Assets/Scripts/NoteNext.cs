using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoteNext : MonoBehaviour
{
    public string sceneName = "JumpMap";

    public void NoteClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
