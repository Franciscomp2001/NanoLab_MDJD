using UnityEngine;

public class OcclusionWalls : MonoBehaviour
{
    public GameObject mainLabParede1; // Primeira parede ativada pelo MainLab
    public GameObject mainLabParede2; // Segunda parede ativada pelo MainLab
    public GameObject mjParede; // Parede ativada pelo MJ
    public GameObject expParede; // Parede ativada pelo Exp
    public GameObject SegParede;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainLab"))
        {
            mainLabParede1.SetActive(true);
            mainLabParede2.SetActive(true);
            //Debug.Log("Jogador no Main Lab.");
        }
        if (other.CompareTag("MJ"))
        {
            mjParede.SetActive(true);
            //Debug.Log("Jogador no MJ.");
        }
        if (other.CompareTag("Exp"))
        {
            expParede.SetActive(true);
            //Debug.Log("Jogador no EXP.");
        }
        if (other.CompareTag("RobotActivate"))
        {
            SegParede.SetActive(false);
            mainLabParede1.SetActive(true);
            mainLabParede2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainLab"))
        {
            mainLabParede1.SetActive(false);
            mainLabParede2.SetActive(false);
            //Debug.Log("Jogador saiu do Main Lab.");
        }
        if (other.CompareTag("MJ"))
        {
            mjParede.SetActive(false);
            //Debug.Log("Jogador saiu do MJ.");
        }
        if (other.CompareTag("Exp"))
        {
            expParede.SetActive(false);
            //Debug.Log("Jogador saiu do EXP.");
        }
    }
}
