using UnityEngine;
public enum SoundType
{
    UI,
    CUT,
    TASK
}
    [RequireComponent(typeof(AudioSource))]
public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    private AudioSource audiosource;
    [SerializeField] private AudioClip[] soundClips;

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
    public static void playSound(SoundType sound)
    {
        instance.audiosource.pitch = Random.Range(instance.minPitch,instance.maxPitch);
        instance.audiosource.PlayOneShot(instance.soundClips[(int)sound], 1f);
    }
}
