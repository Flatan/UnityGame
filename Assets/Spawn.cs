using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    public GameObject cow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float avgCowsPerSecond = 0.2f;
        double probability = 1 - Mathf.Exp(-avgCowsPerSecond*Time.deltaTime);
        if (Random.value <= probability)
        {
            Vector2 pos = RandomPointInBounds(gameObject.GetComponent<SpriteRenderer>().bounds);
            GameObject newCow = Instantiate(cow, pos, Quaternion.identity);
            newCow.SetActive(true);
        }
        
    }

    public static Vector2 RandomPointInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }
}
