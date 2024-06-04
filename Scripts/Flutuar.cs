using UnityEngine;

public class FlutuacaoSuave : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitude da flutuação
    public float velocidadeFlutuacao = 2f; // Velocidade da flutuação

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Calcula a posição Y baseada em uma função seno para criar a flutuação
        float flutuacaoY = Mathf.Sin(Time.time * velocidadeFlutuacao) * amplitude;

        // Atualiza a posição do objeto
        transform.position = new Vector3(transform.position.x, posicaoInicial.y + flutuacaoY, transform.position.z);
    }
}
