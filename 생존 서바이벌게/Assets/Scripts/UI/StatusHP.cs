using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusHP : MonoBehaviour
{

    public Slider HPbar;
    

    //체력
    [SerializeField]
    private int hp;
    private int currentHP;


    private const int HP = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = hp;
    }
    

    // Update is called once per frame
    void Update()
    {
        GaugeUpdate();

    }


    private void GaugeUpdate()
    {
        HPbar.value = currentHP;
    }

    public void IncreaseHP(int _count)
    {
        if (currentHP + _count < hp)
            currentHP += _count;
        else
            currentHP = hp;
    }

    public void DecreaseHP(int _count)
    {
        if (currentHP > 0)
        {
                currentHP -= _count;
        }

        if(currentHP <= 0)
            currentHP = 0;
    }


    public int GetCurrentHP()
    {
        return currentHP;
    }

}
