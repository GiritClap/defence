using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TowerTemplate : ScriptableObject
{
    public GameObject towerPrefab; // Ÿ�� ������ ���� ������
    public GameObject followTowerPrefab;
    public GameObject followTowerRangePrefab;
    public Weapon[] weapon; // ������ Ÿ�� ����

    [System.Serializable]
    public struct Weapon
    {
        public Sprite sprite; // �������� �̹���
        public string name; // �̸�
        public float damage; // ���ݷ�
        public float rate; // ���� �ӵ�
        public float slow; // ���� �ۼ�Ʈ (0.2 = 20%)
        public float range; // ���ݹ���
        public int cost; // �ʿ� ���
    }
}
