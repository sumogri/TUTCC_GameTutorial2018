using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDrawing {

    /// <summary>
    /// カードを引くアルゴリズム
    /// </summary>
    /// <param name="cards">相手の手札</param>
    /// <returns>引くカードのインデックス</returns>
    int DrawNumber(List<Card> cards);
}