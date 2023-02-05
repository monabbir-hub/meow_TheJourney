using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayer;

    
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        
    }

    void Attack()
    {
        //attack
        animator.SetTrigger("Attack");

        //detect
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, enemyLayer);

        //Damage
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We Hit" + enemy.name);

        }
        


    }
}
