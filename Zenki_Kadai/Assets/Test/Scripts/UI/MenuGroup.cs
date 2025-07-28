using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class MenuGroup
{
    public MenuType menuType;

    [Header("ボタン")]
    public Button[] buttons;

    [Header("テキスト")]
    public TMP_Text[] texts;

    [Header("背景")]
    public Image backgroundImage;

    [Header("スライダー")]
    public Slider[] sliders;
}
