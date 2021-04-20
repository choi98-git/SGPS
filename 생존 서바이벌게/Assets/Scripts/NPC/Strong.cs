using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strong : Animal
{

    [SerializeField]
    protected int attackDamage; // 공격 데미지
    [SerializeField]
    protected float attackDelay; // 공격 딜레이
    [SerializeField]
    protected LayerMask targetMask;

    public GameObject Blood;

    [SerializeField]
    protected float ChaseTime;
    protected float currentChaseTime;

    [SerializeField]
    protected float ChaseDelayTime;

    public void Chase(Vector3 _targetPos)
    {
        isChasing = true;
        destination = _targetPos;
        nav.speed = runSpeed;
        isRunning = true;
        anim.SetBool("Running", isRunning);
        nav.SetDestination(destination);
    }

    public override void Damage(int _dmg, Vector3 _targetPos)
    {
        base.Damage(_dmg, _targetPos);
        if (!isDead)
            Chase(_targetPos);
    }

    protected IEnumerator ChaseTargetCoroutine()
    {
        currentChaseTime = 0;

        while (currentChaseTime < ChaseTime)
        {
            Chase(theViewAngle.GetTargetPos()); //충분히 가까이 있고
            if (Vector3.Distance(transform.position, theViewAngle.GetTargetPos()) <= 3f)
            {
                if (theViewAngle.View()) //바로 눈 앞에 있을 경우
                {
                    Debug.Log("공격 시도!");
                    StartCoroutine(AttackCoroutine());
                }
            }
            yield return new WaitForSeconds(ChaseDelayTime);
            currentChaseTime += ChaseDelayTime;
        }

        isChasing = false;
        nav.ResetPath();
    }

    protected IEnumerator AttackCoroutine()
    {
        isAttacking = true;
        nav.ResetPath();
        currentChaseTime = ChaseTime;
        yield return new WaitForSeconds(0.5f);
        transform.LookAt(theViewAngle.GetTargetPos()); // 플레이어를 바라보게 만든다.
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);
        RaycastHit _hit;
        if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out _hit, 3, targetMask))
        {
            Blood.gameObject.SetActive(true);
            thePlayerStatus.DecreaseHP(attackDamage);
            Debug.Log("플레이어 적중!!");
            
        }
        else
        {
            
            Debug.Log("회피!!");
        }
        yield return new WaitForSeconds(attackDelay);
        Blood.gameObject.SetActive(false);
        isAttacking = false;
        StartCoroutine(ChaseTargetCoroutine());
    }

}
