using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{  
    public void ChangeTo1()
    {
        
        SceneManager.LoadScene("Game_Scene");
    }
    public void ChangeTo2()
    {

        SceneManager.LoadScene("StartMenu_Scene");
    }
}
