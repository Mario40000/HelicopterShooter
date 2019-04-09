using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //Variables
    public float bulletSpeed = 0.0f;
    public int damage = 0;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        //Hacemos que siempre mueva hacia arriba
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        //Destruimos el laser si sale de la pantalla
        if (transform.position.z > 55f)
        {
            Destroy(gameObject);
        }
    }
}
