using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_image : MonoBehaviour
{
    public GameObject image_die;
    // Start is called before the first frame update
    void Start()
    {
        image_die.gameObject.SetActive(false);
    }
    void show()
    {
        image_die.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerDeform.player_die == true)
        {
            Invoke("show", 1f);
        }
    }
}