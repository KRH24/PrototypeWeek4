using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 700f;
    public Camera cam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootTowardMouse();
        }
    }

    void ShootTowardMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            // If nothing is hit, shoot far into the distance
            targetPoint = ray.GetPoint(1000f);
        }

        Vector3 direction = (targetPoint - shootPoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direction * shootForce);
        }
    }
}
