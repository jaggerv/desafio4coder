using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public GameObject ammo;
    public bool canShoot = true;
    public float bulletCooldown = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            Shoot();
        }
    }

    void Shoot(){ // Método Disparo
        if (canShoot)
        {
            canShoot = false;
            Instantiate(ammo, transform.position, transform.rotation);
            Invoke("ShootCd", bulletCooldown); // Enfriamiento del disparo
            
        }
    }

    void ShootCd() // Reinicia el booleano para poder disparar de nuevo
    {
        canShoot = true;
    }

}
