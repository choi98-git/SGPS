using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizBar : MonoBehaviour
{
    public GameObject Block;
    public GameObject Player;
    public GameObject quizBar;
    public float JumpDist_;

    // Update is called once per frame
    void Update()
    {
        JumpDist_ = Vector3.Distance(Player.transform.position, Block.transform.position);
        //블록과 플레이어 간의 거리 변수 생성
        if (JumpDist_ <= 3)
        {
            quizBar.gameObject.SetActive(true); 
            // 3 이하의 거리값이면 UI 활성화
        }
        else
            quizBar.gameObject.SetActive(false);
        
    }
}
