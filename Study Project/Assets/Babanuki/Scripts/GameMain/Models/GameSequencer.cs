using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ゲームの流れを管理するクラス
/// </summary>
public class GameSequencer : MonoBehaviour {
    private List<Player> players = new List<Player>();

	// Use this for initialization
	void Start () {
        //プレイヤーの生成
        for (int i = 0; i < 4; i++)
            players.Add(new Player());

        players[0].Name = "一色";
        players[1].Name = "二葉";
        players[2].Name = "三条";
        players[3].Name = "四宮";

        StartCoroutine(GameCoroutine());
	}
	
    private IEnumerator GameCoroutine()
    {
        //席順 == listの格納順
        int turnPlayerIndex = 0;

        //カード配布
        Card[] cards = CardFactory.GenerateDeck();
        for (int i = 0; i < cards.Length; i++)
        {
            players[(i+turnPlayerIndex) % players.Count].HavingCards.Add(cards[i]);
        }

        foreach (var p in players)
            p.TrashCards();

        //初期手札をすべて捨てられたら、それはあがり
        players.RemoveAll(x => !x.HavingCards.Any());

        Player turnPlayer = players[turnPlayerIndex];

        //メインルーチン
        while (players.Count > 1)
        {
            Player drewPlayer = players[turnPlayerIndex + 1 == players.Count ? 0 : turnPlayerIndex + 1];

            Debug.Log($"引く{turnPlayer.Name},引かれる{drewPlayer.Name}");

            //引かれる側は手札をシャッフル
            yield return drewPlayer.SortCardsCoroutine();

            //カードを次の人から引く

            yield return turnPlayer.DlawCardCoroutine(drewPlayer.HavingCards);

            turnPlayer.TrashCards();

            //勝ち状況を確認
            bool isWonTurnP = PlayerWon(turnPlayer);
            bool isWonDrewP = PlayerWon(drewPlayer);
            Player nextTurnPlayer = turnPlayer;

            //ターンプレイヤーのアップデート
            if (!isWonDrewP)
            {
                nextTurnPlayer = drewPlayer;
            }
            else if(isWonTurnP)
            {
                //引かれてあがり、かつ引いてあがったら、次の次のプレイヤーが引く番
                nextTurnPlayer = players[turnPlayerIndex + 2 >= players.Count ? turnPlayerIndex + 2 - players.Count : turnPlayerIndex + 2];
            }
            
            //プレイヤーリストをアップデート
            if (isWonTurnP)
                players.Remove(turnPlayer);

            if (isWonDrewP)
                players.Remove(drewPlayer);

            turnPlayer = nextTurnPlayer;
            turnPlayerIndex = players.FindIndex(x => x == turnPlayer);

            string log = "";
            foreach(var p in players)
            {
                log += $"{p.Name}:{p.HavingCards.Count},";
            }
            Debug.Log(log);

            yield return new WaitForSeconds(1f);
        }

        Debug.Log("Game Finish");
    }

    private static bool PlayerWon(Player player)
    {
        return !player.HavingCards.Any();
    }
}
