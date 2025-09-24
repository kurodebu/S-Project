using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    // Assign your audio clip in inspector or load dynamically
    public AudioClip backgroundMusic;

    private AudioSource audioSource;
    private bool isPlaying = true;

    private Button toggleButton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.Play();

            isPlaying = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetupToggleButton();
    }
    void SetupToggleButton()
    {
        // Look for a button named "MusicToggleButton" in the scene
        if (toggleButton == null)
        {
            GameObject buttonObj = GameObject.Find("MusicToggleButton");
            if (buttonObj != null)
            {
                toggleButton = buttonObj.GetComponent<Button>();
                if (toggleButton != null)
                {
                    toggleButton.onClick.RemoveAllListeners();
                    toggleButton.onClick.AddListener(ToggleMusic);
                }
            }
        }
    }

    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            isPlaying = false;
            Debug.Log("Music paused");
        }
        else
        {
            audioSource.Play();
            isPlaying = true;
            Debug.Log("Music playing");
        }
    }

    public bool IsMusicPlaying()
    {
        return isPlaying;
    }
}

