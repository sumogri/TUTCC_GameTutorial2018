using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISorting{

    /// <summary>
    /// 手札の順列を入れ替えるアルゴリズム
    /// </summary>
    /// <param name="cards">入れ替え前の手札</param>
    /// <returns>入れ替え後の手札</returns>
    List<Card> Sort(List<Card> cards);
}
