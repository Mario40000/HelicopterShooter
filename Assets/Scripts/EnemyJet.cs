using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJet : MonoBehaviour
{
    //Variables
    public float speed = 0.0f;
    public int scoreValue = 0;
    public int endurance = 0;

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
    }

    //Metodo para destruir el jet
    void Destroyer ()
    {
        Destroy(gameObject);
    }
}
