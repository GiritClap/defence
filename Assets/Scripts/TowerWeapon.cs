using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState { SearchTarget = 0, AttackToTarget }
public class TowerWeapon : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    private TowerTemplate towerTemplete; // 타워 정보
    [SerializeField]
    private GameObject projectilePrefab; // 발사체 프리펩
    [SerializeField]
    private Transform spawnPoint; // 발사체 생성 위치
    
    
    private WeaponState weaponState = WeaponState.SearchTarget; // 타워의 무기상태
    private Transform attackTarget = null; // 공격 대상
    private EnemySpawner enemySpawner; // 게임에 존재하는 적 정보 획득용
    private int level = 0; // 타워 레벨

    public Sprite TowerSprite => towerTemplete.weapon[level].sprite;
    public float AttackRange => towerTemplete.weapon[level].range;
    public float Damage => towerTemplete.weapon[level].damage;
    public float Rate => towerTemplete.weapon[level].rate;
    public float Level => level + 1;
    public string Name => towerTemplete.weapon[level].name;

    
=======
    private GameObject projectilePrefab; // 발사체 프리펩
    [SerializeField]
    private Transform spawnPoint; // 발사체 생성 위치
    [SerializeField]
    private float attackRate = 0.5f; // 공격 속도
    [SerializeField]
    private float attackRange = 2.0f; // 공격범위
    private WeaponState weaponState = WeaponState.SearchTarget; // 타워의 무기상태
    private Transform attackTarget = null; // 공격 대상
    private EnemySpawner enemySpawner; // 게임에 존재하는 적 정보 획득용

    [SerializeField]
    private int attackDamage = 1; // 공격력
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4

    public void SetUp(EnemySpawner enemySpawner)
    {
        this.enemySpawner = enemySpawner;
        // 최초 상태를 WeaponState.SearchTarget으로 설정
        ChangeState(WeaponState.SearchTarget);
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
            // 제일 가까이 있는 적을 찾기 위해 최초 거리를 최대한 크게 설정
            float closetDistSqr = Mathf.Infinity;

            // EnemySpawner의 EnemyList에 있는 현재 맵에 존재하는 모든 적 검사
            for (int i = 0; i < enemySpawner.EnemyList.Count; i++)
            {
                float distance = Vector3.Distance(enemySpawner.EnemyList[i].transform.position, transform.position);

                //현재 검사중인 적과의 거리가 공격범위 내에 있고 현재까지 검사한 적보다 거리가 가까우면
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
            // 1. target이 있는지 검사(다른 발사체에 의해 제거, Goal지점까지 이동해 삭제 등등)
            if (attackTarget == null)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            // 2. target이 공격 범위 안에 있는지 검사(공격 범위를 벗어나면 새로운 적 탐색)
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
            // 3. attackRate 시간만큼 대기
<<<<<<< HEAD
            yield return new WaitForSeconds(towerTemplete.weapon[level].rate);
=======
            yield return new WaitForSeconds(attackRate);
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4

            // 4. 공격(발사체 생성)
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
