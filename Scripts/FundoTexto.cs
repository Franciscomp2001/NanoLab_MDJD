using UnityEngine;
using TMPro;

public class TextBackgroundDrawer : MonoBehaviour
{
    public TMP_InputField inputField; // Referência para o input field
    public GameObject backgroundPrefab; // Prefab do fundo retangular

    private GameObject[] letterBackgrounds; // Array para armazenar os fundos retangulares das letras

    private void Start()
    {
        if (inputField == null)
        {
            Debug.LogError("Input Field não atribuído ao TextBackgroundDrawer!");
            return;
        }

        // Instancia o array de fundos retangulares com o mesmo tamanho que o texto no input field
        letterBackgrounds = new GameObject[inputField.text.Length];

        // Instancia os fundos retangulares para cada letra no input field
        for (int i = 0; i < inputField.text.Length; i++)
        {
            GameObject background = Instantiate(backgroundPrefab, transform);
            letterBackgrounds[i] = background;
        }

        // Atualiza as posições e tamanhos dos fundos retangulares
        UpdateLetterBackgrounds();
    }

    // Método para atualizar as posições e tamanhos dos fundos retangulares
    private void UpdateLetterBackgrounds()
    {
        // Obtém o tamanho do texto
        TMP_TextInfo textInfo = inputField.textComponent.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            // Obtém a posição da letra na tela
            Vector3 letterPosition = inputField.textComponent.transform.TransformPoint(textInfo.characterInfo[i].bottomLeft);

            // Obtém o tamanho da letra
            float letterWidth = textInfo.characterInfo[i].topRight.x - textInfo.characterInfo[i].bottomLeft.x;
            float letterHeight = textInfo.characterInfo[i].topRight.y - textInfo.characterInfo[i].bottomLeft.y;

            // Atualiza a posição e tamanho do fundo retangular
            letterBackgrounds[i].transform.position = letterPosition;
            letterBackgrounds[i].transform.localScale = new Vector3(letterWidth, letterHeight, 1f);
        }
    }

    // Método chamado quando o texto no input field é alterado
    public void OnTextChanged()
    {
        // Atualiza o array de fundos retangulares com o mesmo tamanho que o novo texto
        letterBackgrounds = new GameObject[inputField.text.Length];

        // Instancia os fundos retangulares para cada letra no novo texto
        for (int i = 0; i < inputField.text.Length; i++)
        {
            GameObject background = Instantiate(backgroundPrefab, transform);
            letterBackgrounds[i] = background;
        }

        // Atualiza as posições e tamanhos dos novos fundos retangulares
        UpdateLetterBackgrounds();
    }
}
