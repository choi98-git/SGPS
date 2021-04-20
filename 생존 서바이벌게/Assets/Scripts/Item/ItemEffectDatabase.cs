using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string ItemName; // 아이템 이름 키값.
    public string[] part; // 부위
    public int[] num; // 수치
}
public class ItemEffectDatabase : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;

    // 필요한 컴포넌트
    [SerializeField]
    private StatusController thePlayerStatus;

    private const string HP = "HP", SP = "SP", DP = "DP", HUNGRY = "HUNGRTY",
        THIRSTY = "THIRSTY", SATISFY = "SATISFY"; 

    public void UseItem(Item _item)
    {
        if(_item.itemType == Item.ItemType.Used)
        {
            for (int i = 0; i < itemEffects.Length; i++)
            {
                if(itemEffects[i].ItemName == _item.itemName)
                {
                    for(int j=0; j < itemEffects[i].part.Length; j++)
                    {
                        switch (itemEffects[i].part[j])
                        {
                            case HP :
                                thePlayerStatus.IncreaseHP(itemEffects[i].num[j]);
                                break; 
                            case DP:
                                thePlayerStatus.IncreaseDP(itemEffects[i].num[j]);
                                break;
                            case THIRSTY:
                                thePlayerStatus.IncreaseThirsty(itemEffects[i].num[j]);
                                break;
                            case HUNGRY:
                                thePlayerStatus.IncreaseHungry(itemEffects[i].num[j]);
                                break;
                            case SATISFY:
                                break;
                            default:
                                Debug.Log("잘못된 Status 부위 : HP, SP, DP, HUNGRTY, THIRSTY, SATISFY만 가능");
                                break;
                        }
                    }
                    return;
                }
            }
            Debug.Log("DB에 일치하는 아이템 이름이 없습니다");
        }
    }
}
