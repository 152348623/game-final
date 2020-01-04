using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour
{
    public GameObject pannelUI;
    public GameObject player;
    private bool isPause;
    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            isPause = true;
            pannelUI.SetActive(isPause);
            // print(pannelUI.GetComponent<InspectorNameAttribute>());
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
        {
            Time.timeScale = 1;
            isPause = false;
            pannelUI.SetActive(isPause);
        }
    }
    public void resume()
    {
        Time.timeScale = 1;
        isPause = false;
        pannelUI.SetActive(isPause);
    }
    public void restart()
    {
        Time.timeScale = 1;
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }
    public void back()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void exit()
    {
        Time.timeScale = 1;

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }
    

}
