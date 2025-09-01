using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Vector3 scaleFactor = new Vector3(1.2f, 1.2f, 1.2f);
    [SerializeField] float transitionDuration = 0.2f;
    private Vector3 originalScale = Vector3.zero;
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
    }
    private IEnumerator ScaleTo(Vector3 targetScale)
    {
        Vector3 currentScale = transform.localScale;
        float time = 0;
        while (time<transitionDuration) {
            time += Time.deltaTime;
            float progress = time / transitionDuration;
            transform.localScale = Vector3.Lerp(currentScale, targetScale, progress);
            yield return null;
        }
    }
}
