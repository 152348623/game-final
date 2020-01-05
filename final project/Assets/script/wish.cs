using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wish : MonoBehaviour
{
    public Image Fill;
    public GameObject shard;
    private float fillTime = 0.02f;
    private bool ownDiamond;
    private bool isFinish;
    private bool inCollider;
    // Start is called before the first frame update
    void Start()
    {
        isFinish = false;
        ownDiamond = false;
        inCollider = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ownDiamond == true && isFinish == false && inCollider == true)
        {
            if (Input.GetMouseButton(0))
            {
                Fill.gameObject.SetActive(true);
                Fill.fillAmount += fillTime * Time.deltaTime; //總共100s
                if (Fill.fillAmount == 1)
                {
                    isFinish = true;
                    shard.SetActive(true);
                    Fill.gameObject.SetActive(false);
                }
            }
            else
            {
                Fill.gameObject.SetActive(false);
            }
        }
        else
        {
            Fill.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider player)
    {
        inCollider = true;
        if (player.tag == "Player" && isFinish == false)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player.GetComponent<PlayerMission>().missionArray[i].ToString() == "Diamond (UnityEngine.GameObject)")
                {
                    ownDiamond = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            inCollider = false;
        }
    }
}
