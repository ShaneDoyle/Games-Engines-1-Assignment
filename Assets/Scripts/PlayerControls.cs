using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [Range(0, 360)]
    public float rotationSpeed = 180f;
    public float moveSpeed = 20.0f;

    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;

    // Use this for initialization
    void Start()
    {
        //start = .this.transform;
        //to = Quaternion.LookRotation(enemy.transform.position - )
    }

    Quaternion start, to;
    float t;
    // Update is called once per frame
    void Update()
    {



        //transform.rotation = Quaternion.LookRotation();
        // transform.LookAt(enemy)
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.transform.rotation = transform.rotation;
        }
    }
}
