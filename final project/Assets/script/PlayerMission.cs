using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMission : MonoBehaviour
{
    public GameObject playerObj;
    float distance;
    public GameObject[] missionArray = new GameObject[4];   // 存變身物件

    public GameObject missionUI;

    private int scene;
    // Start is called before the first frame update
    void Start()
    {
        distance = 1000f;
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        KeyDown();
    }

    private bool IsSmallDistanceOfDeform(GameObject player, GameObject mission)   // 判斷player與範圍內的deformObj之間的距離
    {
        float temp = 0f;
        temp = Vector3.Distance(player.transform.position, mission.transform.position);

        if (temp <= distance)
        {
            distance = temp;
            return true;
        }
        return false;
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject missionObj;
        missionObj = other.gameObject;

        bool isCanCatch = false;

        if (missionObj.tag == "mission")
        {
            if (!missionObj.GetComponent<cakeslice.Outline>())   // 給deform outline的script
                missionObj.AddComponent<cakeslice.Outline>();

            if (IsSmallDistanceOfDeform(playerObj, missionObj))      //  判斷如果都在範圍內 取距離最短的deformObj顯示外框 並可以抓取
            {
                missionObj.GetComponent<cakeslice.Outline>().color = 2;  // 顯示外框
                isCanCatch = true;
            }
            else
            {
                missionObj.GetComponent<cakeslice.Outline>().color = 0;  // 隱藏外框
                distance = 100f;
                isCanCatch = false;
            }
        }

        if (missionObj.tag == "mission" && Input.GetMouseButtonDown(0))  //碰到物件 可以獲得變身物件    F:獲取變身物件
        {
            for (int i = 0; i < 4; i++)
            {
                if (missionArray[i] == null && isCanCatch)
                {
                    missionArray[i] = missionObj;   // 存放變身物件
                    missionArray[i].transform.parent = playerObj.transform;
                    missionArray[i].SetActive(false);
                    missionArray[i].transform.position = playerObj.transform.position;


                    //deformCount++;
                    break;
                }
            }
        }

        if(missionObj.tag == "letter")
        {
            if (!missionObj.GetComponent<cakeslice.Outline>())   // 給deform outline的script
                missionObj.AddComponent<cakeslice.Outline>();
            missionObj.GetComponent<cakeslice.Outline>().color = 2;  // 顯示外框

            if(Input.GetMouseButtonDown(0))
            {
                missionArray[i].SetActive(false);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        GameObject missionObj;
        missionObj = other.gameObject;
        if (missionObj.tag == "mission")  // 離開範圍外 將外框隱藏
        {
            missionObj.GetComponent<cakeslice.Outline>().color = 0;
            distance = 100f;
        }

        if(missionObj.tag == "letter")
        {
            missionObj.GetComponent<cakeslice.Outline>().color = 0;
        }
    }

    void KeyDown()  //按鍵判斷
    {
       /* if (Input.GetKey(KeyCode.E))    // 從變身物件變成人   E : 變回人
        {
            playerObj.GetComponent<Rigidbody>().position.Set(playerObj.transform.position.x, 1f, playerObj.transform.position.z);
            playerObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            playerObj.GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, 0f, 0f);
            playerObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            playerObj.transform.GetChild(1).gameObject.SetActive(true);    // 原本人物

            for (int i = 0; i < 4; i++)
            {
                if (missionArray[i] != null && missionArray[i].transform.gameObject.activeSelf == true)
                {
                    Destroy(missionArray[i]);
                    missionArray[i] = null;
                    break;
                }
            }
        }

        if (playerObj.transform.GetChild(1).gameObject.activeSelf != false)    // 可以變身物件 按1~4 可以變身    1~4 : 變身
        {
            void SetObjActive(int index)
            {
                playerObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                playerObj.transform.GetChild(1).gameObject.SetActive(false);    // 原本人物
                missionArray[index].SetActive(true);

                playerObj.AddComponent<cakeslice.Outline>();
                missionArray[index].GetComponent<cakeslice.Outline>().color = 0; // 將物體的外框去除
            }

            if (Input.GetKey(KeyCode.Alpha1) && missionArray[0] != null)
            {
                SetObjActive(0);
            }
            else if (Input.GetKey(KeyCode.Alpha2) && missionArray[1] != null)
            {
                SetObjActive(1);
            }
            else if (Input.GetKey(KeyCode.Alpha3) && missionArray[2] != null)
            {
                SetObjActive(2);
            }
            else if (Input.GetKey(KeyCode.Alpha4) && missionArray[3] != null)
            {
                SetObjActive(3);
            }
        }*/
    }
}
