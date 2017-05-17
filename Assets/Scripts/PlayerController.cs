using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;
    public float whatever;
    public GameObject bolt;
    public Transform shootSpawn;
    public float fireRate;
    public AudioSource audioSource;

    private float nextFire;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
            );

        transform.rotation = Quaternion.Euler(0, 0, -rb.velocity.x * whatever);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bolt, shootSpawn.position, shootSpawn.rotation);
            audioSource.Play();
        }
    }
}
