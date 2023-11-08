using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float flySpeed = 3.0f;

    void Update()
    {
        // Movimento horizontal e vertical
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Voo
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.down * flySpeed * Time.deltaTime);
        }
    }
}
