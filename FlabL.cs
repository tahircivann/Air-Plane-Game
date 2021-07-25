using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlabL : MonoBehaviour
{
    public float speed = 90.0f;  // Start is called before the first frame update
    float Rotatright;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // var x = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //var y = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;// Degrees per second;

        {


            if (Input.GetKey(KeyCode.A) || Rotatright < 0)
            {
                // transform.Rotate(x, y, 0, Space.World); // World rotation;
                transform.Rotate(5f, 0, 0);
                transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x, -45, 45), 16.253f, -5.907f);
            }
            else
            {
                if (transform.localRotation.x > 0)
                {
                    transform.Rotate(-5f, 0, 0);
                }



            }

           
        }
    }
}






            


        

