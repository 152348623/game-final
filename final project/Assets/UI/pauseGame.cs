using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour
{
    public GameObject pannelUI;
    public GameObject pannelMission;
    public GameObject pannelContent;
    public GameObject player;
    private bool isPause;
    // Start is called before the first frame update
    void Start()
    {
        initial();

    }
    void initial()
    {
        Time.timeScale = 1;
        pannelUI.SetActive(false);
        pannelMission.SetActive(false);
        pannelContent.SetActive(false);
        isPause = false;
        pannelContent.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
        pannelContent.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
        pannelContent.transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(false);
        pannelContent.transform.GetChild(1).transform.GetChild(3).gameObject.SetActive(false);
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
            initial();
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
    public void home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void mission()
    {
        pannelUI.SetActive(false);
        pannelMission.SetActive(true);
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
    public void mission1()
    {
        pannelMission.SetActive(false);
        pannelContent.SetActive(true);
        pannelContent.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
    }
    public void mission2()
    {
        pannelMission.SetActive(false);
        pannelContent.SetActive(true);
        pannelContent.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
    }
    public void mission3()
    {
        pannelMission.SetActive(false);
        pannelContent.SetActive(true);
        pannelContent.transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(true);
    }
    public void mission4()
    {
        pannelMission.SetActive(false);
        pannelContent.SetActive(true);
        pannelContent.transform.GetChild(1).transform.GetChild(3).gameObject.SetActive(true);
    }
    public void backMenu()
    {
        pannelMission.SetActive(false);
        pannelUI.SetActive(true);
    }
    public void backMission()
    {
        pannelContent.SetActive(false);
        pannelContent.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
        pannelContent.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
        pannelContent.transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(false);
        pannelContent.transform.GetChild(1).transform.GetChild(3).gameObject.SetActive(false);
        pannelMission.SetActive(true);
    }
}
