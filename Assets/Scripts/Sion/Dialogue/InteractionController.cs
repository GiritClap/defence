using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{

    [SerializeField] Camera cam;
    /*

    [SerializeField] GameObject go_NormalCrosshair;
    [SerializeField] GameObject go_InteractionCrosshair;


    [SerializeField] GameObject go_Crosshair;
    [SerializeField] GameObject go_Cursor;
    [SerializeField] GameObject go_TargetNameBar;
    [SerializeField] Text txt_targetName;

    [SerializeField] Image img_Interaction;
    [SerializeField] Image img_InteractionEffect;
    */

    RaycastHit hitInfo;

    bool IsContact = false;
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
        if (!IsInteract)
        {
            CheckObject();
            ClickLeftBtn(); //우클릭감지 함수
        }
    }

    void CheckObject()
    {
        Vector3 t_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        if (Physics.Raycast(cam.ScreenPointToRay(t_MousePos), out hitInfo, 100))
        {
            Contact();
        }
        else
        {
            NotContact();
        }
    }

    public void Contact()
    {
        //if (hitInfo.transform.CompareTag("Interaction"))
        //{
            //go_TargetNameBar.SetActive(true);
            //txt_targetName.text = hitInfo.transform.GetComponent<InteractionType>().GetName();
            if (!IsContact)
            {
                IsContact = true;
                //go_InteractionCrosshair.SetActive(true);
                //go_NormalCrosshair.SetActive(false);
                StopCoroutine("Interaction");
                //StopCoroutine("InteractionEffect");
                StartCoroutine("Interaction", true);
                //StartCoroutine("InteractionEffect");
            }
        //}
        else
        {
            NotContact();
        }

    }


    void NotContact()
    {
        if (IsContact)
        {
            //go_TargetNameBar.SetActive(false);
            IsContact = false;
            //go_InteractionCrosshair.SetActive(false);
            //go_NormalCrosshair.SetActive(true);
            StopCoroutine("Interaction");
            StartCoroutine("Interaction", false);
        }
    }

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




    void ClickLeftBtn()
    {
        if (!IsInteract)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("클릭");

                if (IsContact)
                {
                    Debug.Log("인터렉트");
                    Interact();
                }
            }

        }

    }

    public void Interact()
    {
        IsInteract = true;

        StopCoroutine("Interaction");
        //Color color = img_Interaction.color;
        //color.a = 0;
        //img_Interaction.color = color;



        //Ps_QmarkEffect.gameObject.SetActive(true);
        //Vector3 t_targetPos = hitInfo.transform.position;
        //Ps_QmarkEffect.GetComponent<QuestionEffect>().SetTarget(t_targetPos);
        //Ps_QmarkEffect.transform.position = cam.transform.position;


        

        theDM.ShowDialogue(theInt.GetDialogue());

        Debug.Log("넘어옴3");
        //StartCoroutine(CollisionWait());

    }




}