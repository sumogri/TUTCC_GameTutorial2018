using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player{
    public List<Card> HavingCards { get; private set; } = new List<Card>();

    /// <summary>
    /// 数字一致のカードを捨てる
    /// </summary>
    public void TrashCards()
    {

    }

    /// <summary>
    /// カードを一枚引く
    /// </summary>
    /// <param name="drewList">引く対象のリスト</param>
    public IEnumerator DlawCardCoroutine(List<Card> drewList)
    {
        var c = drewList[0];
        drewList.RemoveAt(0);

        HavingCards.Add(c);
        yield return null;
    }

    /// <summary>
    /// 手札をシャッフルする
    /// </summary>
    public IEnumerator SoteCardsCoroutine()
    {
        HavingCards = HavingCards.OrderBy(x => Guid.NewGuid()).ToList();
        yield return null;
    }
}
