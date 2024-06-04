using UnityEngine;
using TMPro;

public class TextBackgroundDrawer : MonoBehaviour
{
    public TMP_InputField inputField; // Refer�ncia para o input field
    public GameObject backgroundPrefab; // Prefab do fundo retangular

    private GameObject[] letterBackgrounds; // Array para armazenar os fundos retangulares das letras

    private void Start()
    {
        if (inputField == null)
        {
            Debug.LogError("Input Field n�o atribu�do ao TextBackgroundDrawer!");
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

        // Atualiza as posi��es e tamanhos dos fundos retangulares
        UpdateLetterBackgrounds();
    }

    // M�todo para atualizar as posi��es e tamanhos dos fundos retangulares
    private void UpdateLetterBackgrounds()
    {
        // Obt�m o tamanho do texto
        TMP_TextInfo textInfo = inputField.textComponent.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            // Obt�m a posi��o da letra na tela
            Vector3 letterPosition = inputField.textComponent.transform.TransformPoint(textInfo.characterInfo[i].bottomLeft);

            // Obt�m o tamanho da letra
            float letterWidth = textInfo.characterInfo[i].topRight.x - textInfo.characterInfo[i].bottomLeft.x;
            float letterHeight = textInfo.characterInfo[i].topRight.y - textInfo.characterInfo[i].bottomLeft.y;

            // Atualiza a posi��o e tamanho do fundo retangular
            letterBackgrounds[i].transform.position = letterPosition;
            letterBackgrounds[i].transform.localScale = new Vector3(letterWidth, letterHeight, 1f);
        }
    }

    // M�todo chamado quando o texto no input field � alterado
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

        // Atualiza as posi��es e tamanhos dos novos fundos retangulares
        UpdateLetterBackgrounds();
    }
}
