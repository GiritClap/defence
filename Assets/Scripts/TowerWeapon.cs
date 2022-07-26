using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState { SearchTarget = 0, AttackToTarget }
public class TowerWeapon : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    private TowerTemplate towerTemplete; // Ÿ�� ����
    [SerializeField]
    private GameObject projectilePrefab; // �߻�ü ������
    [SerializeField]
    private Transform spawnPoint; // �߻�ü ���� ��ġ
    
    
    private WeaponState weaponState = WeaponState.SearchTarget; // Ÿ���� �������
    private Transform attackTarget = null; // ���� ���
    private EnemySpawner enemySpawner; // ���ӿ� �����ϴ� �� ���� ȹ���
    private int level = 0; // Ÿ�� ����

    public Sprite TowerSprite => towerTemplete.weapon[level].sprite;
    public float AttackRange => towerTemplete.weapon[level].range;
    public float Damage => towerTemplete.weapon[level].damage;
    public float Rate => towerTemplete.weapon[level].rate;
    public float Level => level + 1;
    public string Name => towerTemplete.weapon[level].name;

    
=======
    private GameObject projectilePrefab; // �߻�ü ������
    [SerializeField]
    private Transform spawnPoint; // �߻�ü ���� ��ġ
    [SerializeField]
    private float attackRate = 0.5f; // ���� �ӵ�
    [SerializeField]
    private float attackRange = 2.0f; // ���ݹ���
    private WeaponState weaponState = WeaponState.SearchTarget; // Ÿ���� �������
    private Transform attackTarget = null; // ���� ���
    private EnemySpawner enemySpawner; // ���ӿ� �����ϴ� �� ���� ȹ���

    [SerializeField]
    private int attackDamage = 1; // ���ݷ�
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4

    public void SetUp(EnemySpawner enemySpawner)
    {
        this.enemySpawner = enemySpawner;
        // ���� ���¸� WeaponState.SearchTarget���� ����
        ChangeState(WeaponState.SearchTarget);
    }

    public void ChangeState(WeaponState newState)
    {
        // ������ ������̴� ���� ����
        StopCoroutine(weaponState.ToString());
        // ���� ����
        weaponState = newState;
        // ���ο� ���� ���
        StartCoroutine(weaponState.ToString());
    }

    private void Update()
    {
        if (attackTarget != null)
        {
            RotateToTarget();
        }
    }

    private void RotateToTarget()
    {
        float dx = attackTarget.position.x - transform.position.x;
        float dy = attackTarget.position.y - transform.position.y;
        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degree);
    }

    private IEnumerator SearchTarget()
    {
        while (true)
        {
            // ���� ������ �ִ� ���� ã�� ���� ���� �Ÿ��� �ִ��� ũ�� ����
            float closetDistSqr = Mathf.Infinity;

            // EnemySpawner�� EnemyList�� �ִ� ���� �ʿ� �����ϴ� ��� �� �˻�
            for (int i = 0; i < enemySpawner.EnemyList.Count; i++)
            {
                float distance = Vector3.Distance(enemySpawner.EnemyList[i].transform.position, transform.position);

                //���� �˻����� ������ �Ÿ��� ���ݹ��� ���� �ְ� ������� �˻��� ������ �Ÿ��� ������
<<<<<<< HEAD
                if (distance <= towerTemplete.weapon[level].range && distance <= closetDistSqr)
=======
                if (distance <= attackRange && distance <= closetDistSqr)
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4
                {
                    closetDistSqr = distance;
                    attackTarget = enemySpawner.EnemyList[i].transform;
                }
            }

            if (attackTarget != null)
            {
                ChangeState(WeaponState.AttackToTarget);
            }

            yield return null;

        }

    }

    private IEnumerator AttackToTarget()
    {
        while (true)
        {
            // 1. target�� �ִ��� �˻�(�ٸ� �߻�ü�� ���� ����, Goal�������� �̵��� ���� ���)
            if (attackTarget == null)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            // 2. target�� ���� ���� �ȿ� �ִ��� �˻�(���� ������ ����� ���ο� �� Ž��)
            float distance = Vector3.Distance(attackTarget.transform.position, transform.position);
<<<<<<< HEAD
            if (distance > towerTemplete.weapon[level].range)
=======
            if (distance > attackRange)
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4
            {
                attackTarget = null;
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            // 3. attackRate �ð���ŭ ���
<<<<<<< HEAD
            yield return new WaitForSeconds(towerTemplete.weapon[level].rate);
=======
            yield return new WaitForSeconds(attackRate);
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4

            // 4. ����(�߻�ü ����)
            SpawnProjectile();

        }
    }

    private void SpawnProjectile()
    {
        GameObject clone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
<<<<<<< HEAD
        clone.GetComponent<Projectile>().SetUp(attackTarget, towerTemplete.weapon[level].damage);
=======
        clone.GetComponent<Projectile>().SetUp(attackTarget, attackDamage);
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4
    }
}
