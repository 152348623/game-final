using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moster : MonoBehaviour
{
    public GameObject moster;
    // Start is called before the first frame update
    void Start()
    {
        moster.GetComponent<Animation>().Play("moster_walk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
