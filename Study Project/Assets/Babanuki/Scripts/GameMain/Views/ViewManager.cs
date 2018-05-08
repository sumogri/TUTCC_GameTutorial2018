using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewManager : SingletonMonoBehaviour<ViewManager> {
    [SerializeField] private Transform choseLayoutPos;
    public Vector3 ChoseLayoutPosition { get { return choseLayoutPos.position; } }
    [SerializeField] private GameObject cardPrefab;
    public GameObject CardPrefab { get { return cardPrefab; } }
    public List<Sprite> TrumpSprites { get; private set; } = new List<Sprite>();
    public Sprite TrumpBack { get; private set; }
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
        TrumpBack = Resources.Load<Sprite>($"{spritesPass}");
    }
}