using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerGrade {S,A,B,C,D,E,F }

[System.Serializable]
public class RandomTower
{
    public string towerName;
    public Sprite towerImage;
    public TowerGrade towerGrade;
    public int weight;

    public RandomTower(RandomTower randomTower)
    {
        this.towerName = randomTower.towerName;
        this.towerGrade = randomTower.towerGrade;
        this.towerImage = randomTower.towerImage;
        this.weight = randomTower.weight;
    }
}
