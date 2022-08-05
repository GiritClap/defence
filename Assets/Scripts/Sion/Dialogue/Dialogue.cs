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

    [Header("ī�޶� Ÿ������ ���")]
    public CameraType cameraType;
    public Transform tf_Target;

    //test

    public Transform MainCG;
    public Transform OppoCG;

    //

    
    public string name;     // ���ġ�� ĳ���� �̸�

    
    public string[] contexts;   // ��� ����

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

    public string name; // ��ȭ �̺�Ʈ �̸� ex. �Ĵ� �̺�Ʈ
    

    public Vector2 line; // x���� y���� ���� ��� ����
    
    
    public Dialogue[] dialogues;

}
