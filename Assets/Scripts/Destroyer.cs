using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //Variables
    public float delayTime = 0.0f;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, delayTime);
	}
}
