using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveDefensora : MonoBehaviour
{
    public AudioClip sonidoDisparo;
    private AudioSource audioSource;
    public GameObject proyectilPrefab;
    public Transform puntoDeDisparo; // Asegurate de que este campo sea de tipo Transform
    public float velocidad = 5f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // 
    }

    void Update()
    {
        //Movimiento de la nave defensora
        float movientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * movientoHorizontal * velocidad * Time.deltaTime);

        //Disparo del proyectil
        if (Input.GetButtonDown("Firel")) // configura el botón de disparo en los Input Settings
        {
            Disparar();
        }

    }

    public void Disparar()
    {
        if (puntoDeDisparo != null && proyectilPrefab != null)
        {
            Instantiate(proyectilPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
            if (sonidoDisparo != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoDisparo);
            }

            else
            {
                Instantiate(proyectilPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
            }
        }
        else
        {
            Debug.LogError("PuntoDeDisparo o proyectilPrefab no están asigandos.");
        }
    }


}

