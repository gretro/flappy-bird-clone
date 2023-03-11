using UnityEngine;

public class PipeLogic : MonoBehaviour
{
    public Transform pipe;
    public float Speed = 5.0f;
    public float DespawnBound;

    private void Update()
    {
        if (pipe.position.x < DespawnBound)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        pipe.position = new Vector3(pipe.position.x - Speed * Time.fixedDeltaTime, pipe.position.y, pipe.position.z);
    }
}
