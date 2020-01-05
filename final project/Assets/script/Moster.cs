using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moster : MonoBehaviour
{
    public GameObject moster;
    // Start is called before the first frame update
    void Start()
    {
        moster.GetComponent<Animation>().Play("moster_walk");
        print(moster.name);
        if (moster.name == "monster2" )
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
                moster.SetActive(true);
            else
            {
                moster.SetActive(false);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
