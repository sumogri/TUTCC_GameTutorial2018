using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour {
    [SerializeField] private GameObject cardLayout;
    [SerializeField] private Text nameText;
    [SerializeField] private Text handCountText;
    private Vector3 layoutOriginPos;
    private float moveSec = 1f;
    private HorizontalLayoutGroup cardLayoutGroup;

	// Use this for initialization
	void Start () {
        cardLayoutGroup = cardLayout.GetComponent<HorizontalLayoutGroup>();
        layoutOriginPos = cardLayout.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
