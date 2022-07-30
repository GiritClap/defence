using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopTowerInfo : MonoBehaviour
{
    public Image towerImage;
    public TextMeshProUGUI towerText;
    public TowerGrade towerGrade;

    public void TowerUiSet(RandomTower randomTower)
    {
        towerImage.sprite = randomTower.towerImage;
        towerText.text = randomTower.towerName;
        towerGrade = randomTower.towerGrade;
    }

    
}
