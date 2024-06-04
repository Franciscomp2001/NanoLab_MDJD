using UnityEngine;

public class DetectorMolecula : MonoBehaviour
{
    public GameObject moleculaAguaPrefab; // Prefab da mol�cula de �gua
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
        // Adicione esta verifica��o para garantir que a sa�da do collider n�o afete a contagem
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

        // Adicione verifica��es adicionais para garantir que a contagem � precisa
        if (hidrogeniosCount == 2 && oxigeniosCount == 1 && !moleculaCompleta)
        {
            moleculaCompleta = true;
            //Debug.Log("Mol�cula completa!");

            // Destroi apenas os objetos com as tags Hidrogenio e Oxigenio dentro do collider
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Hidrogenio") || collider.CompareTag("Oxigenio"))
                {
                    Destroy(collider.gameObject);
                }
            }

            // Adiciona uma nova mol�cula de �gua � cena dentro do mesmo collider
            AdicionarMoleculaAgua();
        }
        else if (hidrogeniosCount < 2 || oxigeniosCount < 1)
        {
            moleculaCompleta = false; // Reseta a flag se a condi��o n�o for mais atendida
        }
    }

    private void AdicionarMoleculaAgua()
    {
        // Instancia uma nova mol�cula de �gua a partir do prefab
        GameObject moleculaAgua = Instantiate(moleculaAguaPrefab, transform.position, Quaternion.identity);

        // Configura a posi��o e rota��o conforme necess�rio
        moleculaAgua.transform.SetParent(transform); // Para garantir que a mol�cula est� dentro do collider
    }
}
