
using UnityEngine;

public class MenuButton3D : MonoBehaviour
{
    public MainMenu menu;
    public bool isPlayButton;

    void OnMouseDown()
    {
        if (menu == null)
            return;

        if (isPlayButton)
        {
            menu.PlayGame();
        }
        else
        {
            menu.QuitGame();
        }
    }
}
