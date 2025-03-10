using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    [SerializeField] private bool startTimer = false;
    [SerializeField] private float targetTime = 180f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Timer
    private void Update()
    {
        if(startTimer)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0f)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {

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
