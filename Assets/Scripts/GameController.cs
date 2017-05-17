using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float wavesWait;
    public Text text;
    public Text gameOver;
    public Text restart;
    public GameObject player;

    private int score;

    void Start()
    {
        StartCoroutine(SpawnWaves());
        score = 0;
        text.text = "Score " + score;
    }

    void Update()
    {
        if(restart)
        {
            if (Input.GetKey(KeyCode.R))
                SceneManager.LoadScene(0);
        }
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (player)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawanPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawanPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(wavesWait);
        }
    }
    public void UpdateScore()
    {
        score += 10;
        text.text= text.text = "Score " + score;
    }
}
