using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeform : MonoBehaviour
{
    public GameObject playerObj;

    public GameObject[] deformArray = new GameObject[4];   // 存變身物件
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyDown();
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject deformObj;
        deformObj = other.gameObject;
        if (deformObj.tag == "deform") 
        {
            deformObj.GetComponent<cakeslice.Outline>().color = 1;  // 顯示外框
        }

        if (deformObj.tag == "deform" && Input.GetKey(KeyCode.F))  //碰到物件 才變身    F:獲取變身物件
        {
            for (int i = 0; i < 4; i++)
            {
                if (deformArray[i] == null)
                {
                    deformArray[i] = deformObj;   // 存放變身物件
                    deformArray[i].transform.parent = playerObj.transform;
                    deformArray[i].SetActive(false);
                    deformArray[i].transform.position = playerObj.transform.position;
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject deformObj;
        deformObj = other.gameObject;
        if (deformObj.tag == "deform")
        {
            deformObj.GetComponent<cakeslice.Outline>().color = 0;  
        }
    }

    void KeyDown()  //按鍵判斷
    {
        if (Input.GetKey(KeyCode.E))    // 從變身物件變成人   E : 變回人
        {
            playerObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            playerObj.GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, 0f, 2f);
            playerObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            playerObj.transform.GetChild(1).gameObject.SetActive(true);    // 原本人物

            for (int i = 0; i < 4; i++)
            {
                if (deformArray[i] != null && deformArray[i].transform.gameObject.activeSelf == true)
                {
                    Destroy(deformArray[i]);
                    deformArray[i] = null;
                    break;
                }
            }
        }

        if (playerObj.transform.GetChild(1).gameObject.activeSelf!=false)    // 可以變身物件 按1~4 可以變身    1~4 : 變身
        {
            void SetObjActive(int index)
            {
                playerObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                playerObj.transform.GetChild(1).gameObject.SetActive(false);    // 原本人物
                deformArray[index].SetActive(true);
                deformArray[index].GetComponent<cakeslice.Outline>().color = 0; // 將物體的外框去除
            }

            if (Input.GetKey(KeyCode.Alpha1) && deformArray[0] != null)
            {
                SetObjActive(0);
            }
            else if(Input.GetKey(KeyCode.Alpha2) && deformArray[1] != null)
            {
                SetObjActive(1);
            }
            else if (Input.GetKey(KeyCode.Alpha3) && deformArray[2] != null)
            {
                SetObjActive(2);
            }
            else if (Input.GetKey(KeyCode.Alpha4) && deformArray[3] != null)
            {
                SetObjActive(3);
            }
        }
    }
}
