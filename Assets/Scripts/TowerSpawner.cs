using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    private TowerTemplate towerTemplete; // Ƽ�� ����
    //[SerializeField]
   // private GameObject towerPrefab;
    [SerializeField]
    private EnemySpawner enemySpawner;
    //[SerializeField]
    //private int towerBuildGold = 30; // Ÿ�� �Ǽ� ���
    [SerializeField]
    private PlayerGold playerGold; //Ÿ�� �Ǽ� �� ��� ����
    private bool isOnTowerButton = false; // Ÿ�� �Ǽ� ��ư�� �������� üũ

    private GameObject followTowerClone = null;
    private GameObject followTowerRangeClone = null;
=======
    private GameObject towerPrefab;
    [SerializeField]
    private EnemySpawner enemySpawner;
    [SerializeField]
    private int towerBuildGold = 30; // Ÿ�� �Ǽ� ���
    [SerializeField]
    private PlayerGold playerGold; //Ÿ�� �Ǽ� �� ��� ����
    private bool isOnTowerButton = false; // Ÿ�� �Ǽ� ��ư�� �������� üũ
    [SerializeField]
    private GameObject followTower; // �ӽ� Ÿ�� ��� �Ϸ� �� ������ ���� �����ϴ� ����
    private GameObject followTowerClone;
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4

    public void ReadyToSpawnTower()
    {
        if (isOnTowerButton == true)
        {
            return;
        }

<<<<<<< HEAD
        if (towerTemplete.weapon[0].cost > playerGold.CurrentGold)
=======
        if (towerBuildGold > playerGold.CurrentGold)
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4
        {
            return;
        }

        isOnTowerButton = true;
<<<<<<< HEAD
        followTowerClone = Instantiate(towerTemplete.followTowerPrefab);
        followTowerRangeClone = Instantiate(towerTemplete.followTowerRangePrefab);
        StartCoroutine("OnTowerCancelSystem");
=======
        followTowerClone = Instantiate(followTower);
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4
    }

    public void SpawnTower(Transform tileTransform)
    {
        if(isOnTowerButton == false)
        {
            return ;
        }
        // Ÿ���� �Ǽ��� ��ŭ ���� ���ٸ� �Ǽ�x
        //if (towerBuildGold > playerGold.CurrentGold)
        //{
        //    return;
       // }
        Tile tile = tileTransform.GetComponent<Tile>();

        // Ÿ�� �Ǽ� ���ɿ��� Ȯ��
        // ���� Ÿ�� ��ġ�� �̹� Ÿ���� �Ǽ��Ǿ� ������ Ÿ���Ǽ� ����
        if (tile.IsBuildTower == true)
        {
            return;
        }

        // Ÿ���� ��ġ�Ǿ� �����Ƿ� ����
        tile.IsBuildTower = true;
        isOnTowerButton = false;
        // Ÿ�� ��ġ �� �� ����
<<<<<<< HEAD
        playerGold.CurrentGold -= towerTemplete.weapon[0].cost;
        Vector3 position = tileTransform.position + Vector3.back;
        // ������ Ÿ���� ��ġ�� Ÿ�� �Ǽ�
        GameObject clone = Instantiate(towerTemplete.towerPrefab, position, Quaternion.identity);
        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner);
        Destroy(followTowerClone);
        Destroy(followTowerRangeClone);
        StopCoroutine("OnTowerCancelSystem");
    }

    private IEnumerator OnTowerCancelSystem()
    {
        while(true)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                isOnTowerButton = false;
                Destroy(followTowerClone);
                Destroy(followTowerRangeClone);
                break;

            }
            yield return null;

        }
=======
        playerGold.CurrentGold -= towerBuildGold;
        // ������ Ÿ���� ��ġ�� Ÿ�� �Ǽ�
        GameObject clone = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner);
        Destroy(followTowerClone);
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4
    }
}
