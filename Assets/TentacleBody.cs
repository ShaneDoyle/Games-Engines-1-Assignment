using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class TentacleBody : MonoBehaviour
{
    // User Inputs
    public GameObject CopyTarget;
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public float startdelay = 1;
    public float localtime;
    bool delay = false;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
        StartCoroutine(Delay());
        amplitude *= -1;

    }

    IEnumerator Delay()
    {
        delay = false;
        yield return new WaitForSeconds(0);
        delay = true;
    }

    // Update is called once per frame
    void Update()
    {

        float levelTimer = Time.fixedTime - (startdelay * 0.1f);
        if (delay == true)
        {
            // Spin object around Y-Axis
            transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

            // Float up/down with a Sin()
            tempPos = posOffset;
            tempPos.x += Mathf.Sin(levelTimer * Mathf.PI * frequency) * amplitude;
            transform.position = tempPos;

            //Copy targets rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, CopyTarget.transform.rotation, 0.2f);
        }
    }
}