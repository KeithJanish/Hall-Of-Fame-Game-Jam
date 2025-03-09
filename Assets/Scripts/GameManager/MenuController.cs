using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Main Menu
    public void PlayBttn()
    {
        SceneManager.LoadSceneAsync("Dream");
    }
    public void CreditsBttn()
    {
        SceneManager.LoadSceneAsync("CreditsScene");
    }
    public void ExitBttn()
    {
        Application.Quit();
        print("Exiting Game!");
    }
}
