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
        PlaySound(MusicType.MAINMENU);
    }
    public static void PlaySound(MusicType sound)
    {
        instance.audiosource.clip = instance.songClips[(int)sound];
        instance.audiosource.Play();
    }
}
