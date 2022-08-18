using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { Cannon = 0, Slow }
public enum WeaponState { SearchTarget = 0, TryAttackCannon }
public class TowerWeapon : MonoBehaviour
{
    [Header("Cannon")]
    [SerializeField]
    private TowerTemplate towerTemplete; // 타워 정보
    [SerializeField]
    private Transform spawnPoint; // 발사체 생성 위치
    [SerializeField]
    private WeaponType weaponType; // 무기 속성 설정

    [Header("Cannon")]
    [SerializeField]
    private GameObject projectilePrefab; // 발사체 프리펩


    private WeaponState weaponState = WeaponState.SearchTarget; // 타워의 무기상태
    private Transform attackTarget = null; // 공격 대상
    private EnemySpawner enemySpawner; // 게임에 존재하는 적 정보 획득용
    private SpriteRenderer spriteRenderer;
    
    private int level = 0; // 타워 레벨

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
        // 최초 상태를 WeaponState.SearchTarget으로 설정
        if(weaponType == WeaponType.Cannon)
        {
            ChangeState(WeaponState.SearchTarget);
        }
       
    }

    public void ChangeState(WeaponState newState)
    {
        // 이전에 재생중이던 상태 종료
        StopCoroutine(weaponState.ToString());
        // 상태 변경
        weaponState = newState;
        // 새로운 상태 재생
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
            // target을 공격하는게 가능한지 검사
            if(IsPossivleToAttackTarget() == false)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            // attackRate 시간만큼 대기
            yield return new WaitForSeconds(towerTemplete.weapon[level].rate);

            // 4. 공격(발사체 생성)
            SpawnProjectile();

        }
    }

    private Transform FindClosestAttackTarget()
    {
        // 제일 가까이 있는 적을 찾기 위해 최초 거리를 최대한 크게 설정
        float closestDistSqr = Mathf.Infinity;
        // EnemySpawnwer의 EnemyList에 있는 현재 맵에 존재하는 모든 적 검사
        for(int i = 0; i < enemySpawner.EnemyList.Count; i++)
        {
            float distance = Vector3.Distance(enemySpawner.EnemyList[i].transform.position, transform.position);
            // 현재 검사중인 적과의 거리가 공격범위 내에 있고, 현재까지 검사한 적보다 거리가 가까우면
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

        // target이 있는지 검사
        if(attackTarget == null)
        {
            return false;
        }

        // target이 공격 범위 안에 있는지 검사(공격 범위를 벗어나면 새로운 적 탐색)
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
