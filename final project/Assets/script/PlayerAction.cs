using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float m_speed = 50f;
    public float turnSpeed = 50f;

    GameObject deformObj;
    public GameObject playerObj;
    public Camera newCamera;
    public GameObject moster;



    GameObject tempObj;

    int lookAround = Animator.StringToHash("lookAround");
    int run = Animator.StringToHash("run");
    int count = 0;

    //測試 滑鼠移動人物
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes m_axes = RotationAxes.MouseXAndY;
    public float m_sensitivityX = 0;
    public float m_sensitivityY = 0;

    // 水平方向的 镜头转向
    public float m_minimumX = -360f;
    public float m_maximumX = 360f;
    // 垂直方向的 镜头转向 (这里给个限度 最大仰角为45°)
    public float m_minimumY = -45f;
    public float m_maximumY = 45f;

    float m_rotationY = 0f;

    // 測試結束


    // Start is called before the first frame update
    void Start()
    {
        tempObj = playerObj;
        if (GetComponent<Rigidbody>())
        {
           // GetComponent<Rigidbody>().freezeRotation = true;
        }
        Physics.gravity = new Vector3(0, -50, 0);  // gravity= -35 其他的默认
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj.tag =="Player")
        {
            ActionAni();    //移動動畫
        }
        MoveControlByTranslate();   //移動
        KeyDown();    //按鍵判斷
       // MouseMove();
    }
    void ActionAni()    //動畫區
    {
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
        {

            /*playerObj.GetComponent<Animation>().Play("runTest");
            print("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            print(playerObj.GetComponent<Animation>().IsPlaying("runTest"));*/

            playerObj.GetComponent<Animator>().SetBool(run, true);
            playerObj.GetComponent<Animator>().SetBool(lookAround, false);
        }
        else
        {
            //playerObj.GetComponent<Animation>().Play("lookAround");

            playerObj.GetComponent<Animator>().SetBool(run, false);
            playerObj.GetComponent<Animator>().SetBool(lookAround, true);

        }
    }
    void MoveControlByTranslate()   //移動
    {
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow)) //前
        {

            playerObj.transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
            //playerObj.transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
            //playerObj.transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow)) //後
        {
            // this.transform.Translate(Vector3.forward * -m_speed * Time.deltaTime);
            playerObj.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow)) //左
        {
            playerObj.transform.Translate(Vector3.right * -m_speed * Time.deltaTime);
            playerObj.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);


        }
        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) //右
        {
            playerObj.transform.Translate(Vector3.right * m_speed * Time.deltaTime);
            playerObj.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        }
    }
    
    void KeyDown()  //按鍵判斷
    {
        if (Input.GetKey(KeyCode.X))
        {
            this.transform.position = playerObj.transform.position;
            playerObj = this.gameObject;
            playerObj.transform.GetChild(1).gameObject.SetActive(true);
            ChangeTargetObj(playerObj);
        }

    }

    void MouseMove()
    {
        if (m_axes == RotationAxes.MouseXAndY)
        {
            float m_rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * m_sensitivityX;
            m_rotationY += Input.GetAxis("Mouse Y") * m_sensitivityY;
            m_rotationY = Mathf.Clamp(m_rotationY, m_minimumY, m_maximumY);

            transform.localEulerAngles = new Vector3(-m_rotationY, m_rotationX, 0);
        }
        else if (m_axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * m_sensitivityX, 0);
        }
        else
        {
            m_rotationY += Input.GetAxis("Mouse Y") * m_sensitivityY;
            m_rotationY = Mathf.Clamp(m_rotationY, m_minimumY, m_maximumY);

            transform.localEulerAngles = new Vector3(-m_rotationY, 0, 0);
           //newCamera.transform.localEulerAngles = new Vector3(-m_rotationY, transform.localEulerAngles.y, 0);
        }
    }

    void ChangeTargetObj(GameObject obj)    //鏡頭和怪物目標轉換
    {
        newCamera.GetComponent<FollwCam>().ChangeTargetObj(obj);
        if(obj.tag == "Player")
        {
            moster.GetComponent<FindRoad>().ChangePlayerObj(obj);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "deform" && Input.GetKey(KeyCode.Z) && count == 0)  //碰到物件 才變身
        {
            deformObj = collision.gameObject;   //變身物件

            playerObj.transform.GetChild(1).gameObject.SetActive(false);    //將主角隱身
            playerObj = deformObj;  //變身
            ChangeTargetObj(playerObj); //變換鏡頭和怪物追蹤
            count = 1;
        }
    }

    public GameObject GetPlayerObj()    //回傳現在變形的物件
    {
        return playerObj;
    }

}
