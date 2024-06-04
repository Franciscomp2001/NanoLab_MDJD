using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCenaComTecla : MonoBehaviour
{
    void Update()
    {
        // Verifica se a tecla de espa�o foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Carrega a pr�xima cena
            CarregarProximaCena();
        }
    }

    void CarregarProximaCena()
    {
        // Obt�m o �ndice da cena atual
        int cenaAtualIndex = SceneManager.GetActiveScene().buildIndex;

        // Carrega a pr�xima cena na lista de cenas da build
        SceneManager.LoadScene(cenaAtualIndex + 1);

        // Se a pr�xima cena for a �ltima, volta para a primeira cena
        if (cenaAtualIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
    }
}
