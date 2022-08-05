using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{



    public bool isContact = false;
    public static bool IsInteract = false;

    [SerializeField] ParticleSystem Ps_QmarkEffect;


    DialogueManager theDM;
    InteractionEvent theInt;

    public void SettingUI(bool p_flag)
    {
        //go_Crosshair.SetActive(p_flag);
        //go_Cursor.SetActive(p_flag);
        //go_TargetNameBar.SetActive(p_flag);

        IsInteract = !p_flag;

    }

    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theInt = FindObjectOfType<InteractionEvent>();

    }


    void Update()
    {
        //StartInteract();

    }

    /*
    void StartInteract()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isContact)
            {
                if (!IsInteract)
                {
                    Interact();
                }

            }
        }


    }
    */

    /*
    IEnumerator Interaction(bool p_Appear)
    {
       
        Color color = img_Interaction.color;
        if (p_Appear)
        {
            color.a = 0;
            while (color.a < 1)
            {
                color.a += 0.01f;
                img_Interaction.color = color;
                yield return null;
            }
        }
        else
        {
            while (color.a > 0)
            {
                color.a -= 0.01f;
                img_Interaction.color = color;
                yield return null;
            }
        }


    }
    */

    /*
    IEnumerator InteractionEffect()
    {
        while (IsContact && !IsInteract)
        {
            Color color = img_InteractionEffect.color;
            color.a = 0.5f;

            img_InteractionEffect.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            Vector3 t_scale = img_InteractionEffect.transform.localScale;

            while (color.a > 0)
            {
                color.a -= 0.001f;
                img_InteractionEffect.color = color;

                t_scale.Set(t_scale.x + Time.deltaTime, t_scale.y + Time.deltaTime, t_scale.z + Time.deltaTime);
                img_InteractionEffect.transform.localScale = t_scale;
                yield return null;
            }
            yield return null;

        }

    }

    */





    public void Interact()
    {
        IsInteract = true;

        theDM.ShowDialogue(theInt.GetDialogue());

        //StopCoroutine("Interaction");
        //Color color = img_Interaction.color;
        //color.a = 0;
        //img_Interaction.color = color;



        //Ps_QmarkEffect.gameObject.SetActive(true);
        //Vector3 t_targetPos = hitInfo.transform.position;
        //Ps_QmarkEffect.GetComponent<QuestionEffect>().SetTarget(t_targetPos);
        //Ps_QmarkEffect.transform.position = cam.transform.position;


        //StartCoroutine(CollisionWait());

    }




}