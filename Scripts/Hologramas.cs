using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hologramas : MonoBehaviour
{
    

    [Header("Botoes")]
    public GameObject Hidrogenio;
    public GameObject Oxigenio;
    public GameObject Carbono;
    public GameObject Aluminio;
    public GameObject Ferro;
    public GameObject Helio;
    public GameObject Neon;
    public GameObject Ouro;

    [Header("Audios")]
    public AudioSource RobotSource;

    public AudioClip AlumínioAuido;
    public AudioClip CarbonoAuido;
    public AudioClip FerroAuido;
    public AudioClip HélioAuido;
    public AudioClip HidrogênioAuido;
    public AudioClip NeônioAuido;
    public AudioClip OuroAuido;
    public AudioClip OxigênioAuido;

    [Header("Relogio e troca cena")]
    public GameObject TrocaCena;
    public GameObject RelogioPulso;
    public GameObject SuporteRelogio;

    void Start()
    {
                
        Hidrogenio.SetActive(false);
        Carbono.SetActive(false);
        Aluminio.SetActive(false);
        Ferro.SetActive(false);
        Helio.SetActive(false);
        Neon.SetActive(false);
        Ouro.SetActive(false);


        TrocaCena.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Relogio")
        {

            RelogioPulso.SetActive(true);
            SuporteRelogio.SetActive(false);
            TrocaCena.SetActive(true);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (other.gameObject.tag == "Hidrogenio")
        {

            Hidrogenio.SetActive(true);
            Oxigenio.SetActive(false);
            Carbono.SetActive(false);
            Aluminio.SetActive(false);
            Ferro.SetActive(false);
            Helio.SetActive(false);
            Neon.SetActive(false);
            Ouro.SetActive(false);

            RobotSource.clip = HidrogênioAuido;
            RobotSource.Play();


        }

        if (other.gameObject.tag == "Oxigenio")
        {

            Hidrogenio.SetActive(false);
            Oxigenio.SetActive(true);
            Carbono.SetActive(false);
            Aluminio.SetActive(false);
            Ferro.SetActive(false);
            Helio.SetActive(false);
            Neon.SetActive(false);
            Ouro.SetActive(false);

            RobotSource.clip = OxigênioAuido;
            RobotSource.Play();

        }

        if (other.gameObject.tag == "Carbono")
        {

            Hidrogenio.SetActive(false);
            Oxigenio.SetActive(false);
            Carbono.SetActive(true);
            Aluminio.SetActive(false);
            Ferro.SetActive(false);
            Helio.SetActive(false);
            Neon.SetActive(false);
            Ouro.SetActive(false);

            RobotSource.clip = CarbonoAuido;
            RobotSource.Play();

        }

        if (other.gameObject.tag == "Aluminio")
        {

            Hidrogenio.SetActive(false);
            Oxigenio.SetActive(false);
            Carbono.SetActive(false);
            Aluminio.SetActive(true);
            Ferro.SetActive(false);
            Helio.SetActive(false);
            Neon.SetActive(false);
            Ouro.SetActive(false);

            RobotSource.clip = AlumínioAuido;
            RobotSource.Play();

        }

        if (other.gameObject.tag == "Ferro")
        {

            Hidrogenio.SetActive(false);
            Oxigenio.SetActive(false);
            Carbono.SetActive(false);
            Aluminio.SetActive(false);
            Ferro.SetActive(true);
            Helio.SetActive(false);
            Neon.SetActive(false);
            Ouro.SetActive(false);

            RobotSource.clip = FerroAuido;
            RobotSource.Play();

        }

        if (other.gameObject.tag == "Helio")
        {

            Hidrogenio.SetActive(false);
            Oxigenio.SetActive(false);
            Carbono.SetActive(false);
            Aluminio.SetActive(false);
            Ferro.SetActive(false);
            Helio.SetActive(true);
            Neon.SetActive(false);
            Ouro.SetActive(false);

            RobotSource.clip = HélioAuido;
            RobotSource.Play();

        }

        if (other.gameObject.tag == "Neon")
        {

            Hidrogenio.SetActive(false);
            Oxigenio.SetActive(false);
            Carbono.SetActive(false);
            Aluminio.SetActive(false);
            Ferro.SetActive(false);
            Helio.SetActive(false);
            Neon.SetActive(true);
            Ouro.SetActive(false);

            RobotSource.clip = NeônioAuido;
            RobotSource.Play();

        }

        if (other.gameObject.tag == "Ouro")
        {

            Hidrogenio.SetActive(false);
            Oxigenio.SetActive(false);
            Carbono.SetActive(false);
            Aluminio.SetActive(false);
            Ferro.SetActive(false);
            Helio.SetActive(false);
            Neon.SetActive(false);
            Ouro.SetActive(true);

            RobotSource.clip = OuroAuido;
            RobotSource.Play();

        }

    }
}

