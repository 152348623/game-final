using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Image Fill;
    private float fillTime = 0.2f;
    public bool isFinishDoor;
    public GameObject nextPanel;
    // Start is called before the first frame update
    void Start()
    {
        isFinishDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
       /* if (key)
        {
            GetComponent<Animator>().SetBool("open", true);
        }*/
    }
    private void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player" && player.GetComponent<PlayerMission>().keyShard == 4)
        {
            Fill.gameObject.SetActive(true);
            Fill.fillAmount += fillTime * Time.deltaTime; //總共100s
            if (Fill.fillAmount == 1)
            {
                GetComponent<Animator>().SetBool("open", true);
                Fill.gameObject.SetActive(false);
                isFinishDoor = true;
            }
            // GetComponent<Animator>().SetBool("open", true);
        }
    }
    private void OnCollisionEnter(Collision player)
    {
        if(player.gameObject.tag == "Player" && isFinishDoor)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            if(index == 1)
            {
                Time.timeScale = 0;
                nextPanel.SetActive(true);
            }
                
            /*else if(index == 2)
            {
            }*/
        }
    }
}
