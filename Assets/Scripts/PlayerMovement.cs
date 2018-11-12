using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, 360)]
    public float rotationSpeed = 180f;
    public float moveSpeed = 20.0f;

    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;

    public int Health = 3;

    //Attack variables.
    public int fireCoolDown = 1;
    bool canShoot = true;
    bool canJump = true;
    


    // Use this for initialization
    void Start()
    {

    }

    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireCoolDown);
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        //Jump test
        if (Input.GetKey(KeyCode.Space) && canJump == true)
        {
            transform.Translate(0, 10, 0);
            canJump = false;
        }

    }

    //Gravity
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            Debug.Log("hit");
        }
        else
        {
        }
    }
    
}
