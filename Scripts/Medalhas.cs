using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VerificarSockets : MonoBehaviour
{
    public GameObject Medalha;
    public float tickRate = 1f; // Tempo em segundos entre cada verificação

    void Start()
    {
        StartCoroutine(CheckSocketsRoutine());
    }

    IEnumerator CheckSocketsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(tickRate);
            if (TodosSocketsComObjeto())
            {
                Medalha.SetActive(true);
            }
            else
            {
                Medalha.SetActive(false);
            }
        }
    }

    bool TodosSocketsComObjeto()
    {
        foreach (Transform child in transform)
        {
            XRSocketInteractor socket = child.GetComponent<XRSocketInteractor>();
            if (socket != null && socket.selectTarget == null)
            {
                return false;
            }
        }
        return true;
    }
}
