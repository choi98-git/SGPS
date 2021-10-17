using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorOpen2 : MonoBehaviour
{
    public GameObject Door;
    public GameObject Player;
    public GameObject OpenText;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hitInfo, 3f, LayerMask.GetMask("Note")))
        {
            OpenText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Ending");
            }
        }
        else
            OpenText.gameObject.SetActive(false);
    }
}
