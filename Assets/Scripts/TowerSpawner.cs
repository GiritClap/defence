using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    private TowerTemplate towerTemplete; // 티워 정보
    //[SerializeField]
   // private GameObject towerPrefab;
    [SerializeField]
    private EnemySpawner enemySpawner;
    //[SerializeField]
    //private int towerBuildGold = 30; // 타워 건설 비용
    [SerializeField]
    private PlayerGold playerGold; //타워 건설 시 골드 감소
    private bool isOnTowerButton = false; // 타워 건설 버튼을 눌렀는지 체크

    private GameObject followTowerClone = null;
    private GameObject followTowerRangeClone = null;
=======
    private GameObject towerPrefab;
    [SerializeField]
    private EnemySpawner enemySpawner;
    [SerializeField]
    private int towerBuildGold = 30; // 타워 건설 비용
    [SerializeField]
    private PlayerGold playerGold; //타워 건설 시 골드 감소
    private bool isOnTowerButton = false; // 타워 건설 버튼을 눌렀는지 체크
    [SerializeField]
    private GameObject followTower; // 임시 타워 사용 완료 시 삭제를 위해 저장하는 변수
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
        // 타워를 건설할 만큼 돈이 없다면 건설x
        //if (towerBuildGold > playerGold.CurrentGold)
        //{
        //    return;
       // }
        Tile tile = tileTransform.GetComponent<Tile>();

        // 타워 건설 가능여부 확인
        // 현재 타일 위치에 이미 타워가 건설되어 있으면 타워건설 못함
        if (tile.IsBuildTower == true)
        {
            return;
        }

        // 타워가 설치되어 있으므로 설정
        tile.IsBuildTower = true;
        isOnTowerButton = false;
        // 타워 설치 시 돈 감소
<<<<<<< HEAD
        playerGold.CurrentGold -= towerTemplete.weapon[0].cost;
        Vector3 position = tileTransform.position + Vector3.back;
        // 선택한 타일의 위치에 타워 건설
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
        // 선택한 타일의 위치에 타워 건설
        GameObject clone = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner);
        Destroy(followTowerClone);
>>>>>>> 2cbccd66e2047ba39b8c2e87421efccca1a627a4
    }
}
