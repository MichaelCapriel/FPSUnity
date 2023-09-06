using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nuggets : MonoBehaviour
{
    public float damgeToGive;
    bool hasHitZombie = false;

    private void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.GetComponent<Zombie>() && !hasHitZombie)
        {
            collision.gameObject.GetComponent<Zombie>().TakeDamage(damgeToGive);
            hasHitZombie = true;
        }
    }
}
