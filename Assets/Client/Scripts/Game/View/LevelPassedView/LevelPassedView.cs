using UnityEngine;

public class LevelPassedView : MonoBehaviour
{
    public void NextLevel()
    {
        GameController.Instance.LoadNextLevel();
    }
}
