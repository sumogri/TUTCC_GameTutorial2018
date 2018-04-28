using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log($"{gameObject.name}:Start!");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log($"{gameObject.name}:Update!");
	}
}
