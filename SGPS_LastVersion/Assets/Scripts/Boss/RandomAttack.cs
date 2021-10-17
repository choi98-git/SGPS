using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAttack : MonoBehaviour
{
    protected BossBasic theBossBasic;
    public GameObject missile;
    public Transform missilePortA;
    public Transform missilePortB;
    public Transform RockA;
    public Transform RockB;

    public Transform target;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()

    {
        StartCoroutine(RandomAttacks());
        theBossBasic = FindObjectOfType<BossBasic>();
    }



    // Update is called once per frame
    IEnumerator RandomAttacks()
    {
        yield return new WaitForSeconds(1.5f);
        if (theBossBasic.isDead == false)
        {
            int ranAction = Random.Range(0, 2);
            switch (ranAction)
            {
                // 미사일 발사
                case 0:
                    StartCoroutine(MissileShot());
                    break;

                // 돌 굴리기
                case 1:
                case 2:
                    StartCoroutine(RockShot());
                    break;

            }
        }
    }

    IEnumerator MissileShot()
    {

        yield return new WaitForSeconds(0.2f);
        GameObject instantMissileA = Instantiate(missile, missilePortA.position, missilePortA.rotation);
        BossMissile bossMissile = instantMissileA.GetComponent<BossMissile>();
        bossMissile.Target = target;

        yield return new WaitForSeconds(0.3f);
        GameObject instantMissileB = Instantiate(missile, missilePortB.position, missilePortB.rotation);
        BossMissile bossMissileB = instantMissileB.GetComponent<BossMissile>();
        bossMissileB.Target = target;

        yield return new WaitForSeconds(5f);
        StartCoroutine(RandomAttacks());
    }

    IEnumerator RockShot()
    {
        Instantiate(bullet, RockA.transform.position, RockA.transform.rotation);
        yield return new WaitForSeconds(3f);

        Instantiate(bullet, RockB.transform.position, RockB.transform.rotation);
        yield return new WaitForSeconds(5f);

        StartCoroutine(RandomAttacks());
    }
}
