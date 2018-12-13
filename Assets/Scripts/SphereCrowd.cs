using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SphereCrowd : MonoBehaviour {

    public int numSpheres;
    public GameObject sphereTemplate;

	// Use this for initialization
	void Start () {
        System.Random random = new System.Random();
        for (int i = 0; i < numSpheres; i++) {
            GameObject copy = GameObject.Instantiate(sphereTemplate);
            float x = random.Next(-5,5);
            float z = random.Next(-5,5);
            copy.transform.position = new Vector3(x,0,z);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
