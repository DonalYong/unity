using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float fSpeed = 10;
    Playercontrol playerCtrl;
    private AudioSource ac;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = transform.root.GetComponent<Playercontrol>();
        ac = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))//if(Input.GetButtonDown("Fire1"))
        {
            ac.Play();
            Vector3 direction = new Vector3(0, 0, 0);
            if(playerCtrl.bFaceRight)
            {
                Rigidbody2D RockectInstance = Instantiate(rocket, transform.position, Quaternion.Euler(direction));
                RockectInstance.velocity = new Vector2(fSpeed, 0);
            }
            else
            {
                direction.z = 180;
                Rigidbody2D RockectInstance = Instantiate(rocket, transform.position, Quaternion.Euler(direction));
                RockectInstance.velocity = new Vector2(-fSpeed, 0);
            }
        }
    }
}
