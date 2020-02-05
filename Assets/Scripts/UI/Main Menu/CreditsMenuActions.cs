using UnityEngine;

public class CreditsMenuActions : MonoBehaviour
{
    public void OpenWeb(int index)
    {
        switch (index)
        {
            case 0:
                Application.OpenURL("https://twitter.com/dracobk201");
                break;
            case 1:
                Application.OpenURL("https://twitter.com/KyuuRocks");
                break;
            case 2:
                Application.OpenURL("https://www.facebook.com/pixel8mike/");
                break;
            case 3:
                Application.OpenURL("https://www.ericksubero.com/");
                break;
            case 4:
                Application.OpenURL("https://www.instagram.com/kyuurocks_art/");
                break;
            case 5:
                Application.OpenURL("https://www.instagram.com/pixel8mike/");
                break;
            case 6:
                Application.OpenURL("https://www.instagram.com/samuelnavas_/");
                break;
            case 7:
                Application.OpenURL("https://soundcloud.com/navassamuel");
                break;
        }
    }
}
