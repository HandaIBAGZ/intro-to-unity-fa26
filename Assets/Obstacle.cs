using UnityEngine;
using Unity.Scripting.LifecycleManagement;

[AutoStaticsCleanup]
public partial class Obstacle : MonoBehaviour
{

    public static float moveSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
