using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShit : MonoBehaviour
{
    public GameObject Center; //회전 축
    public float Speed; //회전 속도

    // Update is called once per frame
    void Update()
    {
        OrbitAround();
    }

    void OrbitAround()
    {
        transform.RotateAround(Center.transform.position, Vector3.down, Speed * Time.deltaTime);
        //중심 값을 지정하고 어느 방향으로 얼마의 속도로 공전할지 지정하는 함수
    }
}
