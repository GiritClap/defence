using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    private float maxHp; // 최대 체력
    private float currentHp; // 현재 체력

    public float MaxHp => maxHp;
    public float CurrentHp => currentHp;

    private bool isDie = false; // 적이 사망하면 true
    private Enemy enemy;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHp = maxHp;
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        if(isDie == true)
        {
            return;
        }

        currentHp -= damage;
        StopCoroutine("HitAlphaAnimation");
        StartCoroutine("HitAlphaAnimation");

        if(currentHp <= 0)
        {
            isDie = true;
            enemy.onDie(EnemtDestroyType.Kill);
        }
    }

    private IEnumerator HitAlphaAnimation()
    {
        Color color = spriteRenderer.color;
        color.a = 0.4f;
        spriteRenderer.color = color;

        yield return new WaitForSeconds(0.05f);

        color.a = 1.0f;
        spriteRenderer.color = color;
    }
}
