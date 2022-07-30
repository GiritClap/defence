using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




/// <summary>
///  This is For Test.
/// </summary>



public class SpriteManager : MonoBehaviour
{
    [SerializeField] float fadeSpeed;


    public SpriteRenderer[] MainSpriteRenderer;

    public SpriteRenderer[] OppoSpriteRenderer;


    bool CheckSameSprite_Oppo(SpriteRenderer p_SpriteRenderer, Sprite p_Sprite)
    {
        if (p_SpriteRenderer.sprite == p_Sprite)
            return true;
        else
            return false;
    }


    public IEnumerator SpriteChangeCoroutine_Oppo(Transform OppoCG, string OppoSpriteName)
    {


        SpriteRenderer[] t_SpriteRenderer = OppoSpriteRenderer;

        Sprite Oppo_Sprite = Resources.Load("Characters/" + OppoSpriteName, typeof(Sprite)) as Sprite;

        Debug.Log("1");


        t_SpriteRenderer[0].sprite = Oppo_Sprite;


        yield return null;


    }

    public IEnumerator SpriteChangeCoroutine_Main(Transform MainCG, string MainSpriteName)
    {


        SpriteRenderer[] t_SpriteRenderer = MainSpriteRenderer;

        Sprite Main_Sprite = Resources.Load("Characters/" + MainSpriteName, typeof(Sprite)) as Sprite;

        Debug.Log("2");


        t_SpriteRenderer[0].sprite = Main_Sprite;


        yield return null;


    }

}


