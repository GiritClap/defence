using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTmpViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPlayerHp;
    [SerializeField]
    private PlayerHp playerHp;
    [SerializeField]
    private TextMeshProUGUI textPlayerGold;
    [SerializeField]
    private PlayerGold playerGold;
    [SerializeField]
    private TextMeshProUGUI textWave; 
    [SerializeField]
    private WaveSystem wave;
    [SerializeField]
    private TextMeshProUGUI textEnemyCount;
    [SerializeField]
    private EnemySpawner enemySpawner;

    // Update is called once per frame
    void Update()
    {
        textPlayerHp.text = playerHp.CurrentHp + " / " + playerHp.MaxHp;
        textPlayerGold.text = playerGold.CurrentGold.ToString();
        textWave.text = wave.CurrentWave + " / " + wave.MaxWave;
        textEnemyCount.text = enemySpawner.CurrentEnemyCount + " / " + enemySpawner.MaxEnemyCount;
    }
}
