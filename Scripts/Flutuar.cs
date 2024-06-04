using UnityEngine;

public class FlutuacaoSuave : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitude da flutua��o
    public float velocidadeFlutuacao = 2f; // Velocidade da flutua��o

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Calcula a posi��o Y baseada em uma fun��o seno para criar a flutua��o
        float flutuacaoY = Mathf.Sin(Time.time * velocidadeFlutuacao) * amplitude;

        // Atualiza a posi��o do objeto
        transform.position = new Vector3(transform.position.x, posicaoInicial.y + flutuacaoY, transform.position.z);
    }
}
