using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float timer = 0.0f;
    public GameObject obstacle;

    public GameObject[] obstacleInstances;
    public int numberOfInstances = 10;
    public int instanceIndex = 0;

    private void Start()
    {
        timer = Random.Range(1.0f, 5.0f);
        obstacleInstances= new GameObject[numberOfInstances];

        for(int i=0;i<numberOfInstances; i++)
        {
            obstacleInstances[i] = Instantiate(obstacle);
            obstacleInstances[i].transform.position = transform.position;
            obstacleInstances[i].SetActive(false);
        }
    }


    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnObstacle();
            // Reset timer to a random value between 1 and 2 seconds.
            timer = Random.Range(1.0f, 5.0f);
        }
    }

    void SpawnObstacle()
    {
        obstacleInstances[instanceIndex].SetActive(true);
        obstacleInstances[instanceIndex].transform.position = transform.position;   
        instanceIndex++;
        if(instanceIndex == numberOfInstances)
        {
            instanceIndex = 0;
        }
    }
}