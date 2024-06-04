using UnityEngine;

public class AtivarParticleSystem : MonoBehaviour
{
    public float limiteDeRotacao = 90f;
    public ParticleSystem particleSystem;

    void Update()
    {
        Vector3 rotacaoAtual = transform.eulerAngles;

        float rotacaoX = (rotacaoAtual.x > 180) ? rotacaoAtual.x - 360 : rotacaoAtual.x;
        float rotacaoZ = (rotacaoAtual.z > 180) ? rotacaoAtual.z - 360 : rotacaoAtual.z;

        if (Mathf.Abs(rotacaoX) > limiteDeRotacao || Mathf.Abs(rotacaoZ) > limiteDeRotacao)
        {
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }
}
