using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip m_BgMusic;
    [SerializeField]
    private AudioClip m_ClickSound;
    private AudioSource m_AudioSource;

    private static AudioManager m_Instance;
    public static AudioManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<AudioManager>();
            }
            return m_Instance;
        }


    }

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();

        if (m_Instance == null)
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        PlayBgMusic(m_BgMusic);
    }

    public void SetMusicVolume(float volume)
    {
        m_AudioSource.volume = volume;
    }

    private void PlayBgMusic(AudioClip bgMusic)
    {
        float volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        m_AudioSource.volume = volume;
        m_AudioSource.clip = bgMusic;
        m_AudioSource.loop = true;
        m_AudioSource.Play();
    }

    public void PlayButtonClickSound()
    {
        float volume = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);
        m_AudioSource.PlayOneShot(m_ClickSound, volume);
    }
}
