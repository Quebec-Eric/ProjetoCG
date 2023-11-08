using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCameraController : MonoBehaviour
{
    public float speed = 3.0f;
    public float flySpeed = 5.0f;
    public float rotationSpeed = 60.0f;

    private bool isFlying = false;
    private bool spacePressedOnce = false;

    void Update()
    {
        // Movimentação básica
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Se estiver voando, adicione movimento no eixo Y
        if (isFlying)
        {
            moveDirection.y = 1;  // Move para cima
        }

        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Rotação
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Verifica se a tecla Espaço foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (spacePressedOnce)
            {
                ToggleFlying();
                spacePressedOnce = false;
            }
            else
            {
                spacePressedOnce = true;
                Invoke("ResetSpacePress", 0.5f);
            }

            // Dentro do método Update
            if (isFlying)
            {
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    moveDirection.y = -1;  // Move para baixo
                }
                else
                {
                    moveDirection.y = 1;   // Move para cima
                }
            }


        }
    }

    void ToggleFlying()
    {
        isFlying = !isFlying;

        // Se começar a voar, remova a gravidade do personagem.
        if (isFlying)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.up * flySpeed;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void ResetSpacePress()
    {
        spacePressedOnce = false;
    }
}