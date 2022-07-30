using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{

    // 버튼 오브젝트 링크 함수
    public void OnclickNewGame()
    {
        Debug.Log("새 게임");
        SceneManager.LoadScene("Event_Scene_1");

    }


    public void OnclickLoadGame()
    {
        Debug.Log("불러오기");
        SceneManager.LoadScene("Fight_Scene_1");

    }


    public void OnclickDebugMod()
    {
        Debug.Log("디버그모드");
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
