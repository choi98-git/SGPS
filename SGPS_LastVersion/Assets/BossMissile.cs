using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMissile : MonoBehaviour
{
    protected StatusHP thePlayerStatus;
    public int damage;
    public bool isMelee;
    public Transform Target;
    NavMeshAgent nav;
    
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        thePlayerStatus = FindObjectOfType<StatusHP>();
    }

    void Update()
    {
        nav.SetDestination(Target.position);
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            thePlayerStatus.DecreaseHP(damage);
            Destroy(gameObject);
        }
    }

}
