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


    // 버튼 오브젝트 링크 함수
    public void OnclickEventStart()
    {
        theIntC.Interact();

        //theDM.ShowDialogue(GetComponent<InteractionEvent>().GetDialogue());


    }


    public void OnclickLoadGame()
    {
        Debug.Log("불러오기");

    }


    public void OnclickDebugMod()
    {
        Debug.Log("디버그모드");

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
