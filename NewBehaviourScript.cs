using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    [SerializeField]
    float currentAmount = 0f;
    float maxAmount = 5f;

    //private float _speed = 3.5f;
    // public float horizontalInput;

    public float speed = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0, 0, 0);
        Debug.Log("plane plot added to:" + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveCamTo = transform.position - transform.forward * 15.0f + transform.up * 15.0f;

        float bias = 0.96f;

        Camera.main.transform.position = Camera.main.transform.position * bias +
                                            moveCamTo * (1.0f - bias);
        Camera.main.transform.LookAt(transform.position + transform.forward * 50.0f);



        transform.position += transform.forward * Time.deltaTime / 2 * speed;
        speed -= transform.forward.y * Time.deltaTime * 90.0f;



        if (speed < 50.0f)
        {
            speed = 50.0f;
        }
        if (speed > 150.0f)
        {
            speed = 150.0f;
        }




        if (Input.GetKeyDown(KeyCode.F))
        {

            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.3f;

            else

                Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        if (Time.timeScale == 0.03f)
        {

            currentAmount += Time.deltaTime;
        }

        if (currentAmount > maxAmount)
        {

            currentAmount = 0f;
            Time.timeScale = 1.0f;


        }
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        // Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
        //transform.Translate(new Vector3 (horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);

        //Harita sýnýrlarý

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);
        if (terrainHeightWhereWeAre >= transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeightWhereWeAre, transform.position.z);

        }
        if (terrainHeightWhereWeAre >= transform.position.x)
        {
            transform.position = new Vector3(terrainHeightWhereWeAre, transform.position.y, transform.position.z);
        }
       // else if (terrainHeightWhereWeAre <= transform.position.x)
           // transform.position = new Vector3(terrainHeightWhereWeAre, transform.position.y, transform.position.z);

       if (terrainHeightWhereWeAre >= transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, terrainHeightWhereWeAre);
        }
       //else  if (terrainHeightWhereWeAre <= transform.position.z)
           // transform.position = new Vector3(transform.position.x, transform.position.y, terrainHeightWhereWeAre);
    }
       //Harita sýnýrlar
      
    
}
