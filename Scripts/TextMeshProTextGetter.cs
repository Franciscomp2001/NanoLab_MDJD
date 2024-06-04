using UnityEngine;
using TMPro;

public class InputFieldController : MonoBehaviour
{
    public TMP_InputField userName;
    public TextMeshProUGUI output;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ButtonEnter()
    {
        output.text = userName.text;
    }

}
