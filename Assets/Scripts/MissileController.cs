using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    //Variables
    public float missileSpeed = 0.0f;
    public int damage = 0;
    //public GameObject explosion;

    private GameObject enemy;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            transform.Translate(Vector3.forward * missileSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * missileSpeed * Time.deltaTime);
        }

        if(transform.position.z > 55f)
        {
            Destroy(gameObject);
        }
    }
}
