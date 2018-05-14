using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

public class Player{
    public List<Card> HavingCards { get; private set; } = new List<Card>();
    public PlayerView View { get; set; }
    public StringReactiveProperty Name { get; } = new StringReactiveProperty();
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
            if (HavingCards[i] == null || HavingCards[i].Suit == Suit.Joker) continue;

            for(int j = i+1; j < HavingCards.Count; j++)
            {
                if (HavingCards[j] == null || HavingCards[j].Suit == Suit.Joker) continue;

                if(HavingCards[i].Number == HavingCards[j].Number)
                {
                    View.TrashCard(HavingCards[i]);
                    View.TrashCard(HavingCards[j]);
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
    /// <param name="drewPlayer">引く対象のプレイヤー</param>
    public IEnumerator DlawCardCoroutine(Player drewPlayer)
    {
        var drewList = drewPlayer.HavingCards;
        yield return action.DrawCoroutine(drewList);
        var drewNumber = action.DrewIndex;

        var c = drewList[drewNumber];

        drewPlayer.View.TrashCard(c);
        drewList.RemoveAt(drewNumber);

        View.GenerateHandCard(c);
        HavingCards.Add(c);
    }

    /// <summary>
    /// 手札をシャッフルする
    /// </summary>
    public IEnumerator SortCardsCoroutine()
    {
        yield return action.SortCoroutine(HavingCards);
        var orderItr = action.HandOrder.GetEnumerator();
        HavingCards = HavingCards.OrderBy(x =>
        {
            var n = orderItr.Current;
            orderItr.MoveNext();
            return n;
        }).ToList();
        
        View.SortCard(action.HandOrder);
    }
}
