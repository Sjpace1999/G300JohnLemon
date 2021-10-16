using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public Text numCaptured;
    public Text pressButton;
    public Text timerText;
    public Text highScore;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;
    int count=0;
    float timer;
    float mins;
    float secs;

    void Start()
    {
        pressButton.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //m_IsPlayerAtExit = true;
        }
    }
    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    public void incrementCaptured()
    {
        count++;
        numCaptured.text = "Captured: "+count;
        if (count>=4)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void InstructionsTrue()
    {
        pressButton.enabled = true;
    }

    public void InstructionsFalse()
    {
        pressButton.enabled = false;
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
        //https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/#timer
        timer += Time.deltaTime;
        mins = Mathf.FloorToInt(timer / 60);
        secs = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", mins, secs); ;
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
