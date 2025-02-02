using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
}
