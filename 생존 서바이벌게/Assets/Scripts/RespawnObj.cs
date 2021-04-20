using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObj : MonoBehaviour
{
    List<Transform> spawnPos = new List<Transform>();
    GameObject[] monsters;

    public GameObject monPrefab;
    public int spawnNumber = 1;

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
            if(pos.tag == "Respawn")
            {
                spawnPos.Add(pos);
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

            monsters[i] = mon;
        }
    }

    void SpawnMonster()
    {
        for(int i=0; i<monsters.Length; i++)
        {
            monsters[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            SpawnMonster();
            GetComponent<SphereCollider>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
