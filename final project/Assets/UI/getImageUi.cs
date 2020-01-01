using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getImageUi : MonoBehaviour
{
    //public GameObject playerObj;
    public Image[] image;
    public Image targetImage;
    public GameObject playerObj;
    private GameObject none;
    private GameObject apple;
    private GameObject barrel;
    private GameObject canned;
    private GameObject carrot;
    private GameObject fish;
    private GameObject meat;
    private GameObject mushroom;
    private GameObject[] itemArray;
    public 
    // Start is called before the first frame update
    void Start()
    {
        none = targetImage.transform.GetChild(0).gameObject;
        apple = targetImage.transform.GetChild(1).gameObject;
        barrel = targetImage.transform.GetChild(2).gameObject;
        canned = targetImage.transform.GetChild(3).gameObject;
        carrot = targetImage.transform.GetChild(4).gameObject;
        fish = targetImage.transform.GetChild(5).gameObject;
        meat = targetImage.transform.GetChild(6).gameObject;
        mushroom = targetImage.transform.GetChild(7).gameObject;

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
        itemArray = playerObj.GetComponent<PlayerDeform>().deformArray;

        for(int i = 0; i < 4; i++)
        {
            if (itemArray[i] != null)
            {
                switch (itemArray[i].ToString())
                {
                    case "Apple (UnityEngine.GameObject)":
                        image[i].GetComponent<Image>().sprite = apple.GetComponent<SpriteRenderer>().sprite;
                        break;
                    case "Barrel (UnityEngine.GameObject)":
                        image[i].GetComponent<Image>().sprite = barrel.GetComponent<SpriteRenderer>().sprite;
                        break;
                    case "Canned (UnityEngine.GameObject)":
                        image[i].GetComponent<Image>().sprite = canned.GetComponent<SpriteRenderer>().sprite;
                        break;
                    case "Carrot (UnityEngine.GameObject)":
                        image[i].GetComponent<Image>().sprite = carrot.GetComponent<SpriteRenderer>().sprite;
                        break;
                    case "Fish (UnityEngine.GameObject)":
                        image[i].GetComponent<Image>().sprite = fish.GetComponent<SpriteRenderer>().sprite;
                        break;
                    case "Meat (UnityEngine.GameObject)":
                        image[i].GetComponent<Image>().sprite = meat.GetComponent<SpriteRenderer>().sprite;
                        break;
                    case "Mushroom (UnityEngine.GameObject)":
                        image[i].GetComponent<Image>().sprite = mushroom.GetComponent<SpriteRenderer>().sprite;
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
