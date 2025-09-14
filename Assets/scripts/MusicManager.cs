using UnityEngine;
public enum MusicType
{
    MAINMENU,
    PLAY
}
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    private AudioSource audiosource;
    [SerializeField] private AudioClip[] songClips;

    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        audiosource = GetComponent<AudioSource>();
    }
    void Start()
    {

        PlaySound(MusicType.MAINMENU);
    }
    public void PlaySound(MusicType sound)
    {
        Instance.audiosource.clip = Instance.songClips[(int)sound];
        Instance.audiosource.Play();
    }
    
}
