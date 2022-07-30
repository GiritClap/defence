using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField]
    // private GameObject enemyPrefab; // 적 프리펩
    //[SerializeField]
    // private float spawnTime; // 적 생성 주기
    [SerializeField]
    private Transform[] wayPoints; // 현재 스테이지의 이동 경로

    private List<Enemy> enemyList; // 현재 맵에 존재하는 모든 적의 정보
    public List<Enemy> EnemyList => enemyList; // 적의 생성과 삭제는 EnemySpawner에서 하기 때문에 Set은 필요없다

    [SerializeField]
    private GameObject enemyHpSliderPrefab; // 적 체력을 나타내는 Slider UI 프리펩
    [SerializeField]
    private Transform canvasTransform; // UI를 표현하는 Canvas 오브젝트의 Transform

    [SerializeField]
    private PlayerHp playerHp; // 플레이어의 체력 컴포넌트
    [SerializeField]
    private PlayerGold playerGold; // 플레이어의 골드 컴포넌트

    private Wave currentWave; // 현재 웨이브 정보
    private int currentEnemyCount; // 현재 웨이브에 남아있는 적 숫자 (웨이브 시작시 max설정, 사망시 -1)

    public int CurrentEnemyCount => currentEnemyCount;
    public int MaxEnemyCount => currentWave.maxEnemyCount;

    private void Awake()
    {
        enemyList = new List<Enemy>();
        //StartCoroutine("SpawnEnemy");
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave;
        currentEnemyCount = currentWave.maxEnemyCount;
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        int spawnEnemyCount = 0;
        // while (true)
        while (spawnEnemyCount < currentWave.maxEnemyCount)
        {
            // GameObject clone = Instantiate(enemyPrefab); // 적 오브젝트 생성
            // 웨이브에 등장하는 적의 종류가 여러종류일 때 임의의 적이 등장하도록 설정하고 생성
            int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
            GameObject clone = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
            Enemy enemy = clone.GetComponent<Enemy>(); // 방금 생성한 적의 enemy 컴포넌트

            enemy.SetUp(this, wayPoints); // wayPoint 정보를 매개변수로 SetUp() 호출
            enemyList.Add(enemy); // 리스트에 방금 생성된 적 정보 저장

            SpawnEnemyHpSlider(clone);

            // 현재 웨이브에서 생성한 적의 숫자 +1
            spawnEnemyCount++;

            // yield return new WaitForSeconds(spawnTime); // spawnTime 시간 동안 대기
            yield return new WaitForSeconds(currentWave.spawnTime); // spawnTime 시간 동안 대기
        }
    }

    public void DestroyEnemy(EnemtDestroyType type, Enemy enemy, int gold)
    {
        if (type == EnemtDestroyType.Arrive)
        {
            playerHp.TakeDamage(1);
        }
        else if (type == EnemtDestroyType.Kill)
        {
            playerGold.CurrentGold += gold;
        }

        currentEnemyCount--;
        enemyList.Remove(enemy); // 리스트에서 사망하는 적 정보 삭제
        Destroy(enemy.gameObject); // 적 오브젝트 삭제
    }

    private void SpawnEnemyHpSlider(GameObject enemy)
    {
        // 적 체력을 나타내는 Slider UI 생성
        GameObject sliderClone = Instantiate(enemyHpSliderPrefab);
        // Slider UI 오브젝트를 parent("Canvas"오브젝트)의 자식을 설정
        // UI는 캔버스의 자식오브젝트로 설정되어 있어야 화면에 보인다!! 
        sliderClone.transform.SetParent(canvasTransform);
        // 계층 설정으로 바뀐 크기를 다시 (1,1,1)로 설정
        sliderClone.transform.localScale = Vector3.one;

        // Slider UI 가 쫓아다닐 대상을 본인으로 설정
        sliderClone.GetComponent<SliderPositionAutoSetter>().SetUp(enemy.transform);
        // Slider UI 에 자신의 체력 정보를 표시하도록 설정
        sliderClone.GetComponent<EnemyHpViewer>().SetUp(enemy.GetComponent<EnemyHp>());
    }

}
