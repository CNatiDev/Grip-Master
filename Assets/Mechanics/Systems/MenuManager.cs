using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        GamePause(true);
    }
    public void GamePause(bool pause)
    {
        if (pause)
            Time.timeScale = 0;
        if (!pause)
            Time.timeScale = 1;
    }
    public void Load_Scene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
