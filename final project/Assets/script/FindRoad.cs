using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FindRoad : MonoBehaviour
{
    public NavMeshAgent agent;    //宣告NavMeshAgent
    public GameObject target_obj;    //目標物件
    public GameObject Player;
    public float mosterChaseDis = 1000f;
    bool isTouchTarget = false;
    int childCount = 0;
    GameObject targetChild;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();        //接收NavMeshAgent
        childCount = target_obj.transform.childCount;                   //初始追逐目標物件
        targetChild = target_obj.transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDis = agent.transform.position - Player.transform.position;
        if(playerDis.magnitude < mosterChaseDis && Player.transform.GetChild(1).gameObject.activeSelf == true)    // player在怪獸追逐範圍裡 追player
        {
            agent.SetDestination(Player.transform.position);    //讓怪物往player的座標移動
        }
        else    // player不再追逐範圍裡 則去其他目標點
        {
            if (!isTouchTarget)     //如果還未碰到target 就繼續尋找
            {
                agent.SetDestination(targetChild.transform.position);    //讓怪物往target的座標移動
            }
            else    // 已找到target 隨機選 換target
            {
                int randomNum = UnityEngine.Random.Range(0, childCount);
                targetChild = target_obj.transform.GetChild(randomNum).gameObject;
                isTouchTarget = false;
            }
        }
        
    }
    void OnCollisionEnter(Collision collision)  //moster 碰到
    {
        switch (collision.gameObject.tag)
        {
            case "target":
                print("touch target");
                isTouchTarget = true;
                break;
            case "Player":
                print("player");
                break;
            default:
                break;
        }
    }

    public void ChangePlayerObj(GameObject playerObj)
    {
        Player = playerObj;
    }
}