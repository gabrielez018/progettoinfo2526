using UnityEngine;
using TMPro;

public class TMPSetter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TMP_Text text = GetComponent<TMP_Text>();
        if (text != null && GameManager.Instance != null)
        {
            GameManager.Instance.RegisterText(text);
        }
    }

}
