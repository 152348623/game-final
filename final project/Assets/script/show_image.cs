using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class show_image : MonoBehaviour
{
    public Image image_die;
    // Start is called before the first frame update
    void Start()
    {
        image_die.enabled = false;
    }
    void show()
    {
        image_die.enabled = true;
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