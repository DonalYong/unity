using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawer : MonoBehaviour
{
    public GameObject[] pickupks;
    public float leftX;
    public float rightX;
    public float interavalTime = 5;
    public float highHealthThreshold = 75f;     
    public float lowHealthThreshold = 25f;
    
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnPickup());
    }
    public IEnumerator spawnPickup()
    {
        yield return new WaitForSeconds(interavalTime);

        float randomx = Random.Range(leftX, rightX);
        Vector3 randomPos = new Vector3(randomx, 10, 0);


        if (playerHealth.health >= highHealthThreshold)
        {
            Debug.Log("血量大于75，发装备");
            Instantiate(pickupks[0], randomPos, Quaternion.identity);

        }
        else if (playerHealth.health <= lowHealthThreshold)
        {
            Debug.Log("血量大于25，发血包");
            Instantiate(pickupks[1], randomPos, Quaternion.identity);
        }
        else
        {
            Debug.Log("随机发礼包");
            int pickupIndex = Random.Range(0, pickupks.Length);
            Instantiate(pickupks[pickupIndex], randomPos, Quaternion.identity);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
