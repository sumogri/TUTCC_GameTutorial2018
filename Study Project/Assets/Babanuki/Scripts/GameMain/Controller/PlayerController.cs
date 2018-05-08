using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Player model;
    private PlayerView view;

	// Use this for initialization
	void Start () {
        view = gameObject.GetComponent<PlayerView>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
