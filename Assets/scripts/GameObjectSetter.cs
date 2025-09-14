using UnityEngine;

public class GameObjectSetter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.RegisterPausePanel(this.gameObject);
    }

}
