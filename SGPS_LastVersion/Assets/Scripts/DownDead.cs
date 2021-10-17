using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DownDead : MonoBehaviour
{
    void Update()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(this.transform.position, Vector3.down, out hitInfo, 1f, LayerMask.GetMask("Floor")))
        {//레이저를 아래로 1f 발사하고 레이저에 닿은 것이 Floor 레이어가 적용된 물체라면 게임 오버 씬으로 전환
            SceneManager.LoadScene("JumpOver");
        }
    }
}
