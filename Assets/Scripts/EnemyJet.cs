using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJet : MonoBehaviour
{
    //Variables
    public float speed = 0.0f;
    public int scoreValue = 0;
    public int endurance = 0;
    public GameObject explosion;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerFireAir" || other.tag == "PlayerFireGround")
        {
            Destroy(other.gameObject);
            Destroyer();
        }

        if(other.tag == "Player")
        {
            Destroyer();
        }
    }

    //Metodo para destruir el jet
    void Destroyer ()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
