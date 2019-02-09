using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void ChangeToScene(int sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }
}
