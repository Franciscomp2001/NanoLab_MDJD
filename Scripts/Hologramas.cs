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

    public AudioClip Alum�nioAuido;
    public AudioClip CarbonoAuido;
    public AudioClip FerroAuido;
    public AudioClip H�lioAuido;
    public AudioClip Hidrog�nioAuido;
    public AudioClip Ne�nioAuido;
    public AudioClip OuroAuido;
    public AudioClip Oxig�nioAuido;

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

            RobotSource.clip = Hidrog�nioAuido;
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

            RobotSource.clip = Oxig�nioAuido;
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

            RobotSource.clip = Alum�nioAuido;
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

            RobotSource.clip = H�lioAuido;
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

            RobotSource.clip = Ne�nioAuido;
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

