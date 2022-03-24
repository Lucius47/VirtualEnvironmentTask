/// Written by Reddit user: https://www.reddit.com/user/Shar3D/

using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    public float visualSpeedScalar;

    private Vector3 direction;
    private float currentScroll;

    private void Update()
    {
        // Scroll texture to fake it moving
        currentScroll = currentScroll + Time.deltaTime * speed * visualSpeedScalar;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, currentScroll);
    }

    // Anything that is touching will move
    // This function repeats as long as the object is touching
    private void OnCollisionStay(Collision collision)
    {
        // * Remember Vector3's can used for position AND direction AND rotation
        direction = transform.forward;
        direction *= speed;

        // Add a WORLD force to the other objects
        // Ignore the mass of the other objects so they all go the same speed (ForceMode.Acceleration)
        collision.rigidbody.AddForce(direction, ForceMode.Acceleration);
    }
}