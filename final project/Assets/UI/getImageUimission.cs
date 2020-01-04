using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getImageUimission : MonoBehaviour
{
    //public GameObject playerObj;
    public Image[] image;
    public Image targetImage;
    public GameObject playerObj;
    private GameObject none;
    private GameObject HolyWater;
    private GameObject Diamond;
    private GameObject Mantra;
    private GameObject SacrificialOffering;
    private GameObject[] itemArray;
    public 
    // Start is called before the first frame update
    void Start()
    {
        none = targetImage.transform.GetChild(0).gameObject;
        HolyWater = targetImage.transform.GetChild(1).gameObject;
        Diamond = targetImage.transform.GetChild(2).gameObject;
        Mantra = targetImage.transform.GetChild(3).gameObject;
        SacrificialOffering = targetImage.transform.GetChild(4).gameObject;

        //set image initial
        image[0].GetComponent<Image>().sprite = none.GetComponent<SpriteRenderer>().sprite;
        image[1].GetComponent<Image>().sprite = none.GetComponent<SpriteRenderer>().sprite;
        image[2].GetComponent<Image>().sprite = none.GetComponent<SpriteRenderer>().sprite;
        image[3].GetComponent<Image>().sprite = none.GetComponent<SpriteRenderer>().sprite;
        //0.none 1.apple 2.barrel 3.canned 4.carrot 5.fish 6.meat 7.mushroom

    }

    // Update is called once per frame
    void Update()
    {
        itemArray = playerObj.GetComponent<PlayerMission>().missionArray;

        for(int i = 0; i < 4; i++)
        {
            if (itemArray[i] != null)
            {
                switch (itemArray[i].ToString())
                {
                    case "HolyWater (UnityEngine.GameObject)":
                        image[i].GetComponent<Image>().sprite = HolyWater.GetComponent<SpriteRenderer>().sprite;
                        break;
                    case "Diamond (UnityEngine.GameObject)":
                        image[i].GetComponent<Image>().sprite = Diamond.GetComponent<SpriteRenderer>().sprite;
                        break;
                    case "Mantra (UnityEngine.GameObject)":
                        image[i].GetComponent<Image>().sprite = Mantra.GetComponent<SpriteRenderer>().sprite;
                        break;
                    case "SacrificialOffering (UnityEngine.GameObject)":
                        image[i].GetComponent<Image>().sprite = SacrificialOffering.GetComponent<SpriteRenderer>().sprite;
                        break;
                    default:    //none
                        image[i].GetComponent<Image>().sprite = none.GetComponent<SpriteRenderer>().sprite;
                        break;
                }
            }
            else
            {
                image[i].GetComponent<Image>().sprite = none.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }
}
