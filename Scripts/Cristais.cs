using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EXPCristais : MonoBehaviour
{
    public GameObject Cristais;
    public GameObject SingleMeshCristais;
    public GameObject CopoCristais;
    public float activationDuration = 10f; 
    public float minActivationInterval = 0.5f; 
    public float maxActivationInterval = 2f;

    public GameObject Medalha;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pau")
        {
            StartCoroutine(ActivateRandomChildren());
        }
    }

    IEnumerator ActivateRandomChildren()
    {
        Cristais.SetActive(true);

        yield return new WaitForSeconds(2f);

        float timer = 0f;

        while (timer < activationDuration)
        {
            int randomChildIndex = Random.Range(0, Cristais.transform.childCount);
            GameObject randomChild = Cristais.transform.GetChild(randomChildIndex).gameObject;

            randomChild.SetActive(true);

            float randomInterval = Random.Range(minActivationInterval, maxActivationInterval);
            yield return new WaitForSeconds(randomInterval);

            timer += randomInterval;
        }

        yield return new WaitForSeconds(12f);
        CopoCristais.SetActive(true);
        Cristais.SetActive(false);
        SingleMeshCristais.SetActive(true);
        Medalha.SetActive(true);
    }
}

