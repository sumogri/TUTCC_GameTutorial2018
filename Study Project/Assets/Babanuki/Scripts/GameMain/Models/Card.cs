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

    static int ToId(int number,Suit suit)
    {
        return number + (int)suit * 13;
    }
}

public enum Suit { Clover, Diamond, Heart, Spade, Joker }

