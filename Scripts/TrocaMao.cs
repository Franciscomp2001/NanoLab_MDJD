using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrocaMao : MonoBehaviour
{
    public GameObject LeftController;
    public GameObject RightController;
    public GameObject LeftControllerGlove;
    public GameObject RightControllerGlove;
    public GameObject RGlove;
    public GameObject LGlove;


    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "lGlove")
        {

            LeftController.SetActive(false);
            LeftControllerGlove.SetActive(true);
            LGlove.SetActive(false);


        }

        if (other.gameObject.tag == "rGlove")
        {

            RightController.SetActive(false);
            RightControllerGlove.SetActive(true);
            RGlove.SetActive(false);

        }

    }
}