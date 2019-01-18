using System.Collections;
using UnityEngine;

public class ColliderDemo : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // If only worrying about a single collision
        //Vector3 point = collision.contacts[0].point;

        foreach (var contact in collision.contacts)
        {
            PlaceRedSphereAtPoint(contact.point);
        }
    }

    void PlaceRedSphereAtPoint(Vector3 point)
    {
        Transform sphereTransform = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        sphereTransform.position = point;
        sphereTransform.localScale = Vector3.one * 0.1f;
        sphereTransform.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FlashColor(other));
    }

    IEnumerator FlashColor(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        other.GetComponent<Renderer>().material.color = Color.yellow;

        yield return new WaitForSeconds(0.5f);

        GetComponent<Renderer>().material.color = Color.white;
        other.GetComponent<Renderer>().material.color = Color.white;
    }
}
