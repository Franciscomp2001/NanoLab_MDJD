using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GerenciadorDeCena : MonoBehaviour
{
    // Referência ao objeto XR Origin (XR Rig) em cada cena
    public Transform originCena1;
    public Transform originCena2;
    public Transform originCena3;

    // Lista de nomes dos GameObjects para desativar
    public List<string> nomesParaDesativar;

    // Verifica se o jogador já entrou na cena 1
    private bool jogadorEntrouNaCena1 = false;

    private void Start()
    {
        // Garante que este objeto não será destruído entre as cenas
        DontDestroyOnLoad(gameObject);

        // Inscreve-se no evento de carregamento de cena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Encontra o objeto XR Origin (XR Rig)
        GameObject xrRig = GameObject.Find("XR Origin (XR Rig)");

        if (xrRig == null)
        {
            Debug.LogError("Objeto XR Origin (XR Rig) não encontrado na cena.");
            return;
        }

        // Verifica se a cena carregada é a cena 1
        if (scene.buildIndex == 1)
        {
            if (!jogadorEntrouNaCena1)
            {
                // Define a posição do objeto XR Origin (XR Rig) para a cena 1
                xrRig.transform.position = originCena1.position;
                jogadorEntrouNaCena1 = true;
            }
            else
            {
                // Define a posição do objeto XR Origin (XR Rig) para a cena 3
                xrRig.transform.position = originCena3.position;

                // Desativa os objetos na lista de nomesParaDesativar
                foreach (string nome in nomesParaDesativar)
                {
                    GameObject objParaDesativar = GameObject.Find(nome);
                    if (objParaDesativar != null)
                    {
                        objParaDesativar.SetActive(false);
                        Debug.Log("Objeto desativado: " + nome);
                    }
                    else
                    {
                        Debug.LogWarning("Objeto com nome '" + nome + "' não encontrado na cena.");
                    }
                }

            }
        }
        // Verifica se a cena carregada é a cena 2
        else if (scene.buildIndex == 2)
        {
            // Define a posição do objeto XR Origin (XR Rig) para a cena 2
            xrRig.transform.position = originCena2.position;
        }
    }
}
