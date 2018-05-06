using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

public class Player{
    public List<Card> HavingCards { get; private set; } = new List<Card>();
    public string Name { get; set; }
    PlayerAction action;

    public Player(PlayerAction action)
    {
        this.action = action;
    }

    public Player()
    {
        action = new PlayerAction(new RandomSorting(),new ConstDrawing());
    }

    /// <summary>
    /// 数字一致のカードを捨てる
    /// </summary>
    public void TrashCards()
    {
        for(int i = 0; i < HavingCards.Count; i++)
        {
            if (HavingCards[i] == null) continue;

            for(int j = i+1; j < HavingCards.Count; j++)
            {
                if (HavingCards[j] == null) continue;

                if(HavingCards[i].Number == HavingCards[j].Number)
                {
                    HavingCards[i] = null;
                    HavingCards[j] = null;
                    break;
                }
            }
        }

        HavingCards.RemoveAll(x => x == null);
    }

    /// <summary>
    /// カードを一枚引く
    /// </summary>
    /// <param name="drewList">引く対象のリスト</param>
    public IEnumerator DlawCardCoroutine(List<Card> drewList)
    {
        yield return action.DrawCoroutine(drewList);
        var drewNumber = action.DrewIndex;

        var c = drewList[drewNumber];
        drewList.RemoveAt(drewNumber);
        HavingCards.Add(c);
    }

    /// <summary>
    /// 手札をシャッフルする
    /// </summary>
    public IEnumerator SortCardsCoroutine()
    {
        yield return action.SortCoroutine(HavingCards);
        HavingCards = action.SortedHand;
    }
}
