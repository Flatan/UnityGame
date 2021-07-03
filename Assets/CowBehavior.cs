using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehavior : MonoBehaviour
{
    Sprite ALIVE, DEAD;
    private bool dead = false;
    double timeDead = 0;
    const double decayDuration = 4;
    // Start is called before the first frame update
    void Start()
    {
        ALIVE = Resources.Load<Sprite>("cow_alive");
        DEAD = Resources.Load<Sprite>("cow_dead");
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) 
        {
            timeDead += Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1,1,1,1 - (float) (timeDead/decayDuration));
        }
    }

    public void Die() 
    {
        dead = true;
        transform.rotation = Quaternion.identity;
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = DEAD;
        
        Destroy(gameObject,(float) decayDuration);
    }
}
