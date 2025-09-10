using UnityEngine;
public enum SoundType
{
    UI,
    CUT,
    TASK,
    DEATH,
    GAMEOVER
}
[RequireComponent(typeof(AudioSource))]
public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance{ get; private set; }
    private AudioSource audiosource;
    [SerializeField] private AudioClip[] soundClips;

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

    }
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void PlaySound(SoundType sound)
    {
        Instance.audiosource.pitch = Random.Range(Instance.minPitch,Instance.maxPitch);
        Instance.audiosource.PlayOneShot(Instance.soundClips[(int)sound], 1f);
    }
}
