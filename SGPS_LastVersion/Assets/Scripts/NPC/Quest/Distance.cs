using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public GameObject NPC;// NPC를 담을 인스펙터 변수 창 -> 린 3D 소환하고 끌어다 놓으면 됨
    public GameObject Player; //플레이어를 담을 인스펙터 변수 창 -> Player 끌어다 놓으면 됨
    public float Distance_; // 두 오브젝트 간 거리변수

    [SerializeField] public GameObject Crosshair;// 크로스헤어
    [SerializeField] public Camera WeaponCamera;// 무기 카메라
    [SerializeField] public GameObject Holder;// 플레이어 손
    [SerializeField] public GameObject HUD;// 허드
    [SerializeField] public GameObject Sprite;
    [SerializeField] public GameObject NPCHi;
    [SerializeField] public GameObject Quick;


    void Update()
    {
        Distance_ = Vector3.Distance(NPC.transform.position, Player.transform.position); // NPC와 플레이어 사이의 거리
        if (Distance_ < 3) //거리는 임의로 설정하면됨  
        {
            Sprite.SetActive(true);
            Holder.gameObject.SetActive(false);
            WeaponCamera.gameObject.SetActive(false);
            Crosshair.gameObject.SetActive(false);
            HUD.gameObject.SetActive(false);
            NPCHi.gameObject.SetActive(true);
            Quick.gameObject.SetActive(false);
        }
        else
        {
            Sprite.SetActive(false);
            Holder.gameObject.SetActive(true);
            WeaponCamera.gameObject.SetActive(true);
            Crosshair.gameObject.SetActive(true);
            HUD.gameObject.SetActive(true);
            NPCHi.gameObject.SetActive(false);
            Quick.gameObject.SetActive(true);
        }
    }
}
// 지금 이 스크립트는 Terrain에 적용시키면 됨 그 후에 빈칸에 오브젝트 끌어다 놓고 