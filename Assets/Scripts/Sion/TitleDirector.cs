using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{

    // ��ư ������Ʈ ��ũ �Լ�
    public void OnclickNewGame()
    {
        Debug.Log("�� ����");
        SceneManager.LoadScene("Event_Scene_1");

    }


    public void OnclickLoadGame()
    {
        Debug.Log("�ҷ�����");
        SceneManager.LoadScene("Fight_Scene_1");

    }


    public void OnclickDebugMod()
    {
        Debug.Log("����׸��");
        SceneManager.LoadScene("Fight_Scene_1");

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
