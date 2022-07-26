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
        public float damage; // ���ݷ�
        public float rate; // ���� �ӵ�
        public string name; // �̸�
        public float range; // ���ݹ���
        public int cost; // �ʿ� ���
    }
}
