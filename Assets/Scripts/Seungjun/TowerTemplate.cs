using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TowerTemplate : ScriptableObject
{
    public GameObject towerPrefab; // 타워 생성을 위한 프레팹
    public GameObject followTowerPrefab;
    public GameObject followTowerRangePrefab;
    public Weapon[] weapon; // 레벨별 타워 정보

    [System.Serializable]
    public struct Weapon
    {
        public Sprite sprite; // 보여지는 이미지
        public string name; // 이름
        public float damage; // 공격력
        public float rate; // 공격 속도
        public float slow; // 감속 퍼센트 (0.2 = 20%)
        public float range; // 공격범위
        public int cost; // 필요 비용
    }
}
