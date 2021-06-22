using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float  hurtBloodpPiont=20f;
    public float damageRepeat = 0.5f;
    public float hurtForce =100f;
    public AudioClip[] ouchClips;

    SpriteRenderer healthBar;
    Vector3 healthBarScale;
    private float lastHurt;
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        healthBarScale = healthBar.transform.localScale;
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            if(Time.time >lastHurt+damageRepeat)
            {
                if (health > 0)
                {
                    //减血
                    TakeDamage(collision.gameObject.transform);
                    lastHurt = Time.time;
                    if (health <= 0)
                    {
                        //播放死亡动画
                        anim.SetTrigger("Die");
                        //掉到河里
                        Collider2D[] colliders = GetComponents<Collider2D>();
                        foreach (Collider2D c in colliders)
                            c.isTrigger = true;
                        /*
                        Collider2D c;
                        for (int i = 0,i < colliders.Length; i++)
                        { c = colliders[i];
                            c.isTrigger = true;
                        }*/
                        SpriteRenderer[] sp = GetComponentsInChildren<SpriteRenderer>();
                        foreach (SpriteRenderer s in sp)
                            s.sortingLayerName = "UI";
                        GetComponent<Playercontrol>().enabled = false;
                        GetComponentInChildren<Gun>().enabled = false;
                        
                    }

                }
            }
            
        }
    }
    void TakeDamage( Transform enemy)
    {
        health -= hurtBloodpPiont;
        //更新血条状态
        UpdateHealthBar();
        Vector3 hurtVector = transform.position - enemy.position+Vector3.up;
        GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);
        int i = Random.Range(0, ouchClips.Length);
        AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
    }
     public void UpdateHealthBar()
    {
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthBar.transform.localScale = new Vector3(health * 0.01f, 1, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
