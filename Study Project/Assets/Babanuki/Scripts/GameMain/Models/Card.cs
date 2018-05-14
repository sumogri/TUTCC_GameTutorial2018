using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {
    public int Number { get; private set; }
    public Suit Suit { get; private set; }
    private const int maxNumber = 13;

    public Card(int number,Suit suit)
    {
        Number = number;
        Suit = suit;
    }

    public Card(int id)
    {
        Number = id % maxNumber + 1;
        Suit = (Suit)(id / maxNumber);
    }

    public override string ToString()
    {
        return $"Card{Suit}{Number}";
    }

    public static int ToId(int number,Suit suit)
    {
        return number-1 + (int)suit * 13;
    }

    public static int ToId(Card card)
    {
        if (card.Suit == Suit.Joker) return 52;
        return card.Number-1 + (int)card.Suit * 13;
    }
}

public enum Suit { Clover, Diamond, Heart, Spade, Joker }

