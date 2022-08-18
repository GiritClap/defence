using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { Cannon = 0, Slow }
public enum WeaponState { SearchTarget = 0, TryAttackCannon }
public class TowerWeapon : MonoBehaviour
{
    [Header("Cannon")]
    [SerializeField]
    private TowerTemplate towerTemplete; // Ÿ�� ����
    [SerializeField]
    private Transform spawnPoint; // �߻�ü ���� ��ġ
    [SerializeField]
    private WeaponType weaponType; // ���� �Ӽ� ����

    [Header("Cannon")]
    [SerializeField]
    private GameObject projectilePrefab; // �߻�ü ������


    private WeaponState weaponState = WeaponState.SearchTarget; // Ÿ���� �������
    private Transform attackTarget = null; // ���� ���
    private EnemySpawner enemySpawner; // ���ӿ� �����ϴ� �� ���� ȹ���
    private SpriteRenderer spriteRenderer;
    
    private int level = 0; // Ÿ�� ����

    public Sprite TowerSprite => towerTemplete.weapon[level].sprite;
    public float AttackRange => towerTemplete.weapon[level].range;
    public float Damage => towerTemplete.weapon[level].damage;
    public float Rate => towerTemplete.weapon[level].rate;
    public float Level => level + 1;
    public string Name => towerTemplete.weapon[level].name;
    public float Slow => towerTemplete.weapon[level].slow;
    public int MaxLevel => towerTemplete.weapon.Length;
    public int MaxExp => towerTemplete.weapon[level].maxExp;
    public int CurExp => towerTemplete.weapon[level].curExp;
    public int Exp => towerTemplete.weapon[level].exp;

    public WeaponType WeaponType => weaponType;

    

    public void SetUp(EnemySpawner enemySpawner)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.enemySpawner = enemySpawner;
        // ���� ���¸� WeaponState.SearchTarget���� ����
        if(weaponType == WeaponType.Cannon)
        {
            ChangeState(WeaponState.SearchTarget);
        }
       
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
            attackTarget = FindClosestAttackTarget();

            if (attackTarget != null)
            {
                ChangeState(WeaponState.TryAttackCannon);
            }

            yield return null;

        }

    }

    private IEnumerator TryAttackCannon()
    {
        while (true)
        {
            // target�� �����ϴ°� �������� �˻�
            if(IsPossivleToAttackTarget() == false)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            // attackRate �ð���ŭ ���
            yield return new WaitForSeconds(towerTemplete.weapon[level].rate);

            // 4. ����(�߻�ü ����)
            SpawnProjectile();

        }
    }

    private Transform FindClosestAttackTarget()
    {
        // ���� ������ �ִ� ���� ã�� ���� ���� �Ÿ��� �ִ��� ũ�� ����
        float closestDistSqr = Mathf.Infinity;
        // EnemySpawnwer�� EnemyList�� �ִ� ���� �ʿ� �����ϴ� ��� �� �˻�
        for(int i = 0; i < enemySpawner.EnemyList.Count; i++)
        {
            float distance = Vector3.Distance(enemySpawner.EnemyList[i].transform.position, transform.position);
            // ���� �˻����� ������ �Ÿ��� ���ݹ��� ���� �ְ�, ������� �˻��� ������ �Ÿ��� ������
            if(distance <= towerTemplete.weapon[level].range && distance <= closestDistSqr)
            {
                closestDistSqr = distance;
                attackTarget = enemySpawner.EnemyList[i].transform;
            }
        }
        return attackTarget;
    }

    private bool IsPossivleToAttackTarget()
    {

        // target�� �ִ��� �˻�
        if(attackTarget == null)
        {
            return false;
        }

        // target�� ���� ���� �ȿ� �ִ��� �˻�(���� ������ ����� ���ο� �� Ž��)
        float distance = Vector3.Distance(attackTarget.position,transform.position);
        if(distance > towerTemplete.weapon[level].range)
        {
            attackTarget = null;
            return false;
        }
        return true;
    }

    private void SpawnProjectile()
    {
        GameObject clone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<Projectile>().SetUp(attackTarget, towerTemplete.weapon[level].damage);
    }

    public bool Upgrade()
    {
        towerTemplete.weapon[level].curExp += towerTemplete.weapon[level].exp;
        if(towerTemplete.weapon[level].maxExp < towerTemplete.weapon[level].curExp)
        {
           return false;
        }
        level++;
        spriteRenderer.sprite = towerTemplete.weapon[level].sprite;
        return true; 
    }
}
