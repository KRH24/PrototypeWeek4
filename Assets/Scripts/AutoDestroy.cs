using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f); // Destroy after 5 seconds
    }
}
