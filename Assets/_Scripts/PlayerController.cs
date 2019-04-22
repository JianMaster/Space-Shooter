using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System .Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}
public class PlayerController : MonoBehaviour {
    
    float moveHorizontal;
    float moveVertical;
    new Rigidbody rigidbody;
    public float speed;

    public Boundary boundary;

    public GameObject shots;
    public Transform  shotSpawn;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if(Input .GetMouseButton (0)&&Time .time >nextFire )
        {
            nextFire = Time.time + fireRate;
            Instantiate(shots, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

    }


    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        rigidbody .velocity = (new Vector3(moveHorizontal, 0.0f, moveVertical))*speed;

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax));

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, moveHorizontal*(-30.0f) );

    }

}
