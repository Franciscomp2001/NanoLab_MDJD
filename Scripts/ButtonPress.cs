using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrintMessageOnPrimaryButton : MonoBehaviour
{
    public XRController controller;

    private void Start()
    {
        // Encontrar o XRController associado a este GameObject
        controller = GetComponent<XRController>();

        // Certificar-se de que o XRController � v�lido
        if (controller == null)
        {
            Debug.LogError("Este script requer um XRController anexado ao mesmo GameObject!");
            enabled = false; // Desativar o script se o XRController n�o estiver presente
        }
    }

    private void Update()
    {
        // Verificar se o bot�o prim�rio est� sendo pressionado no quadro atual
        if (controller.inputDevice.IsPressed(InputHelpers.Button.PrimaryButton, out bool isPressed))
        {
            if (isPressed)
            {
                // Imprimir uma mensagem na consola quando o bot�o prim�rio � pressionado
                Debug.Log("Bot�o Prim�rio Pressionado!");
            }
        }
    }
}
