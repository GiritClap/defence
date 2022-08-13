using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // 대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); // csv 파일 가져옴

        string[] data = csvData.text.Split(new char[] { '\n' }); // 엔터(한 줄 한 줄) 기준으로 쪼갬



        for (int i = 5; i < data.Length;) // 시트의 5번 째 줄 부터 반복 (0부터 시작임!) // 시작부분 정하는 줄
        {
            string[] row = data[i].Split(new char[] { ',' }); // 쉼표 기준으로 쪼갬

            Dialogue dialogue = new Dialogue(); // 대사 리스트 생성

            dialogue.name = row[1];

            List<string> contextList = new List<string>();



            List<string> MainSpriteList = new List<string>();

            List<string> OppoSpriteList = new List<string>();

            List<string> CutSceneSpriteList = new List<string>();

            List<string> Sound_BGM_Name_List = new List<string>();

            List<string> Sound_Effect_Name_List = new List<string>();

            do
            {
                contextList.Add(row[2]);
                MainSpriteList.Add(row[3]);
                OppoSpriteList.Add(row[4]);
                CutSceneSpriteList.Add(row[5]);
                Sound_BGM_Name_List.Add(row[6]);
                Sound_Effect_Name_List.Add(row[7]);

            
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                    
                }
                else
                {
                    break;
                }

            } while (row[0].ToString() == "");

            dialogue.contexts = contextList.ToArray();
            dialogue.MainSpriteName = MainSpriteList.ToArray();
            dialogue.OppoSpriteName = OppoSpriteList.ToArray();
            dialogue.CutSceneSpriteName = CutSceneSpriteList.ToArray();
            dialogue.Sound_BGM_Name = Sound_BGM_Name_List.ToArray();
            dialogue.Sound_Effect_Name = Sound_Effect_Name_List.ToArray();

            dialogueList.Add(dialogue);

            

        }

       
        return dialogueList.ToArray();


       


    }


}
