using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// コルーチンで回転させるスクリプト
/// </summary>
public class Rotator : MonoBehaviour {
    //引数なしのリスナが登録できるイベント
    public UnityEvent OnEndRotation { get; } = new UnityEvent();
    private float roteteTime = 10;
    private Vector3 firstEulerAngles;

    private void Start()
    {
        firstEulerAngles = transform.eulerAngles;
    }

    /// <summary>
    /// 回転コルーチンを開始するスクリプト
    /// </summary>
    public void RotationStart()
    {
        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        var startTime = Time.timeSinceLevelLoad;
        var diff = Time.timeSinceLevelLoad - startTime;

        while (diff <= roteteTime) 
        {
            transform.eulerAngles = firstEulerAngles +  new Vector3(360*(diff/roteteTime),0,0);
            //ここで中断、1F待つ
            yield return null;
            diff = Time.timeSinceLevelLoad - startTime;
        }
        transform.eulerAngles = firstEulerAngles;
        
        OnEndRotation.Invoke();
    }
}
