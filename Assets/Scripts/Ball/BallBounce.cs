using UnityEngine;

public class BallBounce : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _velocity = _rb.velocity;
        
    }
    void FixedUpdate()
{
    _velocity = _rb.velocity;
    float maxSpeed = 1000f; // Maksimum hız sınırı
    if (_velocity.magnitude > maxSpeed)
    {
        _rb.velocity = _velocity.normalized * maxSpeed;
    }
}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = _velocity.magnitude;
        var direction = Vector3.Reflect(_velocity.normalized, collision.contacts[0].normal);
        
        // İsteğe bağlı: Yansıma açısını düzenle
        direction = AdjustReflectionAngle(direction, collision.contacts[0].normal);
        
        _rb.velocity = direction * Mathf.Max(speed, 0f);
    }

    Vector2 AdjustReflectionAngle(Vector2 direction, Vector2 normal)
    {
        // Yansıma açısını düzenleme kodu buraya
        // Örneğin, belirli durumlara göre yansıma vektörünü ayarlayabilirsiniz
        return direction;
    }

}
