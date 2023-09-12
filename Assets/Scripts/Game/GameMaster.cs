using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int highscore;
    public int current_score;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 2)
        {
            TextMeshProUGUI score_text = GameObject.FindGameObjectWithTag("CurrentScore").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI highscore_text = GameObject.FindGameObjectWithTag("Highscore").GetComponent<TextMeshProUGUI>();
            score_text.text = string.Format("{0:00}:{1:00}", (int)(current_score / 60),(int)(current_score%60));
            highscore_text.text = string.Format("{0:00}:{1:00}", (int)(highscore / 60), (int)(highscore % 60));
        }
    }


    public void EndGame()
    {
        GameObject timeKeeper = GameObject.Find("TimeKeeper");
        current_score = (int)(timeKeeper.GetComponent<TimeKeeper>().current_time);

        if (current_score > highscore)
            highscore = current_score;

        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(2);
    }
}
