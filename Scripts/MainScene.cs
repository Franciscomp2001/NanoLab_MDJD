using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainScene : MonoBehaviour
{
    // Refer�ncia ao jogador
    public Transform jogador;

    private void OnTriggerEnter(Collider other)
    {
        // Certifica-se de que a colis�o ocorreu com o jogador e que ainda n�o processamos a colis�o
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
