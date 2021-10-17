using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //무기 중복 실행 교체 방지
    public static bool isChangeWeapon = false;

    public static Transform currentWeapon;
    public static Animator currentWeaponAnim;

    [SerializeField]
    private string currentWeaponType;

    [SerializeField]
    private float changeWeaponDelayTime;
    [SerializeField]
    private float changeWeaponEndDelayTime;

    [SerializeField]
    private Gun[] guns;
    [SerializeField]
    private Hand[] hands;

    //손이나 총으로 전환하는 시스템을 관리할 딕셔너리 선언
    private Dictionary<string, Gun> gunDictionary = new Dictionary<string, Gun>();
    private Dictionary<string, Hand> handDictionary = new Dictionary<string, Hand>();

    //
    [SerializeField]
    private GunController theGunController;
    [SerializeField]
    private HandController theHandController;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            gunDictionary.Add(guns[i].gunName, guns[i]); 
            // gunDictionary에 새로운 gun 요소를 추가한다.
        }
        for (int i = 0; i < hands.Length; i++)
        {
            handDictionary.Add(hands[i].HandName, hands[i]);
            // gunDictionary에 새로운 hand 요소를 추가한다.
        }

        // gunDictionary.Add("AK47", guns[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isChangeWeapon)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                StartCoroutine(ChangeWeaponCoroutine("HAND", "맨손"));
            // 숫자 1번 누르면 맨손으로 교체
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                StartCoroutine(ChangeWeaponCoroutine("GUN", "SubMachineGun1"));
            // 숫자 2번 누르면 총으로 교체
        }
    }

    public IEnumerator ChangeWeaponCoroutine(string _type,string _name)
    {
        isChangeWeapon = true;
        currentWeaponAnim.SetTrigger("Weapon_Out");
        // 무기를 꺼내는 동작 애니메이션 실행

        yield return new WaitForSeconds(changeWeaponDelayTime);
        // 행동 전환 간의 딜레이 시간 

        CancelPreWeaponAction();
        WeaponChange(_type, _name);

        yield return new WaitForSeconds(changeWeaponEndDelayTime);
        currentWeaponType = _type;
        isChangeWeapon = false;
    }

    private void CancelPreWeaponAction()
    {
        switch(currentWeaponType)
        {
            case "GUN":
                theGunController.CancelFineSight(); // 정조준 상태 해제
                theGunController.CancelReload(); // 재장전 상태 해제
                GunController.isActive = false;
                break;
            case "HAND":
                HandController.isActive = false;
                break;
        }
    }

    private void WeaponChange(string _type, string _name)
    {
        if(_type == "GUN")
            theGunController.GunChange(gunDictionary[_name]); 
            // 딕셔너리에 저장된 총을 불러온 뒤 GunChange의 인자값으로 받는다.
        else if(_type== "HAND")
            theHandController.HandChange(handDictionary[_name]);
            // 위와 같이 딕셔너리에 저장된 맨손을 불러온다.

    }
}
