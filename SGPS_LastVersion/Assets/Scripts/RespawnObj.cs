using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObj : MonoBehaviour
{
    // 오브젝트가 리스폰 될 위치들을 리스트를 통해 선언한다.
    List<Transform> spawnPos = new List<Transform>();

    // 몬스터는 여러마리, 여러 종류가 소환될 수 있으므로 배열로 선언
    GameObject[] monsters;
    
    // 리스폰할 몬스터 오브젝트를 인스펙터 창에서 지정
    public GameObject monPrefab;
   
    // 리스폰할 오브젝트 개수
    public int spawnNumber;

    int deadMonsters = 0;
    // Start is called before the first frame update
    void Start()
    {
        MakeSpawnPos();
    }

    void MakeSpawnPos()
    { 
        foreach(Transform pos in transform)
        {
            if(pos.tag == "Respawn") //pos는 오브젝트가 소환될 정확한 좌표값이다. 그 좌표값 개수를 Respawn태그로 지정한다.
            {
                spawnPos.Add(pos); //오브젝트 생성 위치 값 개수를 늘리기 위한 ADD() 사용
            }
        }
        if(spawnNumber > spawnPos.Count)
        {
            spawnNumber = spawnPos.Count;
        }

        monsters = new GameObject[spawnNumber];

        MakeMonsters();
    }

    void MakeMonsters()
    {
        for(int i=0; i<spawnNumber; i++)
        {
            GameObject mon = Instantiate(monPrefab, spawnPos[i].position, Quaternion.identity) as GameObject;
            mon.SetActive(false);

            monsters[i] = mon; // 스폰할 개수만큼 몬스터를 생성한다.
        }
    }

    void SpawnMonster()
    {
        for(int i=0; i<monsters.Length; i++)
        {
            monsters[i].SetActive(true);
        } // 리스폰 전에 보이지 않던 몬스터들이 리스폰 적용 후 맵에 나타난다.
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            SpawnMonster();
            GetComponent<SphereCollider>().enabled = false;
        } // 플레이어가 일정 범위안에 들어오면 리스폰이 활성화된다.
    }
   
}
