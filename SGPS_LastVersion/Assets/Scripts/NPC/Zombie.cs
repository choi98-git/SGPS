using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Strong
{
    protected override void Update()
    {
        base.Update();
        if (theViewAngle.View() && !isDead && !isAttacking)
        {
            StopAllCoroutines();
            StartCoroutine(ChaseTargetCoroutine());
        }
    }

    protected override void ReSet()
    {
        base.ReSet();
    }

}
