using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private float startSpeed;
    private Rigidbody enemyRb;
    public GameObject playerGoal;
    private float limitBotoom = -10f;
    private SpawnManagerX spawnManagerScript;
    private int nbOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();

        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        nbOfEnemies = spawnManagerScript.enemyCount;
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;

        speed = startSpeed + (50 * nbOfEnemies);
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if ((other.gameObject.name == "Enemy Goal") || (other.gameObject.name == "Player Goal") || (transform.position.y < limitBotoom))
        {
            Destroy(gameObject);
        }
    }
}
