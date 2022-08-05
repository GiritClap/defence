using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EventDirector : MonoBehaviour
{

 

    DialogueManager theDM;
    InteractionController theIntC;

    void Start()
    {

        theDM = FindObjectOfType<DialogueManager>();
        theIntC = FindObjectOfType<InteractionController>();
        
    }


    // ��ư ������Ʈ ��ũ �Լ�
    public void OnclickEventStart()
    {
        theIntC.Interact();

        //theDM.ShowDialogue(GetComponent<InteractionEvent>().GetDialogue());


    }


    public void OnclickLoadGame()
    {
        Debug.Log("�ҷ�����");

    }


    public void OnclickDebugMod()
    {
        Debug.Log("����׸��");

    }

    public void OnclickQuitGame()
    {
#if UNITY_EDITOR
UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        
        


    }




}
