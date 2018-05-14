using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PlayerView : MonoBehaviour {
    [SerializeField] private GameObject cardLayout;
    [SerializeField] private Text nameText;
    [SerializeField] private Text handCountText;
    [SerializeField] private BoolReactiveProperty isOpneCard;    
    private HorizontalLayoutGroup cardLayoutGroup;
    private Vector3 cardLayoutOriginPos;
    private float cardLayoutGroupOriginSpacing;
    private List<GameObject> handCardObjects = new List<GameObject>();
    private Player model;
    public Player Model {
        get { return model; }
        set {
            model = value;
            model.Name.Subscribe(x => nameText.text = x).AddTo(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        cardLayoutGroup = cardLayout.GetComponent<HorizontalLayoutGroup>();
        cardLayoutOriginPos = cardLayout.transform.position;
        cardLayoutGroupOriginSpacing = cardLayoutGroup.spacing;
        isOpneCard.Where(x => x == true).Subscribe(x => OpenCard() );
    }
    
    public void GenerateHandCard(Card card)
    {
        var obj = Instantiate(ViewManager.I.CardPrefab, cardLayout.transform);
        //obj.GetComponent<Image>().sprite = ViewManager.I.TrumpBack;
        obj.GetComponent<Image>().sprite = ViewManager.I.TrumpSprites[Card.ToId(card)];
        handCardObjects.Add(obj);
        obj.name = card.ToString();
    }

    public void TrashCard(Card card)
    {
        var index = handCardObjects.FindIndex(x => x.name == card.ToString());
        Destroy(handCardObjects[index]);
        handCardObjects.RemoveAt(index);
    }

    public void SortCard(List<int> order)
    {
        var orderItr = order.GetEnumerator();
        foreach(var o in handCardObjects)
        {
            o.transform.SetSiblingIndex(orderItr.Current);
            orderItr.MoveNext();
        }
    }

    public void MoveToChose()
    {
        StartCoroutine(HandMoveCoroutien(ViewManager.I.ChoseLayoutPosition, 0f, 1f));
    }

    public void MoveToOrigin()
    {
        StartCoroutine(HandMoveCoroutien(cardLayoutOriginPos, cardLayoutGroupOriginSpacing, 1f));
    }

    private IEnumerator HandMoveCoroutien(Vector3 toPosition,float toSpacing,float moveSec) {
        float startTime = Time.time;
        Vector3 fromPos = cardLayout.transform.position;
        float fromSpacing = cardLayoutGroup.spacing;
    
        for (var distCovered = (Time.time-startTime); distCovered <= moveSec; distCovered = (Time.time - startTime))
        {
            var fractTime = distCovered / moveSec;
            cardLayout.transform.position = Vector3.Lerp(fromPos, toPosition, fractTime);
            cardLayoutGroup.spacing = Mathf.Lerp(fromSpacing,toSpacing,fractTime);
            yield return null;
        }
        cardLayout.transform.position = toPosition;
        cardLayoutGroup.spacing = toSpacing;
    }

    private void OpenCard()
    {

    }
}