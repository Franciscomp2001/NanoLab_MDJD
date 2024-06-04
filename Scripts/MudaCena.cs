using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCenaComTecla : MonoBehaviour
{
    void Update()
    {
        // Verifica se a tecla de espaço foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Carrega a próxima cena
            CarregarProximaCena();
        }
    }

    void CarregarProximaCena()
    {
        // Obtém o índice da cena atual
        int cenaAtualIndex = SceneManager.GetActiveScene().buildIndex;

        // Carrega a próxima cena na lista de cenas da build
        SceneManager.LoadScene(cenaAtualIndex + 1);

        // Se a próxima cena for a última, volta para a primeira cena
        if (cenaAtualIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
    }
}
