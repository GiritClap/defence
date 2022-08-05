using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour // 파싱한 데이터를 데이터베이스에서 저장 및 관리
{

    public static DatabaseManager instance; // 쉬운 참조를 위해 자체 인스턴스화

    [SerializeField] string csv_FileName;

    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>(); // int = 몇 번째 / Dialogue = 다이얼로그

    public static bool isFinish = false;

    void Awake()
    {
        if(instance == null)
        {

            instance = this;
            DialogueParser theParser = GetComponent<DialogueParser>();
            Dialogue[] dialogues = theParser.Parse(csv_FileName);
   

            for (int i = 0; i < dialogues.Length; i++){ 
                dialogueDic.Add(i+1, dialogues[i]);
                
            }
            isFinish = true;
            

        }

    }



    public Dialogue[] GetDialogue(int _StartNum, int _EndNum)
    {

        

        List<Dialogue> dialogueList = new List<Dialogue>();

        
        for (int i = 0; i <= _EndNum - _StartNum; i++) {
            dialogueList.Add(dialogueDic[_StartNum + i]);
           
        }


        

        return dialogueList.ToArray();


    }

}
