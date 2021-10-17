using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gain : MonoBehaviour
{

    // 충돌한 오브젝트tag가 Player이면 코인 삭제
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {    
            Destroy(gameObject, 0f);
        }
    }
    
}
