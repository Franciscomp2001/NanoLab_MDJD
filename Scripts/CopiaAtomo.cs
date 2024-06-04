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

        // Verifica se a c�pia ainda n�o foi criada
        if (!copiaCriada)
        {
            // Cria uma c�pia do objeto original na posi��o inicial
            copiaObjeto = Instantiate(objetoOriginal, objetoOriginal.transform.position, objetoOriginal.transform.rotation);


            // Ativa a gravidade e desativa a cinem�tica na c�pia
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
