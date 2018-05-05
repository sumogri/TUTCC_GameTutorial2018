using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions{
    private ISorting sorting;
    private IDrawing drawing;

    public PlayerActions(ISorting sorting,IDrawing drawing)
    {
        this.sorting = sorting;
        this.drawing = drawing;
    }

    public List<Card> Sort(List<Card> cards)
    {
        return sorting.Sort(cards);
    }

    public int Draw(List<Card> cards)
    {
        return drawing.DrawNumber(cards);
    }
}
