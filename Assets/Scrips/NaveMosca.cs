using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMosca : MonoBehaviour
{
    public float velocidad = 5f;
    void Update()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);

        if (transform.position.y < -6) //Ajusta segun la posicion de tu escenario
        {
            GameManger gameManger = FindObjectOfType<GameManger>();
            if (gameManger != null)
            {
                gameManger.IncrementarMissed(1); // Incrementar el contador de naves perdidas
            }
            Destroy(gameObject);    // Destruye la nave que se paso 
        }
    }
}
