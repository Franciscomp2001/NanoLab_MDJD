using UnityEngine;
using System.Collections;

public class RotacionarTampa : MonoBehaviour
{
    public GameObject tampa;
    public float anguloDeRotacao = 60f;
    public float velocidadeDeRotacao = 2f;

    private Quaternion rotacaoInicial;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(RotacaoGradual(anguloDeRotacao));
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(RotacaoGradual(-anguloDeRotacao));
        }
    }

    private IEnumerator RotacaoGradual(float anguloAlvo)
    {

        rotacaoInicial = tampa.transform.rotation;
        Quaternion rotacaoFinal = Quaternion.Euler(tampa.transform.eulerAngles + new Vector3(0, 0, anguloAlvo));
        float tempoDecorrido = 0;

        while (tempoDecorrido < 1)
        {
            tampa.transform.rotation = Quaternion.Lerp(rotacaoInicial, rotacaoFinal, tempoDecorrido);
            tempoDecorrido += Time.deltaTime * velocidadeDeRotacao;

            yield return null;
        }

        tampa.transform.rotation = rotacaoFinal;
    }
}
