using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstDrawing : IDrawing
{
    public int DrawNumber { get; private set; }

    public IEnumerator DrawCoroutine(List<Card> cards)
    {
        DrawNumber = 0;
        yield return null;
    }
}