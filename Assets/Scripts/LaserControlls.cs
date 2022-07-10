using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControlls : MonoBehaviour
{
    public int laserSpeed = 6;  
    
    void laserAtack()
    {
        transform.Translate(Vector3.up* laserSpeed * Time.deltaTime);
    }

    void DestroyMyLiser()
    {
        if (transform.position.y >= 16)
        {
            Destroy(this.gameObject, 0.5f);
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        laserAtack();
        DestroyMyLiser();
    }
}