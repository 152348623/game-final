using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwCam : MonoBehaviour
{
	public float dist = 70f;
	public float height = 30.0f;
	public float dampTrace = 0.0f;

    public GameObject targetTr;

    public Transform tr;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
        //targetTr = targetTr.GetComponent<PlayerAction>().GetPlayerObj();

    }
    // Update is called once per frame
    void LateUpdate () {
        tr.position = Vector3.Lerp (tr.position, targetTr.transform.position - (targetTr.transform.forward * dist) + (Vector3.up * height), Time.deltaTime * dampTrace);
		tr.LookAt(targetTr.transform.position);

	}
    public void ChangeTargetObj(GameObject playerObj)   //變換跟隨物
    {
        targetTr = playerObj;
    }


}
