using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayJ : MonoBehaviour
{
    GameObject scanNpc;
    public JumpTalkMg manager;
    public static int cnt;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {

            RaycastHit hitInfo;

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 10f, LayerMask.GetMask("NPC")))
            {
                scanNpc = hitInfo.transform.gameObject;
                cnt++;
                manager.Action(scanNpc);
            }

        }

    }
}
