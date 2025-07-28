using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] private MenuGroup[] menuGroups;

    // メニューごとのUIマネージャー
    private Dictionary<MenuType, UIManager<Button>> buttonManagers = new();
    private Dictionary<MenuType, UIManager<TMP_Text>> textManagers = new();
    private Dictionary<MenuType, UIManager<Slider>> sliderManagers = new(); // ★追加
    private Dictionary<MenuType, Image> backgroundImages = new();           // ★追加

    // ★ 現在開いているメニューを記録
    private MenuType? currentMenu = null;

    private void Awake()
    {
        foreach (var group in menuGroups)
        {
            // ====== ボタン管理 ======
            var btnManager = new UIManager<Button>();
            foreach (var btn in group.buttons)
                btnManager.Add(btn);
            buttonManagers[group.menuType] = btnManager;

            // ====== テキスト管理 ======
            var txtManager = new UIManager<TMP_Text>();
            foreach (var txt in group.texts)
                txtManager.Add(txt);
            textManagers[group.menuType] = txtManager;

            // ====== スライダー管理 ★追加 ======
            var sldManager = new UIManager<Slider>();
            foreach (var sld in group.sliders)
                sldManager.Add(sld);
            sliderManagers[group.menuType] = sldManager;

            // ====== 背景Image管理 ★追加 ======
            if (group.backgroundImage != null)
            {
                backgroundImages[group.menuType] = group.backgroundImage;
                group.backgroundImage.gameObject.SetActive(false); // 最初は非表示
            }

            // 初期状態は非表示
            btnManager.HideAll();
            txtManager.HideAll();
            sldManager.HideAll();
        }
    }

    /// <summary>
    /// 特定のメニューを表示する
    /// </summary>
    public void ShowMenu(MenuType type)
    {
        HideAll(); // 他のメニューは全部閉じる

        // ボタン表示
        if (buttonManagers.TryGetValue(type, out var btnManager))
            btnManager.ShowAll();

        // テキスト表示
        if (textManagers.TryGetValue(type, out var txtManager))
            txtManager.ShowAll();

        // スライダー表示 ★追加
        if (sliderManagers.TryGetValue(type, out var sldManager))
            sldManager.ShowAll();

        // 背景表示 ★追加
        if (backgroundImages.TryGetValue(type, out var bg))
            bg.gameObject.SetActive(true);

        currentMenu = type; // ★ 今開いてるメニューを記録

        Debug.Log($"{type} メニューを表示");
    }

    /// <summary>
    /// 全メニューを閉じる
    /// </summary>
    public void HideAll()
    {
        // ボタン全部非表示
        foreach (var manager in buttonManagers.Values)
            manager.HideAll();

        // テキスト全部非表示
        foreach (var manager in textManagers.Values)
            manager.HideAll();

        // スライダー全部非表示 ★追加
        foreach (var manager in sliderManagers.Values)
            manager.HideAll();

        // 背景全部非表示 ★追加
        foreach (var bg in backgroundImages.Values)
            bg.gameObject.SetActive(false);

        currentMenu = null; // ★ 閉じたので何も開いていない
    }

    // ★ 追加: 指定メニューが現在開いているか？
    public bool IsMenuOpen(MenuType type)
    {
        return currentMenu.HasValue && currentMenu.Value == type;
    }
}
