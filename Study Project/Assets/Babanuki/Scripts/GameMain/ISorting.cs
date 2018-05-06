using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISorting{
    List<Card> SortedHand { get; }
    /// <summary>
    /// 手札の順列を入れ替えるアルゴリズム
    /// </summary>
    /// <param name="cards">入れ替え前の手札</param>
    IEnumerator SortCoroutine(List<Card> cards);
}
