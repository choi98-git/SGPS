using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance2 : MonoBehaviour
{

    [SerializeField] public GameObject NPC;// NPC를 담을 인스펙터 변수 창 -> 린 3D 소환하고 끌어다 놓으면 됨
    [SerializeField] public GameObject Player; //플레이어를 담을 인스펙터 변수 창 -> Player 끌어다 놓으면 됨
    [SerializeField] public float Distance_; // 두 오브젝트 간 거리변수
    [SerializeField] public GameObject NPCHi;
    // Start is called before the first frame update
    void Update()
    {
        Distance_ = Vector3.Distance(NPC.transform.position, Player.transform.position); // NPC와 플레이어 사이의 거리
        if (Distance_ < 3) //거리는 임의로 설정하면됨  
        {
            NPCHi.gameObject.SetActive(true);
        }
        else
        {
            NPCHi.gameObject.SetActive(false);
        }
    }
}
