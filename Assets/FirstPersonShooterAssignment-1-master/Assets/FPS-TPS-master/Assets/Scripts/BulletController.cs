using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody rbbullet;
    public float lifeTime;
    public GameObject effects;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rbbullet.velocity = transform.forward * bulletSpeed;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            StartCoroutine(nameof(Bulletadd));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(nameof(Bulletadd));
        Instantiate(effects, transform.position, transform.rotation);
    }
    IEnumerator Bulletadd()
    {
        yield return new WaitForSeconds(2);
        //("Missed the ball");
        //(rbbullet.gameObject.name);

        if (rbbullet.gameObject.name == "PlayerBullet")
        {
            PlayerController.bulletInstance.addBullet(rbbullet.gameObject);
            //(rbbullet.gameObject.name);
            //print("Added cannon ball to player");
        }
    }

}
