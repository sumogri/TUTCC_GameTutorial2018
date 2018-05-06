using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDrawing {
    int DrawNumber { get; }

    /// <summary>
    /// カードを引くアルゴリズム
    /// 戻り値はDrawNumberに入れる
    /// </summary>
    /// <param name="cards">相手の手札</param>
    IEnumerator DrawCoroutine(List<Card> cards);
}