using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDistance : MonoBehaviour
{
    public GameObject Player;
    public GameObject NoteInfo; //노트 읽기 메시지
    public GameObject Note; // 노트 UI
    public GameObject NoteBtn; //노트의 버튼
    public GameObject NoteText; //노트 내용
    public GameObject Allcan; // 전체 캔버스 


    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 3f, LayerMask.GetMask("Note")))
        {
            NoteInfo.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T))
            {
                Note.gameObject.SetActive(true);
                NoteBtn.gameObject.SetActive(true);
                NoteText.gameObject.SetActive(true);
                Allcan.gameObject.SetActive(false);
                NoteInfo.gameObject.SetActive(false);
            }
        }
        else
            NoteInfo.gameObject.SetActive(false);
    }
}
