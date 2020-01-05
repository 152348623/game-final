using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyUI : MonoBehaviour
{
    public GameObject player;
    public GameObject keyImage;
    public Image fillLine;
    private float fillTime;
    private bool isFill;
    // Start is called before the first frame update
    void Start()
    {
        isFill = false;
        fillTime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerMission>().keyShard == 4 && isFill == false)
        {
            fillLine.fillAmount += fillTime * Time.deltaTime;
        }
        if(fillLine.fillAmount == 1)
        {
            isFill = true;
            keyImage.SetActive(true);
        }
    }
}
