using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour // �Ľ��� �����͸� �����ͺ��̽����� ���� �� ����
{

    public static DatabaseManager instance; // ���� ������ ���� ��ü �ν��Ͻ�ȭ

    [SerializeField] string csv_FileName;

    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>(); // int = �� ��° / Dialogue = ���̾�α�

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
