using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSorting : ISorting
{
    public List<int> HandOrder { get; private set; }    

    public IEnumerator SortCoroutine(List<Card> cards)
    {
        HandOrder = Enumerable.Range(0,cards.Count).OrderBy(x => Random.Range(0,100)).ToList();
        yield return null;
    }
}
