using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;



public class gun : MonoBehaviour
{
    bool firing = false;
    Sprite IDLE, FIRING;
    public Transform player;

    Thread fireThread;
    // Start is called before the first frame update
    void Start()
    {
        fireThread = new Thread(new ThreadStart(Fire));
        IDLE = Resources.Load<Sprite>("gun");
        FIRING = Resources.Load<Sprite>("gun_fire");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;

        transform.position = player.position;
        
        
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x);

        transform.rotation = Quaternion.Euler(0f, 0f, rot_z * Mathf.Rad2Deg);

        Vector3 direction = new Vector3(Mathf.Cos(rot_z), Mathf.Sin(rot_z));

        transform.position += direction*3;

        AudioSource audio = GetComponent<AudioSource>();
        if (Input.GetMouseButton(0))
        {
            if (!fireThread.IsAlive)
            {
                fireThread = new Thread(new ThreadStart(Fire));
                fireThread.Start();
            }

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
            
            if (hit.collider != null) 
            {
                try
                {
                    hit.collider.gameObject.GetComponent<CowBehavior>().Die();
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 20 * Time.deltaTime, ForceMode2D.Impulse);
                }
                catch { }
            }

            if (!audio.isPlaying)
                audio.Play();
        }

        if(firing)
            gameObject.GetComponent<SpriteRenderer>().sprite = FIRING;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = IDLE;

    }

    void Fire() 
    {
        firing = true;
        Thread.Sleep(60);
        firing = false;
        Thread.Sleep(60);
    }
}
