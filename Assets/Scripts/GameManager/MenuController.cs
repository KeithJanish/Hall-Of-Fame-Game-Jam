using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    [SerializeField] private bool startTimer = false;
    [SerializeField] private float currentTime = 180f;
    [SerializeField] private float totalTime = 180f;

    [SerializeField] private TextMeshProUGUI timerText;


    // Timer
    private void Update()
    {
        if(startTimer)
        {
            currentTime -= Time.deltaTime;
            timerText = FindAnyObjectByType<TextMeshProUGUI>();

        }
        if (currentTime <= 0f && startTimer)
        {
            startTimer = false;
            currentTime = 0f;
            GameOver();
        }

        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = string.Format("{00}:{1:00}", minutes, seconds);
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
