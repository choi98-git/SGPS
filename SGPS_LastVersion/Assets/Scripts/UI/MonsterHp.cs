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
        m_cam = Camera.main; //UI 확인을 위한 카메라

        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("WeakCr"); // NPC 태그의 오브젝트들에게 적용
        for(int i = 0; i < t_objects.Length; i++)
        {
            m_objectList.Add(t_objects[i].transform);
            GameObject t_hpbar = Instantiate(go, t_objects[i].transform.position, Quaternion.identity, transform);
            m_hpBarList.Add(t_hpbar);
            //NPC 태그의 오브젝트들에게 적용시킬 hp 스테이터스를 리스트에 추가한다.
        }
    }



    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< m_objectList.Count; i++)
        {
            m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(0, 1.8f, 0));
            // 스테이터스를 게임 화면에서 볼 수 있게 한다.
            if (m_hpBarList[i].transform.position.z < 0.0f)
            {
                m_hpBarList[i].transform.position *= -1.0f;
            } // z값이 반전, 즉 3D 공간에서 반대로 고개를 돌려도 스테이터스가 나타나지 않도록 방지
        }
    }
}
