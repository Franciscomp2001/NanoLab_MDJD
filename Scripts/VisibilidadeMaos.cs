using UnityEngine;

public class ControleVisibilidade : MonoBehaviour
{
    public GameObject LeftController;
    public GameObject RightController;
    public GameObject LeftControllerGlove;
    public GameObject RightControllerGlove;

    void Start()
    {
        // Certifique-se de que todos os objetos estejam inicialmente visíveis
        MostrarObjetos();
    }

    // Função para mostrar todos os objetos
    void MostrarObjetos()
    {
        SetVisibilidade(LeftController, true);
        SetVisibilidade(RightController, true);
        SetVisibilidade(LeftControllerGlove, true);
        SetVisibilidade(RightControllerGlove, true);
    }

    // Função para esconder todos os objetos
    void EsconderObjetos()
    {
        SetVisibilidade(LeftController, false);
        SetVisibilidade(RightController, false);
        SetVisibilidade(LeftControllerGlove, false);
        SetVisibilidade(RightControllerGlove, false);
    }

    // Funções individuais para mostrar e esconder cada objeto
    void MostrarLeftController()
    {
        SetVisibilidade(LeftController, true);
    }

    void EsconderLeftController()
    {
        SetVisibilidade(LeftController, false);
    }

    void MostrarRightController()
    {
        SetVisibilidade(RightController, true);
    }

    void EsconderRightController()
    {
        SetVisibilidade(RightController, false);
    }

    void MostrarLeftControllerGlove()
    {
        SetVisibilidade(LeftControllerGlove, true);
    }

    void EsconderLeftControllerGlove()
    {
        SetVisibilidade(LeftControllerGlove, false);
    }

    void MostrarRightControllerGlove()
    {
        SetVisibilidade(RightControllerGlove, true);
    }

    void EsconderRightControllerGlove()
    {
        SetVisibilidade(RightControllerGlove, false);
    }

    // Função para definir a visibilidade usando Renderer.enabled
    void SetVisibilidade(GameObject objeto, bool visivel)
    {
        Renderer renderer = objeto.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.enabled = visivel;
        }
        else
        {
            Debug.LogError("O objeto não possui um componente Renderer.");
        }
    }
}
