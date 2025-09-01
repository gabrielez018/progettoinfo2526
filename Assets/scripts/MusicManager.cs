using UnityEngine;
public enum MusicType
{
    MAINMENU,
    PLAY
}
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private AudioSource audiosource;
    [SerializeField] private AudioClip[] songClips;

    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        
    }
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public static void PlaySound(MusicType sound)
    {
        instance.audiosource.PlayOneShot(instance.songClips[(int)sound], 1f);
    }
}
