using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{

    //체력
    [SerializeField]
    private int hp;
    private int currentHp;

    [SerializeField]
    private Image[] images_Gauge;

    private const int HP = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
    }
    

    // Update is called once per frame
    void Update()
    {
        GaugeUpdate();

    }


    private void GaugeUpdate()
    {
        images_Gauge[HP].fillAmount = (float)currentHp / hp;
    }

    public void IncreaseHP(int _count)
    {
        if (currentHp + _count < hp)
            currentHp += _count;
        else
            currentHp = hp;
    }

    public void DecreaseHP(int _count)
    {
        if (currentHp > 0)
        {
            DecreaseHP(_count);
            return;
        }

        currentHp -= _count;

        if (currentHp <= 0)
            Debug.Log("캐릭터의 hp가 0이 되었습니다!!");
    }


}
