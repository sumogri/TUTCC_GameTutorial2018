using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : SingletonMonoBehaviour<ViewManager> {
    [SerializeField] private Transform choseLayoutPos;
    public Vector3 ChoseLayoutPosition{ get { return choseLayoutPos.position; } }

}
