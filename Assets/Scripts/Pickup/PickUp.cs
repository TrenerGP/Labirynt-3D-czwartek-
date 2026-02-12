using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50f, 0);
    public float amplitude = 0.001f;
    public float frequency = 2f;

    public virtual void Picked()
    {
        Debug.Log("Zebrany");
        Destroy(gameObject);
    }

    public void Animation()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
        float newY = transform.position.y + Mathf.Sin(Time.time * frequency) * amplitude;
        if (Time.timeScale>0) 
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void Update()
    {
        Animation();
    }
}
