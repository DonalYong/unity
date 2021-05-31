using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockect : MonoBehaviour
{
    private GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
         explosion = Resources.Load("prefabs/explosion") as GameObject;//explosion = Resources.Load<GameObject>("explosion");


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float rotationZ = Random.Range(0, 360);
        if (collision.tag != "body")
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0, 0, rotationZ)));
            Destroy(gameObject);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
