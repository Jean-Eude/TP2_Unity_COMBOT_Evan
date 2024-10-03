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
            Debug.Log("Nombre de pièces atteint, chargement de la scène finale.");
            GameVariables.currentTime = GameVariables.allowedTime;
            SceneManager.LoadScene("Scene_Final");
        }
    }


    public void AddHit()
    {
        nbCoins++;  // Incrémenter le nombre de pièces collectées
        coinText.text = "Coins: " + nbCoins;  // Mettre à jour le texte affiché
    }


    IEnumerator TimerTick()
    {
        while (GameVariables.currentTime > 0)
        {
            yield return new WaitForSeconds(1);
            GameVariables.currentTime--;         
            timerText.text = "Time: " + GameVariables.currentTime.ToString();
        }

        Debug.Log("Temps écoulé, rechargement de la scène Terrain.");
        GameVariables.currentTime = GameVariables.allowedTime;
        SceneManager.LoadScene("Terrain");
    }
}

