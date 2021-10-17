using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    public GameObject Door;
    public GameObject Player;
    public GameObject OpenText;
    public float OpenDistance;

    // Update is called once per frame
    void Update()
    {
        OpenDistance = Vector3.Distance(Door.transform.position, Player.transform.position);
        if(OpenDistance < 2)
        {
            OpenText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("BossMap");
            }
        }
    }
}
