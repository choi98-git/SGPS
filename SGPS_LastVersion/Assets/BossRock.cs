using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRock : MonoBehaviour
{
    protected StatusHP thePlayerStatus;
    public int damage;
    public bool isMelee;
    Rigidbody rigid;

    // 회전 파워, 크기
    float angularPower = 2;
    float scaleValue = 0.1f;

    bool isShoot;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        StartCoroutine(GainPowerTimer());
        StartCoroutine(GainPower());
    }

    private void Start()
    {
        thePlayerStatus = FindObjectOfType<StatusHP>();
    }


    // 쏘는 타이밍 관리
    IEnumerator GainPowerTimer()
    {
        // 기모으는 시간이 2.2초후 발사
        yield return new WaitForSeconds(2.2f);
        isShoot = true;
    }
    IEnumerator GainPower()
    {
        while (!isShoot)
        {
            angularPower += 0.04f;
            scaleValue += 0.002f;
            transform.localScale = Vector3.one * scaleValue;
            rigid.AddTorque(transform.right * angularPower, ForceMode.Acceleration);
            Destroy(gameObject, 3.5f);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            thePlayerStatus.DecreaseHP(damage);
            Destroy(gameObject);
        }
    }
}
