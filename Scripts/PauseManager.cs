using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;

    public GameObject pausePanel;

    private bool isPaused = false;
    public bool IsPaused => isPaused;
    private float cachedMusicVolume;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        // Cache user volume
        cachedMusicVolume = AudioManager.instance.musicSource.volume;

        // Dim music instead of overriding
        AudioManager.instance.musicSource.volume = cachedMusicVolume * 0.3f;

        Time.timeScale = 0.0001f;

        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        AudioManager.instance.musicSource.volume = savedVolume;

        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pausePanel.SetActive(false);
    }

}
