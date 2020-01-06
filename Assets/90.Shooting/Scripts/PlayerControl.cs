using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //player speed value
    public float Speed = 15.0f;
    // player gameObject transform component
    private Transform myTransform = null;

    public GameObject BulletPrefab = null;
    
    // Start is called before the first frame update
    void Start()
    {
        //transform component caching
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //move
        float axis = Input.GetAxis("Horizontal");
        //Debug.Log("axis: " + axis);
        Vector3 moveAmount = axis * Speed * -Vector3.right * Time.deltaTime;
        
        myTransform.Translate(moveAmount);
        
        //shooting
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Instantiate(BulletPrefab, myTransform.position, Quaternion.identity);
        }
    }
}
