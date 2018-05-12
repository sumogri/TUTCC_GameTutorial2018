using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction{
    private ISorting sorting;
    private IDrawing drawing;

    public PlayerAction(ISorting sorting,IDrawing drawing)
    {
        this.sorting = sorting;
        this.drawing = drawing;
    }

    public IEnumerator SortCoroutine(List<Card> cards)
    {
        return sorting.SortCoroutine(cards);
    }
    public List<int> HandOrder
    {
        get
        {
            return sorting.HandOrder;
        }
    }

    public IEnumerator DrawCoroutine(List<Card> cards)
    {
        return drawing.DrawCoroutine(cards);
    }
    public int DrewIndex
    {
        get
        {
            return drawing.DrawNumber;
        }
    }
}
