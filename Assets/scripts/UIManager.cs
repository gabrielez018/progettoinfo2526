using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] String gameSceneName;
    [SerializeField] String menuSceneName;
    //[SerializeField] GameObject settingsPanel;
    public static UIManager instance;
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
        //settingsPanel.SetActive(false);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
        SoundFXManager.playSound(SoundType.UI);
        MusicManager.PlaySound(MusicType.PLAY);
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
        SoundFXManager.playSound(SoundType.UI);
        MusicManager.PlaySound(MusicType.MAINMENU);
    }
    public void OpenSettingsPanel()
    {
        //settingsPanel.SetActive(true);
    }
    public void CloseSettingsPanel()
    {
        //settingsPanel.SetActive(false);
    }
    
    
}
