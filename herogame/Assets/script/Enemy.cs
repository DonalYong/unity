using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed =3.0f;
    public Sprite damageEnemy;
    public Sprite deadEnemy;
    public int HP = 2;
    public float minSpinForce = -200;
    public float maxSpinForce = 200;
    public GameObject UI_100Points;

    private Rigidbody2D enemyBoby;
    private Transform frontCheck;
    private bool isDead = false;
    private SpriteRenderer curBody;


    private void Awake()
    {
        enemyBoby = GetComponent<Rigidbody2D>();
        frontCheck = transform.Find("frontCheck");
        curBody = transform.Find("body").GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    private void FixedUpdate()
    {
        enemyBoby.velocity = new Vector2(transform.localScale.x * moveSpeed, enemyBoby.velocity.y);
        Collider2D[] colliders = Physics2D.OverlapPointAll(frontCheck.position);
        foreach(Collider2D c in colliders)
        {
            if(c.tag=="wall")
            {
                flip();
                break;
            }
        }
        if(HP==1&&damageEnemy!=null)
        {
            curBody.sprite = damageEnemy;
        }
        if(HP<=0&&!isDead)
        {
            death();
            isDead = true;

        }
    }
    public void Hurt()
    {
        HP--;
    }
    void death()
    {
        isDead = true;
        curBody.sprite = deadEnemy;
        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
            c.isTrigger = true;
        //给一个随机旋转扭矩
        enemyBoby.AddTorque(Random.Range(minSpinForce, maxSpinForce));
        Vector3 UI100Pos = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        Instantiate(UI_100Points, UI100Pos, Quaternion.identity);
        Debug.Log(Quaternion.identity);
    }

    void flip()
    {
        Vector3 enemyScale = transform.localScale;//获取敌人转身
        enemyScale.x *= -1;//转身
        transform.localScale = enemyScale;
        Debug.Log("完成转身");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
