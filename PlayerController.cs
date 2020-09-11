using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float verticalInput;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6;
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        if (movement != Vector3.zero) {
          transform.rotation =Quaternion.LookRotation(movement);
        }

        transform.Translate (movement * speed * Time.deltaTime, Space.World);

    }
}
