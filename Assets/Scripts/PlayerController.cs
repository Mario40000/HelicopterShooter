using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Variables
    public float playerSpeed = 0.0f;
    public float playerTilt = 0.0f;

    private Rigidbody rb;

    //Prefabs
    public GameObject bullet;
    public GameObject missile;
    public GameObject explosion;

    //Armas
    public Transform gun1;
    public Transform gun2;
    public Transform gun3;
    public Transform gun4;
    public Transform rocket1;
    public Transform rocket2;
    public Transform rocket3;
    public Transform rocket4;
    public Transform missile1;
    public Transform missile2;
    public Transform missile3;
    public Transform missile4;
    public float gunFireRate = 0.0f;
    public float rocketFireRate = 0.0f;
    public float missileFireRate = 0.0f;
    public int gunPower = 0;
    public int rocketPower = 0;
    public int missilePower = 0;

    private float nextFire = 0.0f;
    private float nextMissile = 0.0f;
    private float nextRocket = 0.0f;
    

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		//Si pulsamos espacio disparamos
        if(Input.GetButtonDown("Jump"))
        {
            MainShot();
        }

        //Si pulsamos ctrl izquierdo lanzamos misiles
        if (Input.GetButtonDown("Fire1"))
        {
            MissileShot();
        }
	}

    private void FixedUpdate()
    {
        Move();
    }
    //Metodo para desplazar al player
    private void Move()
    {
        //Recogemos si hay valor en los ejes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Si hay valor movemos la aeronave
        //transform.Translate(Vector3.right * playerSpeed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.forward * playerSpeed * verticalInput * Time.deltaTime);

        //Hacemos el alabeo del helicoptero
        Vector3 movement = new Vector3(horizontalInput, 0.0f , 0.0f);
        rb.velocity = movement * playerSpeed;
        rb.rotation = Quaternion.Euler(- 0.0f, 0.0f, (rb.velocity.x * playerTilt) * -1);

        //No podremos pasar de los limites de la pantalla
        //Con las anidaciones corregimos un bug por el cual la aeronave escapaba por las esquinas
        if (transform.position.x > 67)
        {
            if (transform.position.z < -32 && transform.position.x > 67)
            {
                transform.position = new Vector3(67f, transform.position.y, -32f);
            }
            else if (transform.position.z > 32 && transform.position.x > 67)
            {
                transform.position = new Vector3(67f, transform.position.y, 32f);
            }
            else
            {
                transform.position = new Vector3(67f, transform.position.y, transform.position.z);
            }    
        }
        else if (transform.position.x < -67)
        {
            if (transform.position.z < -32 && transform.position.x < -67)
            {
                transform.position = new Vector3(-67f, transform.position.y, -32f);
            }
            else if (transform.position.z > 32 && transform.position.x < -67)
            {
                transform.position = new Vector3(-67f, transform.position.y, 32f);
            }
            else
            {
                transform.position = new Vector3(-67f, transform.position.y, transform.position.z);
            }
        }
        else if (transform.position.z > 32)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 32f);
        }
        else if (transform.position.z < -32)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -32f);
        }
    }

    //Disparo principal
    void MainShot ()
    {
        //Comprobamos si ha pasado el cooldown
        if (Time.time > nextFire)
        {
            if (gunPower > 0)
            {
                //Comprobamos si tenemos power o no
                nextFire = Time.time + gunFireRate;
                Instantiate(bullet, gun1.position, Quaternion.identity);
                Instantiate(bullet, gun2.position, Quaternion.identity);
                Instantiate(bullet, gun3.position, Quaternion.identity);
                Instantiate(bullet, gun4.position, Quaternion.identity);
            }
            else
            {
                nextFire = Time.time + gunFireRate;
                Instantiate(bullet, gun1.position, Quaternion.identity);
                Instantiate(bullet, gun2.position, Quaternion.identity);
            }
        }
    }

    //Metodo para disparar los misiles aire-tierra
    void MissileShot ()
    {
        //Comprobamos si ha pasado el cooldown
        if (Time.time > nextMissile)
        {
            //Comprobamos si tenemos Power o no
            if (missilePower > 0)
            {

                nextMissile = Time.time + missileFireRate;
                Instantiate(missile, missile1.position, Quaternion.identity);
                Instantiate(missile, missile2.position, Quaternion.identity);
                Instantiate(missile, missile3.position, Quaternion.identity);
                Instantiate(missile, missile4.position, Quaternion.identity);
            }
            else
            {
                
                nextMissile = Time.time + missileFireRate;
                Instantiate(missile, missile1.position ,Quaternion.identity);
                Instantiate(missile, missile2.position, Quaternion.identity);
            }
        }
    }

    //Comprobamos si chocamos con algo
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroyer();
        }
    }

    //Metodo para destruir al player
    void Destroyer ()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
