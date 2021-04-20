using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea] // 어려줄 쓸수 있게 해줌
    public string dialogue;
    public Sprite cg;
}

public class Test : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sprite_StandingCG; // 인물사진
    [SerializeField] private SpriteRenderer sprite_DialogueBox; // 대화창
    [SerializeField] private Text txt_Dialogue;// 대화내용
    [SerializeField] private GameObject Button;// 대화 시작버튼
    [SerializeField] public GameObject Crosshair;// 크로스헤어
    [SerializeField] public Camera WeaponCamera;// 무기 카메라
    [SerializeField] public GameObject Holder;// 플레이어 손
    [SerializeField] public GameObject HUD;// 허드

    private bool isDialogue = false;

    private int count = 0;

    // 대사가 많을 수도 있기때문에 배열로 선언
    [SerializeField] private Dialogue[] dialogue;

    // 인물사진, 대화창, 대화내용 보여주는 함수
    public void ShowDialogue()
    {
        Onoff(true);
        count = 0;
        NextDialogue();
    }

    // 시작 눌렀을 때 인물사진, 대화창, 대화내용 띄우고 
    //대화 시작버튼, 크로스헤어, 무기 카메라, 플레이어 손, 허드를 사라지게 하는 함수
    public void Onoff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        sprite_StandingCG.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = (_flag);

        Button.gameObject.SetActive(false);
    }
    // 다음 대화화면 이동 함수
    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
        sprite_StandingCG.sprite = dialogue[count].cg;
        count++;
    }

    // 마우스 왼쪽 클릭할때마다 다음 화면으로 넘어가기
    void Update()
    {

        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (count < dialogue.Length)
                    NextDialogue();
                else
                    Onoff(false);
            }
        }
        else
            Button.gameObject.SetActive(true);

    }
}
