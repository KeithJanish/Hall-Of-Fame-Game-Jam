using UnityEngine;

public class StarManager : MonoBehaviour
{
    public int starsCollected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(starsCollected == 5)
        {
            //something to end the game;
        }
    }
}
