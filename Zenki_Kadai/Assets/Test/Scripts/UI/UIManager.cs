using System.Collections.Generic;
using UnityEngine;

public class UIManager<T> where T : Component
{
    private readonly List<T> elements = new List<T>();

    // UI要素を追加
    public void Add(T element) => elements.Add(element);

    // 一括表示
    public void ShowAll()
    {
        foreach (var elem in elements)
            elem.gameObject.SetActive(true);
    }

    // 一括非表示
    public void HideAll()
    {
        foreach (var elem in elements)
            elem.gameObject.SetActive(false);
    }

    // まとめて初期化
    public void ResetAll(System.Action<T> resetAction)
    {
        foreach (var elem in elements)
            resetAction(elem);
    }
}
