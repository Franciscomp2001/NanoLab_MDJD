using UnityEngine;

public class DetectorMolecula : MonoBehaviour
{
    public GameObject moleculaAguaPrefab; // Prefab da molécula de água
    private bool moleculaCompleta = false;

    private void OnColliderEntered(Collider other)
    {
        if (other.CompareTag("Hidrogenio") || other.CompareTag("Oxigenio"))
        {
            CheckMoleculaCompletion();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OnColliderEntered(other);
    }

    private void OnTriggerExit(Collider other)
    {
        // Adicione esta verificação para garantir que a saída do collider não afete a contagem
        if (other.CompareTag("Hidrogenio") || other.CompareTag("Oxigenio"))
        {
            OnColliderEntered(other);
        }
    }

    private void CheckMoleculaCompletion()
    {
        // Obter todos os colliders dentro de uma esfera com raio igual ao do collider do objeto atual
        Collider[] colliders = Physics.OverlapSphere(transform.position, GetComponent<Collider>().bounds.extents.x);

        int hidrogeniosCount = 0;
        int oxigeniosCount = 0;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Hidrogenio"))
            {
                hidrogeniosCount++;
            }
            else if (collider.CompareTag("Oxigenio"))
            {
                oxigeniosCount++;
            }
        }

        // Adicione verificações adicionais para garantir que a contagem é precisa
        if (hidrogeniosCount == 2 && oxigeniosCount == 1 && !moleculaCompleta)
        {
            moleculaCompleta = true;
            //Debug.Log("Molécula completa!");

            // Destroi apenas os objetos com as tags Hidrogenio e Oxigenio dentro do collider
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Hidrogenio") || collider.CompareTag("Oxigenio"))
                {
                    Destroy(collider.gameObject);
                }
            }

            // Adiciona uma nova molécula de água à cena dentro do mesmo collider
            AdicionarMoleculaAgua();
        }
        else if (hidrogeniosCount < 2 || oxigeniosCount < 1)
        {
            moleculaCompleta = false; // Reseta a flag se a condição não for mais atendida
        }
    }

    private void AdicionarMoleculaAgua()
    {
        // Instancia uma nova molécula de água a partir do prefab
        GameObject moleculaAgua = Instantiate(moleculaAguaPrefab, transform.position, Quaternion.identity);

        // Configura a posição e rotação conforme necessário
        moleculaAgua.transform.SetParent(transform); // Para garantir que a molécula está dentro do collider
    }
}
