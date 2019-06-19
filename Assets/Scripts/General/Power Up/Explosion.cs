using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //private GameObject bomb; // get the position of explosion
    public float power = 0.1f; // power of the explosion
    public float radius = 4.0f; // radius of the explosion
    public float upForce = 0.0f; // 
    private GameObject player;
    public GameObject exposionEffect;

    //public GameObject cheesePrefab;

    //private GameObject cheese;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //bomb = GameObject.FindGameObjectWithTag("Bomb");
    }

    private void FixedUpdate()
    {
        if(this.gameObject.activeSelf)
        {
            Invoke("Detonate", 8);
        }
    }

    void Detonate()
    {
        Vector3 explosionPosition = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        Instantiate(exposionEffect, explosionPosition, Quaternion.identity);
        foreach(Collider hit in colliders)
        {
            if(hit.tag.Equals("Player")){

                if(!hit.GetComponent<PlayerPowerUp>().shieldIsUp){
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    if(rb){
                        rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                    }
                    hit.GetComponent<PlayerController>().CheeseLose(explosionPosition);
                    
                }
            }
            if (hit.tag.Equals("Enemy 1"))
            {

                if (!hit.GetComponent<EnemyPowerUp>().shieldIsUp)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    if (rb)
                    {
                        rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                    }
                    //hit.GetComponent<EnemyMovement>().CheeseLose(explosionPosition);

                }
            }
            if (hit.tag.Equals("Enemy 2"))
            {

                if (!hit.GetComponent<EnemyPowerUp>().shieldIsUp)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    if (rb)
                    {
                        rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                    }
                   // hit.GetComponent<EnemyMovement>().CheeseLose(explosionPosition);

                }
            }
            if (hit.tag.Equals("Enemy 3"))
            {

                if (!hit.GetComponent<EnemyPowerUp>().shieldIsUp)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    if (rb)
                    {
                        rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                    }
                    //hit.GetComponent<EnemyMovement>().CheeseLose(explosionPosition);

                }
            }


        }

        Destroy(this.gameObject);
    }
}
