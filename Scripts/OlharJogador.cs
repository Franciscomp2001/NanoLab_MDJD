using System.Collections;
using UnityEngine;

public class OlharJogador : MonoBehaviour
{
    // Refer�ncia ao jogador
    public Transform jogador;
    
    void Update()
    {
        if (jogador != null)
        {
            transform.LookAt(jogador);

            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}
