using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public void CloseSettings()
    {
        SceneManager.LoadScene(0);
    }
    
    public void WinMenu()
    {
        SceneManager.LoadScene(2);
    }
}
