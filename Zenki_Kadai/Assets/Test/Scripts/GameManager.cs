using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MenuUIController menuController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuController.IsMenuOpen(MenuType.Pause))
            {
                CloseMenu();
            }
            else
            {
                OpenPauseMenu();
            }
        }
    }

    public void OpenPauseMenu()
    {
        menuController.ShowMenu(MenuType.Pause);
        Time.timeScale = 0f;
    }

    public void OpenSettingsMenu()
    {
        menuController.ShowMenu(MenuType.Settings);
    }

    public void OpenRestartMenu()
    {
        menuController.ShowMenu(MenuType.Restart);
    }

    public void CloseMenu()
    {
        menuController.HideAll();
        Time.timeScale = 1f; // 再開
    }
}
