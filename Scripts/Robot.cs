using UnityEngine;

public class SeguirJogador : MonoBehaviour
{
    public Transform jogador;

    public float distanciaMinima = 5f;

    public float alturaRelativa = 2f;

    public float velocidadeDeslizamento = 5f;


    void Update()
    {

        if (jogador != null)
        {

            Vector3 direcaoParaJogador = jogador.position - transform.position;
            Vector3 novaPosicao = jogador.position - direcaoParaJogador.normalized * distanciaMinima;
            novaPosicao.y = jogador.position.y + alturaRelativa;

            transform.position = Vector3.Lerp(transform.position, novaPosicao, velocidadeDeslizamento * Time.deltaTime);

        }

    }
}

