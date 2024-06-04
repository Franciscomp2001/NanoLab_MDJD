using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainScene : MonoBehaviour
{
    // Referência ao jogador
    public Transform jogador;

    private void OnTriggerEnter(Collider other)
    {
        // Certifica-se de que a colisão ocorreu com o jogador e que ainda não processamos a colisão
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
