using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Encher : MonoBehaviour
{
    public GameObject CopoGrab;

    private const float escalaMaximaZ = 100f;
    private const float aumentoEscalaZ = 1f;

    private bool xrGrabInteractableAdded = false;

    void OnParticleCollision(GameObject other)
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (other.gameObject.tag == "AguaLiquido")
        {
            meshRenderer.enabled = true;
            
            if (transform.localScale.z < escalaMaximaZ)
            {
                
                float novaEscalaZ = Mathf.Min(transform.localScale.z + aumentoEscalaZ, escalaMaximaZ);
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, novaEscalaZ);

                // Verifica se atingiu a escala máxima
                if (novaEscalaZ >= escalaMaximaZ)
                {
                    // Ativa o "isTrigger" do Collider
                    Collider collider = GetComponent<Collider>();
                    if (collider != null)
                    {
                        collider.isTrigger = true;
                    }

                    if (!xrGrabInteractableAdded)
                    {
                        XRGrabInteractable xrGrabInteractable = CopoGrab.AddComponent<XRGrabInteractable>();
                        xrGrabInteractableAdded = true;
                    }
                }
            }
        }
    }
}
