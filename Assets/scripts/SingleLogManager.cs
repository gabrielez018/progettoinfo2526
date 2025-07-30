using UnityEngine;

public class SingleLogManager : MonoBehaviour
{
    [SerializeField] TreesSpawnerManager treesSpawnerManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (treesSpawnerManager != null)
            {
                treesSpawnerManager.OnLogCut(this.gameObject);
                Collider logCollider = GetComponent<Collider>();
                if (logCollider != null)
                {
                    logCollider.enabled = false;
                }
            }
        }
    }
}
