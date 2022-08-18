using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShop : MonoBehaviour
{

    public List<RandomTower> deck = new List<RandomTower>();
    public int total = 0;
    private RandomTower result;

    public GameObject[] towerPrefab;
    public Transform parent;
    private RandomTower temp;

    private GameObject[] towerUI = new GameObject[2];


    void Start()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            total += deck[i].weight;
        }
        ResultSelect();
    }

    public void ReRandom()
    {
        total = 0;
        result = null;  
        for(int i = 0; i < 2; i++)
        {
            Destroy(towerUI[i]);

        }
        for (int i = 0; i < deck.Count; i++)
        {
            total += deck[i].weight;
        }
        ResultSelect();
    }

    public void ResultSelect()
    {
        for (int i = 0; i < 2; i++)
        {
            // ����ġ ������ �����鼭 ��� ����Ʈ�� �־��ݴϴ�.
            result = RandTower();
            // ��� �ִ� ī�带 �����ϰ�
            if(temp.towerName.Equals("Tower01"))
            {
                towerUI[i] = Instantiate(towerPrefab[0], parent);
              
            } else if(temp.towerName.Equals("Tower02"))
            {
                towerUI[i] = Instantiate(towerPrefab[1], parent);
             

            }
            else if(temp.towerName.Equals("Tower03"))
            {
                towerUI[i] = Instantiate(towerPrefab[2], parent);
             

            }

            // ���� �� ī�忡 ��� ����Ʈ�� ������ �־��ݴϴ�.
            towerUI[i].GetComponent<ShopTowerInfo>().TowerUiSet(result);
        }

    }
    public RandomTower RandTower()
    {
        int weight = 0;
        int selectNum = 0;
        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));
        for (int i = 0; i < deck.Count; i++)
        {
            weight += deck[i].weight;
            if (selectNum <= weight)
            {
                temp = new RandomTower(deck[i]);
                return temp;
            }
        }
        return null;
    }



}
