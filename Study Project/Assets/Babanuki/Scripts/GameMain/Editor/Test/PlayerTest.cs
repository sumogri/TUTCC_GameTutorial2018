using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class PlayerTest {

    private static object[] trashCases = {
        new object[] {
            new List<Card>{
            new Card(13,Suit.Clover),
            new Card(13,Suit.Heart),
            new Card(13,Suit.Diamond)
            }
            ,1
        },
        new object[] {
            new List<Card>{
            new Card(13,Suit.Clover),
            new Card(12,Suit.Heart),
            new Card(11,Suit.Clover),
            new Card(10,Suit.Heart),
            new Card(9,Suit.Clover),
            new Card(8,Suit.Heart),
            new Card(7,Suit.Clover),
            new Card(6,Suit.Heart),
            new Card(5,Suit.Clover),
            new Card(4,Suit.Heart),
            new Card(3,Suit.Diamond)
            }
            ,11
        }
    };

    [TestCaseSource("trashCases")]
    public void PlayerCardTrash(List<Card> cardlist, int trashedSize)
    {
        Player p = new Player();
        foreach (var c in cardlist)
            p.HavingCards.Add(c);

        p.TrashCards();

        Assert.AreEqual(trashedSize,p.HavingCards.Count);
    }
    
 }
