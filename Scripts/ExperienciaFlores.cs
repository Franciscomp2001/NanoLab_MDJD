using System.Collections;
using UnityEngine;

public class ExperienciaFlores : MonoBehaviour
{
    public float duracaoDaTransicao = 5f;
    public GameObject Medalha;

    private Material material;
    private bool emTransicao = false; 

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!emTransicao) 
        {
            Renderer otherRenderer = other.GetComponent<Renderer>();

            if (otherRenderer != null)
            {
                Color corAlvo = otherRenderer.material.GetColor("_EmissionColor");
                StartCoroutine(TransicaoCor(corAlvo, otherRenderer));

                Medalha.SetActive(true);
            }
        }
    }

    IEnumerator TransicaoCor(Color corAlvo, Renderer otherRenderer)
    {
        emTransicao = true;
        float elapsedTime = 0f;
        Color corInicial = material.GetColor("_EmissionColor"); 

        while (elapsedTime < duracaoDaTransicao)
        {
            material.SetColor("_EmissionColor", Color.Lerp(corInicial, corAlvo, elapsedTime / duracaoDaTransicao));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        material.SetColor("_EmissionColor", corAlvo);

        if (otherRenderer != null)
        {
            otherRenderer.material.SetColor("_EmissionColor", corAlvo);
        }

        emTransicao = false;
    }
}