using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AgarrarObjeto : XRGrabInteractable
{
    private GameObject objetoOriginal;
    private GameObject copiaObjeto;
    private bool copiaCriada = false;

    protected override void Awake()
    {
        base.Awake();
        objetoOriginal = gameObject;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Verifica se a cópia ainda não foi criada
        if (!copiaCriada)
        {
            // Cria uma cópia do objeto original na posição inicial
            copiaObjeto = Instantiate(objetoOriginal, objetoOriginal.transform.position, objetoOriginal.transform.rotation);


            // Ativa a gravidade e desativa a cinemática na cópia
            Rigidbody copiaRigidbody = copiaObjeto.GetComponent<Rigidbody>();
            if (copiaRigidbody != null)
            {
                copiaRigidbody.useGravity = true;
                copiaRigidbody.isKinematic = false;
            }

            copiaCriada = true;
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

    }
}
