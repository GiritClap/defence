using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
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

    public void ReadyToSpawnTower()
    {
        if (isOnTowerButton == true)
        {
            return;
        }

        if (towerBuildGold > playerGold.CurrentGold)
        {
            return;
        }

        isOnTowerButton = true;
        followTowerClone = Instantiate(followTower);
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
        playerGold.CurrentGold -= towerBuildGold;
        // ������ Ÿ���� ��ġ�� Ÿ�� �Ǽ�
        GameObject clone = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner);
        Destroy(followTowerClone);
    }
}
