using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        DontDestroyOnLoad(gameObject);

        float value = PlayerPrefs.GetFloat(AudioManager.VOLUME_LEVEL_KEY, AudioManager.DEFAULT_VOLUME);
        pausePanel.GetComponentInChildren<Slider>().value = value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void CloseMenu()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}