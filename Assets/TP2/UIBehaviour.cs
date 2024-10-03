using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour
{

    private TMP_Text coinText;
    private TMP_Text timerText;


    private int nbCoins = 0;
    public int totalCoins = 5;

    void Start()
    {
        coinText = GameObject.Find("lblCoins").GetComponent<TMP_Text>();
        timerText = GameObject.Find("lblTime").GetComponent<TMP_Text>();

        coinText.text = "Coins: " + nbCoins;
        timerText.text = "Time: " + GameVariables.currentTime;


        StartCoroutine(TimerTick());
    }

    void Update()
    {
        if (nbCoins >= totalCoins)
        {
            SceneManager.LoadScene("S");
        }
    }


    public void AddHit()
    {
        nbCoins++;
        coinText.text = "Coins: " + nbCoins;
    }


    IEnumerator TimerTick()
    {
        while (GameVariables.currentTime > 0)
        {

            yield return new WaitForSeconds(1);
            GameVariables.currentTime--;
            timerText.text = "Time: " + GameVariables.currentTime.ToString();
        }


        SceneManager.LoadScene("Terrain");
    }
}

