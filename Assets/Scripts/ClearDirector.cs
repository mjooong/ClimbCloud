using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }

        if(Input.GetKeyDown(KeyCode.K)) //치트키
        {
            PlayerPrefs.DeleteAll(); //저장 값 모두 초기화 하기

            GameMgr.Load();

            Debug.Log("저장 정보 초기화 완료!");
        }
    }//void Update()
}
