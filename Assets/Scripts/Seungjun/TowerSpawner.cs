using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private TowerTemplate[] towerTemplete; // Ƽ�� ����
                                           //[SerializeField]
                                           // private GameObject towerPrefab;
    [SerializeField]
    private EnemySpawner enemySpawner;

    private GameObject towerButtonObject = null;


    //[SerializeField]
    //private int towerBuildGold = 30; // Ÿ�� �Ǽ� ���
    [SerializeField]
    private PlayerGold playerGold; //Ÿ�� �Ǽ� �� ��� ����

    private bool isOnTowerButton = false; // Ÿ�� �Ǽ� ��ư�� �������� üũ


    private GameObject followTowerClone = null;
    private GameObject followTowerRangeClone = null;

    private int towerType;



    public void ReadyToSpawnTower(int type)
    {
        towerType = type;
        if (isOnTowerButton == true)
        {
            return;
        }

        if (towerTemplete[towerType].weapon[0].cost > playerGold.CurrentGold)
        {
            return;
        }

        isOnTowerButton = true;
        followTowerClone = Instantiate(towerTemplete[towerType].followTowerPrefab);
        followTowerRangeClone = Instantiate(towerTemplete[towerType].followTowerRangePrefab);
        StartCoroutine("OnTowerCancelSystem");
    }

    public void SpawnTower(Transform tileTransform)
    {
        if (isOnTowerButton == false)
        {
            return;
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
        playerGold.CurrentGold -= towerTemplete[towerType].weapon[0].cost;
        Vector3 position = tileTransform.position + Vector3.back;
        // ������ Ÿ���� ��ġ�� Ÿ�� �Ǽ�
        GameObject clone = Instantiate(towerTemplete[towerType].towerPrefab, position, Quaternion.identity);
        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner, playerGold, tile, towerType);
        Destroy(followTowerClone);
        Destroy(followTowerRangeClone);

        StopCoroutine("OnTowerCancelSystem");
    }

    public void UpGradeTower(Transform towerWeapon)
    {
        if (isOnTowerButton == false)
        {
            return;
        }
        isOnTowerButton = false;

        TowerWeapon currentTower = towerWeapon.GetComponent<TowerWeapon>();
        currentTower.Upgrade();

        Destroy(followTowerClone);
        Destroy(followTowerRangeClone);
        StopCoroutine("OnTowerCancelSystem");

    }

    private IEnumerator OnTowerCancelSystem()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {

                towerButtonObject.SetActive(true);

                isOnTowerButton = false;
                Destroy(followTowerClone);
                Destroy(followTowerRangeClone);

                break;

            }
            yield return null;

        }
    }

    public void getGameObjecttoSetActive(GameObject gameObject)
    {
        towerButtonObject = gameObject;
    }
}
