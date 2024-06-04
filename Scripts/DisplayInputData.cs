using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using TMPro;

public class TriggerInputDetector : MonoBehaviour
{

    public GameObject Cuboo;

    private InputData _inputData;


    private void Start()
    {
        _inputData = GetComponent<InputData>();
        Debug.Log("Started inputData: " + _inputData);
    }
    // Update is called once per frame
    void Update()
    {

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton))
        {

            Cuboo.SetActive(true);
            Debug.Log("A button: " + Abutton);
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool Bbutton))
        {
            Cuboo.SetActive(false);
            Debug.Log("B button: " + Bbutton);
        }

    }
}