using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 1f;
    public float bulletLifeTime = 5f;
    private float lifeTimeLeft;
    public bool canScale = true;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    void ResetTimer()
    {
        lifeTimeLeft = bulletLifeTime;
    }

    void BulletTimer()
    {
        lifeTimeLeft -= Time.deltaTime;
        if (lifeTimeLeft <= 0)
        {
            Destroy(gameObject);
            ResetTimer();
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ScaleBullet();
        }
        BulletTimer();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void ScaleBullet()
    {
        if(canScale)
        {
            canScale = false;
            transform.localScale *= 2;
            Invoke("ScaleCd", 2f);
        }
    }

    void ScaleCd()
    {
        canScale = true;
    }    

}