using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Transform OptionsPanel;
    public GameObject PausePanel;

    public GameObject checkpoint;
    public void PlayGame()
    {
        Time.timeScale = 1;
        checkpoint.transform.position = new Vector3(-65.0f, -12.0f, -1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }
    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        OptionsPanel.GetChild(2).gameObject.SetActive(false);
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
