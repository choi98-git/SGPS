using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusSP : MonoBehaviour
{
    public Slider SPbar;

    // 스태미나 값
    [SerializeField]
    public int  maxSp;
    public int currentSP;

    // 스태미나 증가량
    [SerializeField]
    private int spIncreaseSpeed;

    // 스태미나 재회복 딜레이.
    [SerializeField]
    private int spRechargeTime;
    private int currentSpRechargeTime;

    // 스태미나 감소 여부
    private bool spUsed;


    // Start is called before the first frame update
    void Start()
    {
        SPbar.value = maxSp;
    }

    // Update is called once per frame
    void Update()
    {
        GaugeUpdate();
        SPRechargeTime();
        SPRecover();
    }

    // 스태미나 회복 딜레이
    private void SPRechargeTime()
    {
        if (spUsed)
        {
            if (currentSpRechargeTime < spRechargeTime)
                currentSpRechargeTime++;
            else
                spUsed = false;
        }

    }

    //스태미나 회복
    private void SPRecover()
    {
        if (!spUsed && currentSP < maxSp)
        {
            currentSP += spIncreaseSpeed;
        }
    }

    // 상태 업데이트
    private void GaugeUpdate()
    {
        SPbar.value = currentSP;
    }

    // 스태미나 감소
    public void DecreaseStamina(int _count)
    {
        spUsed = true;
        currentSpRechargeTime = 0;

        if (currentSP - _count > 0)
            currentSP -= _count;
        else
            currentSP = 0;
    }

    public int GetCurrentSP()
    {
        return currentSP;
    }
}

