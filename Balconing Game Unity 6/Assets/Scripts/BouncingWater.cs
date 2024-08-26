using UnityEngine;

public class BouncingWater : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private int _velocityWater;

    private void Awake() 
    {
        _rigidBody = GetComponent<Rigidbody>();    
    }

    private void Start() 
    {
        MoveWater();
    }

    private void MoveWater()
    {
        float positionY = 0.2f;
        transform.position = new Vector3 (0f, positionY, 0f);
        _velocityWater = 10;
        Vector3 direction;
        float x = Random.Range(-2.0f, 2.0f);
        direction = new Vector3(1, positionY, x).normalized;
        _rigidBody.linearVelocity =  direction * _velocityWater;
    }
}
