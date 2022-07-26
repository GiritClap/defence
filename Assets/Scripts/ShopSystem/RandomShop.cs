using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShop : MonoBehaviour
{
    private int level;
    public List<RandomTower> deck = new List<RandomTower>();
    public int total = 0;
    public List<RandomTower> result = new List<RandomTower> ();

    public void ResultSelect()
    {
        result.Add(RandTower());
    }
    public RandomTower RandTower()
    {
        int weight = 0;
        int selectNum = 0;
        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));
        for(int i = 0; i < deck.Count; i++)
        {
            weight += deck[i].weight;
            if(selectNum <= weight)
            {
                RandomTower temp = new RandomTower(deck[i]);
                return temp;
            }
        }
        return null;
    }

    void Start()
    {
        for(int i = 0; i < deck.Count; i++)
        {
            total += deck[i].weight;
        }
    }
    // onClick으로 조절할 레벨업
    public void LevelUp()
    {
        level++;
    }
}
