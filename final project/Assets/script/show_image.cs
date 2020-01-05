using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_image : MonoBehaviour
{
    public GameObject image_die;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        image_die.gameObject.SetActive(false);
    }
    void show()
    {
        
        Time.timeScale = 0;
        player.GetComponent<Invector.CharacterController.vThirdPersonInput>().unLockCamere();
        image_die.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerDeform.player_die == true)
        {
            PlayerDeform.player_die = false;
            show();
        }
    }
}