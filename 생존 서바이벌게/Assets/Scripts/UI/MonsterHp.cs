using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHp : MonoBehaviour
{
    [SerializeField] GameObject go = null;

    List<Transform> m_objectList = new List<Transform>();
    List<GameObject> m_hpBarList = new List<GameObject>();

    Camera m_cam = null;
    // Start is called before the first frame update
    void Start()
    {
        m_cam = Camera.main;

        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("NPC");
        for(int i = 0; i < t_objects.Length; i++)
        {
            m_objectList.Add(t_objects[i].transform);
            GameObject t_hpbar = Instantiate(go, t_objects[i].transform.position, Quaternion.identity, transform);
            m_hpBarList.Add(t_hpbar);
        }
    }



    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< m_objectList.Count; i++)
        {
            m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(0, 1.8f, 0));
            if (m_hpBarList[i].transform.position.z < 0.0f)
            {
                m_hpBarList[i].transform.position *= -1.0f;
            }
        }
    }
}
