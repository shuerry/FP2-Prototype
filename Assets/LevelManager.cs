using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
//    public float levelDuration = 30.0f;
//    public float levelScoreNeeded = 5;
//    public Text timerText;
//    public Text gameText;

// This is still here in case we want it but like. lowkey. it doesn't matter how long it takes as long as they don't die
    public AudioClip gameOverSFX;
//    public AudioClip gameWonSFX;
// I'm going to control game win sound effects based on position in the third level -- will trigger when door opens
//    public static int score = 0;
// Do we want/need a scoring system?
    public static bool isGameOver = false;
//    public static bool lessThanHalfTime = false;

    public string nextLevel;
//    float countDown;
    void Start()
    {
        isGameOver = false;
        // score = 0;
        // countDown = levelDuration;
        // SetTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) {
            // will be controlled via player health / death function -- tbd
            /* if (countDown > 0) {
                countDown -= Time.deltaTime;
            } else {
                countDown = 0.0f;
                LevelLost();
            }

            SetTimerText();

            if (score >= levelScoreNeeded) {
                LevelBeat();
            } */
        }
    }

    /* public void SetTimerText() {
        timerText.text = countDown.ToString("f2") + "  SCORE: " + score.ToString("f");
    } */
    public void LevelLost() {
        isGameOver = true;
        // gameText.text = "GAME OVER";
        // gameText.gameObject.SetActive(true);

        Camera.main.GetComponent<AudioSource>().pitch = 1;
        AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position);

        Invoke("LoadCurrentLevel", 2);
    }

    public void LevelBeat() {
        isGameOver = true;
        // gameText.text = "YOU WIN!";
        // gameText.gameObject.SetActive(true);

        // Camera.main.GetComponent<AudioSource>().pitch = 2;
        // AudioSource.PlayClipAtPoint(gameWonSFX, Camera.main.transform.position);

        if(!string.IsNullOrEmpty(nextLevel)) {
            Invoke("LoadNextLevel", 2);
        }
    }

    void LoadNextLevel() {
        SceneManager.LoadScene(nextLevel);
    }

    void LoadCurrentLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}