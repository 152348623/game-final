using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    public GameObject ghostUI;
    public GameObject shard;
    private bool isFinish;
    // Start is called before the first frame update
    void Start()
    {
        isFinish = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player" && isFinish == false)
        {
            ghostUI.SetActive(true);
            for (int i = 0; i < 4; i++)
            {
                if (player.GetComponent<PlayerMission>().missionArray[i].ToString() == "SacrificialOffering (UnityEngine.GameObject)")
                {
                    shard.SetActive(true);
                    isFinish = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            ghostUI.SetActive(false);
        }
    }
}
