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

    [HideInInspector]
    public string name;

    [HideInInspector]
    public string[] contexts;

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

    public string name;
    

    public Vector2 line;
    
    
    public Dialogue[] dialogues;

}
