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
        if (target != null) // target �� �����ϸ� 
        {
            // �߻�ü�� target�� ��ġ�� �̵�
            Vector3 direction = (target.position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        else // ���� ������ target�� �������
        {
            // �߻�ü ����
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
