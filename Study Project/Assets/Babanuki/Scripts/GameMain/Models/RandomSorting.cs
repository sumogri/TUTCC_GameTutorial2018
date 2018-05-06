using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSorting : ISorting
{
    public List<Card> SortedHand { get; private set; }


    public IEnumerator SortCoroutine(List<Card> cards)
    {
        SortedHand = cards.OrderBy(x => Random.Range(0, 100)).ToList();
        yield return null;
    }
}
