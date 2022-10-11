using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    RaycastHit hit;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(10, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(10, 0, 0) * Time.deltaTime;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            Debug.Log(hit.transform.name);
        }
    }
}
