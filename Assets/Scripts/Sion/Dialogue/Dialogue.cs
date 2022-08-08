using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public enum CameraType
{
    ObjectFront,
    Reset,
    FadeOut,
    FadeIn,
    FlashIn,
    FlashOut,
}



[System.Serializable]
public class Dialogue
{

    [Header("카메라가 타겟팅할 대상")]
    public CameraType cameraType;
    public Transform tf_Target;

    //test

    public Transform MainCG;
    public Transform OppoCG;

    //

    
    public string name;     // 대사치는 캐릭터 이름

    
    public string[] contexts;   // 대사 내용

    [HideInInspector]
    public string[] MainSpriteName;

    [HideInInspector]
    public string[] OppoSpriteName;

    [HideInInspector]
    public string[] Sound_BGM_Name;

    [HideInInspector]
    public string[] Sound_Effect_Name;


}


[System.Serializable]
public class DialogueEvent
{

    public string name; // 대화 이벤트 이름 ex. 식당 이벤트
    

    public Vector2 line; // x부터 y까지 줄의 대사 추출
    
    
    public Dialogue[] dialogues;

}
