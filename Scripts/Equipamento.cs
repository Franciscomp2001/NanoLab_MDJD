using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Equipamento : MonoBehaviour
{
    public GameObject Oculos;
    public GameObject Mask;


    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Oculos")
        {

            Debug.Log("Oculos colidiu DENTRO");
            Oculos.SetActive(false);
        
        }


        if (other.gameObject.tag == "Mask")
        {

            Debug.Log("Mask colidiu DENTRO");
            Mask.SetActive(false);
        
        }
    }
}