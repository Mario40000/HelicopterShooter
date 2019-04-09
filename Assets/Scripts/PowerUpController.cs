using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{

    //Variables
    [SerializeField]
    private float _speed = 0.0f;
    [SerializeField]
    private int powerUpID;//0 = gunPower, 1 = missilePower, 2 = rockets
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -50f)
        {
            Destroy(gameObject);
        }
    }

    //Miramos si hemos colisionado con algo
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.tag == "Player")
        {
            //Accedemos a los componentes del jugador
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                if (powerUpID == 0)
                {
                    player.gunPower = 1;
                }
                else if (powerUpID == 1)
                {
                    player.missilePower = 1;
                }
                else if (powerUpID == 2)
                {
                    player.rocketPower = 1;
                }

            }
            Destroy(gameObject);
        }
    }
}
