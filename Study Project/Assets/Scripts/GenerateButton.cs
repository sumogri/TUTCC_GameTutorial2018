using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// キューブ生成ボタンのコントローラー
/// </summary>
[RequireComponent(typeof(Button))]
public class GenerateButton : MonoBehaviour {
    [SerializeField] private GameObject generatedPrefab;
    private Button myButton;

	// Use this for initialization
	void Start () {
        myButton = gameObject.GetComponent<Button>();
        myButton.onClick.AddListener( () => Instantiate(generatedPrefab) );
	}	
}