using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{

    public Transform target;
    NavMeshAgent agent;

    float currentHealth;
    public float maxHealth;

    public Image healthBarFill;

    public GameObject gutsPreFab;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        target = FindObjectOfType<FPSController>().transform;

    }

    // Update is called once per frame derp derp derp
    void Update()
    {
        ChaseTarget();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene(0);
        }
    }

    public void EatBrain()
    {

    }

    public void ChaseTarget()
    {
        agent.destination = target.position;
    }

    public void TakeDamage(float DamageToGive)
    {
        currentHealth -= DamageToGive;
        healthBarFill.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0)
        {
            Instantiate(gutsPreFab, transform.position, transform.rotation, null);
            ZombieSpawner.Instance.CountZombies();
            Destroy(gameObject);
        }
    }

}
