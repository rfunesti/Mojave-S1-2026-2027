using Unity.VisualScripting;
using UnityEngine;

public class GameFeel : MonoBehaviour
{
    // Static is the key here. It means the variable belongs to the
    // GameFeel class itself, rather than to an individual object.
    // This allows other scripts to access it using:
    public static GameFeel instance;

    public float cameraShakeTime = 0f;

    // The first GameFeel component becomes the Singleton.
    // If another one is created, Unity destroys the duplicate component.
    private void Awake()
    {
        if(instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static void AddCameraShake(float time)
    {
        if (instance)
        {
            instance.cameraShakeTime = time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraShakeTime > 0f)
        {
            cameraShakeTime -= Time.deltaTime;
            Vector3 newCameraPosition = new Vector3();
            newCameraPosition.x = Random.Range(-0.1f, 0.1f);
            newCameraPosition.y = Random.Range(-0.1f, 0.1f);
            newCameraPosition.z = -10f;
            Camera.main.transform.position = newCameraPosition;
        }
    }
}
