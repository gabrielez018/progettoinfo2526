using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("tracking settings")]
    [SerializeField] GameObject lookAtObject;

    public float rotationSpeed = 5.0f;

    public float distanceFromTarget = 10.0f;
    //y camera distance the lookatobject
    public float height = 5.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;

    [SerializeField] float minClamp = -60f;
    [SerializeField] float maxClamp = 60f;

    [Header("shake settings")]

    [SerializeField] float shakeDuration;

    public bool shake = false;

    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        currentY = Mathf.Clamp(currentY, minClamp, maxClamp);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        Vector3 newCameraPosition = rotation * new Vector3(0.0f, height, -distanceFromTarget) + lookAtObject.transform.position;

        // Imposta la posizione e la rotazione della telecamera
        transform.position = newCameraPosition;
        transform.LookAt(lookAtObject.transform);
        if (shake)
        {
            shake = false;
            StartCoroutine(shaking());
        }
    }

    IEnumerator shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.onUnitSphere;
            yield return null;
        }
        transform.position = startPosition;
    }

    public void setShake()
    {
        shake = true;
    }
}
