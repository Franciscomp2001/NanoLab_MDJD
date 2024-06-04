using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrintMessageOnPrimaryButton : MonoBehaviour
{
    public XRController controller;

    private void Start()
    {
        // Encontrar o XRController associado a este GameObject
        controller = GetComponent<XRController>();

        // Certificar-se de que o XRController é válido
        if (controller == null)
        {
            Debug.LogError("Este script requer um XRController anexado ao mesmo GameObject!");
            enabled = false; // Desativar o script se o XRController não estiver presente
        }
    }

    private void Update()
    {
        // Verificar se o botão primário está sendo pressionado no quadro atual
        if (controller.inputDevice.IsPressed(InputHelpers.Button.PrimaryButton, out bool isPressed))
        {
            if (isPressed)
            {
                // Imprimir uma mensagem na consola quando o botão primário é pressionado
                Debug.Log("Botão Primário Pressionado!");
            }
        }
    }
}
