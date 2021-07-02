using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gun : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
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

        transform.position += new Vector3(Mathf.Cos(rot_z), Mathf.Sin(rot_z), 0)*3;

        AudioSource audio = GetComponent<AudioSource>();
        if (Input.GetMouseButton(0) && !audio.isPlaying)
        {
            audio.Play();
        }
    }
}
