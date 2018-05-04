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

        StartCoroutine(GameCoroutine());
	}
	
    private IEnumerator GameCoroutine()
    {
        //席順 == listの格納順
        //最初に"引く"手番のプレイヤーを決める
        int turnPlayerIndex = Random.Range(0,players.Count-1);
        Player turnPlayer = players[turnPlayerIndex];

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

        //メインルーチン
        while (players.Count > 1)
        {
            //引くはずのプレイヤーがあがっている
            if(turnPlayer != players[turnPlayerIndex])
            {
                turnPlayer = players[turnPlayerIndex];
            }
            Player drewPlayer = players[turnPlayerIndex + 1 == players.Count ? 0 : turnPlayerIndex + 1];

            //引かれる側は手札をシャッフル
            var sorting = StartCoroutine(drewPlayer.SoteCardsCoroutine());
            yield return sorting;

            //カードを次の人から引く
            var dlawing = turnPlayer.DlawCardCoroutine(drewPlayer.HavingCards);
            yield return dlawing;

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
        }

        Debug.Log("Game Finish");
    }

    private static bool PlayerWon(Player player)
    {
        return !player.HavingCards.Any();
    }
}
