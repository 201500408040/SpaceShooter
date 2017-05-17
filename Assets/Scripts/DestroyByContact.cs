using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
        if (other.tag == "Player")
        {
            GameObject newPlayerExplosion = Instantiate(playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(newPlayerExplosion, 2);
            GameController.instance.gameOver.gameObject.SetActive(true);
            GameController.instance.restart.gameObject.SetActive(true);
        }

        GameController.instance.UpdateScore();
        GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        Destroy(newExplosion, 2);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
