using UnityEngine;

public class Pickup : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }
}
