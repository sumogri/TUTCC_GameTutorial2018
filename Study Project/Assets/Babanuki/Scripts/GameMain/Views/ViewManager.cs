using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewManager : SingletonMonoBehaviour<ViewManager> {
    [SerializeField] private Transform choseLayoutPos;
    [SerializeField] private GameObject cardPrefab;
    public Vector3 ChoseLayoutPosition{ get { return choseLayoutPos.position; } }
    public List<Sprite> TrumpSprites { get; private set; } = new List<Sprite>();
    private const string spritesPass = "Textures/trump/png/";

    private void Awake()
    {
        foreach (var c in "cdsh")
        {
            for(int i = 1; i <= 13; i++)
            {
                TrumpSprites.Add(Resources.Load<Sprite>($"{spritesPass}{c}{i:00}"));
            }
        }
        TrumpSprites.Add(Resources.Load<Sprite>($"{spritesPass}x01"));
    }
}