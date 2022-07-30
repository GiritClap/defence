using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField]
    // private GameObject enemyPrefab; // �� ������
    //[SerializeField]
    // private float spawnTime; // �� ���� �ֱ�
    [SerializeField]
    private Transform[] wayPoints; // ���� ���������� �̵� ���

    private List<Enemy> enemyList; // ���� �ʿ� �����ϴ� ��� ���� ����
    public List<Enemy> EnemyList => enemyList; // ���� ������ ������ EnemySpawner���� �ϱ� ������ Set�� �ʿ����

    [SerializeField]
    private GameObject enemyHpSliderPrefab; // �� ü���� ��Ÿ���� Slider UI ������
    [SerializeField]
    private Transform canvasTransform; // UI�� ǥ���ϴ� Canvas ������Ʈ�� Transform

    [SerializeField]
    private PlayerHp playerHp; // �÷��̾��� ü�� ������Ʈ
    [SerializeField]
    private PlayerGold playerGold; // �÷��̾��� ��� ������Ʈ

    private Wave currentWave; // ���� ���̺� ����
    private int currentEnemyCount; // ���� ���̺꿡 �����ִ� �� ���� (���̺� ���۽� max����, ����� -1)

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
            // GameObject clone = Instantiate(enemyPrefab); // �� ������Ʈ ����
            // ���̺꿡 �����ϴ� ���� ������ ���������� �� ������ ���� �����ϵ��� �����ϰ� ����
            int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
            GameObject clone = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
            Enemy enemy = clone.GetComponent<Enemy>(); // ��� ������ ���� enemy ������Ʈ

            enemy.SetUp(this, wayPoints); // wayPoint ������ �Ű������� SetUp() ȣ��
            enemyList.Add(enemy); // ����Ʈ�� ��� ������ �� ���� ����

            SpawnEnemyHpSlider(clone);

            // ���� ���̺꿡�� ������ ���� ���� +1
            spawnEnemyCount++;

            // yield return new WaitForSeconds(spawnTime); // spawnTime �ð� ���� ���
            yield return new WaitForSeconds(currentWave.spawnTime); // spawnTime �ð� ���� ���
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
        enemyList.Remove(enemy); // ����Ʈ���� ����ϴ� �� ���� ����
        Destroy(enemy.gameObject); // �� ������Ʈ ����
    }

    private void SpawnEnemyHpSlider(GameObject enemy)
    {
        // �� ü���� ��Ÿ���� Slider UI ����
        GameObject sliderClone = Instantiate(enemyHpSliderPrefab);
        // Slider UI ������Ʈ�� parent("Canvas"������Ʈ)�� �ڽ��� ����
        // UI�� ĵ������ �ڽĿ�����Ʈ�� �����Ǿ� �־�� ȭ�鿡 ���δ�!! 
        sliderClone.transform.SetParent(canvasTransform);
        // ���� �������� �ٲ� ũ�⸦ �ٽ� (1,1,1)�� ����
        sliderClone.transform.localScale = Vector3.one;

        // Slider UI �� �Ѿƴٴ� ����� �������� ����
        sliderClone.GetComponent<SliderPositionAutoSetter>().SetUp(enemy.transform);
        // Slider UI �� �ڽ��� ü�� ������ ǥ���ϵ��� ����
        sliderClone.GetComponent<EnemyHpViewer>().SetUp(enemy.GetComponent<EnemyHp>());
    }

}
