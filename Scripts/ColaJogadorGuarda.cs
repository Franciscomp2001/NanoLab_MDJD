using UnityEngine;

public class AttachToParent : MonoBehaviour
{
    public GameObject parentObject;

    void Start()
    {

        GameObject jogador = GameObject.FindWithTag("TagJogador");

        if (jogador != null)
        {

            jogador.transform.parent = parentObject.transform;

            jogador.transform.localPosition = Vector3.zero;
            jogador.transform.localRotation = Quaternion.identity;
            jogador.transform.localScale = Vector3.one;
        }
        else
        {
            Debug.LogError("Tag do jogador nao encontrada");
        }
    }
}
