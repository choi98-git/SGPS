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
    }

    // Update is called once per frame
    void Update()
    {
        GaugeUpdate();
    }

   
    private void GaugeUpdate()
    {
        Pig_Hpbar.value = currentHP;
    }


    public void DecreaseHP(int _count)
    {
        if (currentHP > 0)
        {
            currentHP -= _count;
        }

        if (currentHP <= 0)
            currentHP = 0;
    }



    public int GetCurrentHP()
    {
        return currentHP;
    }

}
