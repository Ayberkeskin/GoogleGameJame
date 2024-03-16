using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(20*Time.deltaTime*speed, 20*Time.deltaTime*speed));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
