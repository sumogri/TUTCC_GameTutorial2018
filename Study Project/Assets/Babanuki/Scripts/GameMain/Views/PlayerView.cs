using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour {
    [SerializeField] private GameObject cardLayout;
    [SerializeField] private Text nameText;
    [SerializeField] private Text handCountText;
    private HorizontalLayoutGroup cardLayoutGroup;
    private Vector3 cardLayoutOriginPos;
    private float cardLayoutGroupOriginSpacing;

    // Use this for initialization
    void Start() {
        cardLayoutGroup = cardLayout.GetComponent<HorizontalLayoutGroup>();
        cardLayoutOriginPos = cardLayout.transform.position;
        cardLayoutGroupOriginSpacing = cardLayoutGroup.spacing;        
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

}
