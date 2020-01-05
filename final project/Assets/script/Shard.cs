using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shard : MonoBehaviour
{
    public Text shardNumber;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            player.GetComponent<PlayerMission>().keyShard += 1;
            shardNumber.text = ":  " + player.GetComponent<PlayerMission>().keyShard.ToString() + " / 4";
            Destroy(this.gameObject);
        }
    }

}
