using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject PipePrefab;
    public float SpawnRateInSecs = 1.5f;
    public float PositionYVariation = 12.0f;

    private float deltaTime = 0;
    private Vector3 spawnLocation;

    private void Start()
    {
        spawnLocation = this.gameObject.transform.position;
    }

    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= SpawnRateInSecs)
        {
            SpawnPipes();
            deltaTime = 0;
        }
    }

    void SpawnPipes()
    {
        // TODO: Improve on the Random range algorithm to create more variation between pipes
        var yVariation = Random.Range(PositionYVariation * -1, PositionYVariation);
        var position = spawnLocation + new Vector3(0, yVariation, 0);

        Instantiate(PipePrefab, position, new Quaternion());
    }
}
