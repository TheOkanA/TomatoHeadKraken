using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackArea;
    [SerializeField] private bool canAttack = true;
    public Animator animator;
    public float attackSpeed = 0.75f;

    public void PlayerAttackStart()
    {
        StartCoroutine(AttackMaker());
    }

    public IEnumerator AttackMaker()
    {
        if(canAttack)
        {
            animator.SetTrigger("Attack");
            canAttack = false;
            yield return new WaitForSeconds(0.35f);
            attackArea.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            attackArea.SetActive(false);
            yield return new WaitForSeconds(attackSpeed);
            canAttack = true;
        }
    }

}
