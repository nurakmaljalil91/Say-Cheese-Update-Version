using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFade : MonoBehaviour
{

    private GameObject player;
    public Camera camera;
   
    private GameObject[] prop;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 direction = player.transform.position - camera.transform.position;

        if(Physics.Raycast(camera.transform.position, direction, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag.Equals("Prop"))
            {
                hit.transform.GetComponent<MakeFade>().isFade = true;
            }
          
            
        }

       
    }
}
