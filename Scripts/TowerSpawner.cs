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

    public void SpawnTower(Transform tileTransform)
    {
        // Ÿ���� �Ǽ��� ��ŭ ���� ���ٸ� �Ǽ�x
        if (towerBuildGold > playerGold.CurrentGold)
        {
            return;
        }
        Tile tile = tileTransform.GetComponent<Tile>();

        // Ÿ�� �Ǽ� ���ɿ��� Ȯ��
        // ���� Ÿ�� ��ġ�� �̹� Ÿ���� �Ǽ��Ǿ� ������ Ÿ���Ǽ� ����
        if (tile.IsBuildTower == true)
        {
            return;
        }

        // Ÿ���� ��ġ�Ǿ� �����Ƿ� ����
        tile.IsBuildTower = true;
        // Ÿ�� ��ġ �� �� ����
        playerGold.CurrentGold -= towerBuildGold;
        // ������ Ÿ���� ��ġ�� Ÿ�� �Ǽ�
        GameObject clone = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner);
    }
}
