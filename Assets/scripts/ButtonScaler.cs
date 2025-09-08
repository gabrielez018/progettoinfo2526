using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Vector3 newScale = new Vector3(1.5f, 1.5f, 1.5f);
    [SerializeField] float transitionDuration = 0.05f;
    private Vector3 originalScale = Vector3.zero;
    void Start()
    {
        originalScale = transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleTo(newScale));
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleTo(originalScale));
    }
    private IEnumerator ScaleTo(Vector3 targetScale)
    {
        Vector3 currentScale = transform.localScale;
        float time = 0;
        while (time < transitionDuration)
        {
            time += Time.deltaTime;
            float progress = time / transitionDuration;
            transform.localScale = Vector3.Lerp(currentScale, targetScale, progress);
            yield return null;
        }
        transform.localScale = targetScale;
    }
}
