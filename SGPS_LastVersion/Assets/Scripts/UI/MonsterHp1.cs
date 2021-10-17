using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHp1 : MonoBehaviour
{
    public Slider Pig_Hpbar;
    [SerializeField]
    public int maxHp;
    public int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        Pig_Hpbar.value = maxHp; 
        //돼지 오브젝트와 스테이터스바를 연결
    }

    // Update is called once per frame
    void Update()
    {
        GaugeUpdate();
    }

    private void GaugeUpdate()
    {
        Pig_Hpbar.value = currentHP; 
        //현재의 기본 HP 업데이트
    }

    public void DecreaseHP(int _count)
    {
        if (currentHP > 0)
        {
            currentHP -= _count;
        } // 타격 횟수를 count로 받아 돼지의 HP를 감소

        if (currentHP <= 0)
            currentHP = 0;
    }



    public int GetCurrentHP()
    {
        return currentHP;
    }

}
