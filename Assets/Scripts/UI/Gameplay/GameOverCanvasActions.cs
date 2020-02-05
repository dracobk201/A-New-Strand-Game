using UnityEngine;

public class GameOverCanvasActions : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField] private StringReference SceneToChange;
    [SerializeField] private GameEvent ChangeSceneEvent;

    public void GoToMainMenu()
    {
        SceneToChange.Value = Global.MAINMENUSCENE;
        ChangeSceneEvent.Raise();
    }
}
