using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardFactory{

    public static Card[] GenerateDeck()
    {
        const int deckSize = 53;

        Card[] cards = new Card[deckSize];
        for(int i = 0; i < deckSize; i++)
        {
            cards[i] = new Card(i);
        }
        cards = cards.OrderBy(x => Random.Range(1,100)).ToArray();

        return cards;
    }
}
