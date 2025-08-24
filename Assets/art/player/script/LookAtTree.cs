using UnityEngine;

public class LookAtTree : MonoBehaviour
{
    [SerializeField] Transform gameTree;
    private Vector3 direction;
    private Quaternion rotation;
    private Vector3 eulerAngles;

    // Update is called once per frame
    void Update()
    {
        direction = gameTree.position - transform.position;
        rotation = Quaternion.LookRotation(direction);
        eulerAngles = rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, eulerAngles.y, 0);
    }
}
