using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 回転コルーチンを呼び出すボタンのコントローラー
/// </summary>
public class StartRotateButton : MonoBehaviour {
    [SerializeField] private Rotator rotator;
    private Button myButton;

    // Use this for initialization
    void Start()
    {
        myButton = gameObject.GetComponent<Button>();

        myButton.onClick.AddListener(() => 
            {
                myButton.interactable = false;
                rotator.RotationStart();
            });

        rotator.OnEndRotation.AddListener(() => myButton.interactable = true);
    }
}
