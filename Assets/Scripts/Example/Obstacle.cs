using UnityEngine;
using Unity.Scripting.LifecycleManagement;

public partial class Obstacle : MonoBehaviour
{
    [AutoStaticsCleanup] public static float MoveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveSpeed * Time.deltaTime * Vector2.left);

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
