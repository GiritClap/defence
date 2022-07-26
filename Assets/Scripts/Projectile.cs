using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Movement2D movement2D;
    private Transform target;
<<<<<<< HEAD
    private float damage;

    public void SetUp(Transform target, float damage)
=======
    private int damage;

    public void SetUp(Transform target, int damage)
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4
    {
        movement2D = GetComponent<Movement2D>();
        this.target = target;
        this.damage = damage;
    }

    private void Update()
    {
        if (target != null) // target 이 존재하면 
        {
            // 발사체를 target의 위치로 이동
            Vector3 direction = (target.position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        else // 여러 이유로 target이 사라지면
        {
            // 발사체 삭제
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        if (collision.transform != target)
        {
            return;
        }

        collision.GetComponent<EnemyHp>().TakeDamage(damage);
        Destroy(gameObject);

    }
}
