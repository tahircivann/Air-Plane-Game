using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript_2 : MonoBehaviour
{
    [SerializeField]
    float currentAmount = 0f;
    float maxAmount = 5f;
    [SerializeField]
    private GameObject _LaserPrefab;
    //private float _speed = 3.5f;
    // public float horizontalInput;
    Bounds b;

    public float lifeDuration = 10f;
    private float lifeTimer;
    public float speed = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0, 0, 0);
        lifeTimer = lifeDuration;

        Debug.Log("plane plot added to:" + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 moveCamTo = transform.position - transform.forward * 15.0f + transform.up * 15.0f;

        float bias = 0.96f;
        b = new Bounds(new Vector3(507, 195, 987), new Vector3(996, 361, 23));
        // Camera.main.transform.position = Camera.main.transform.position * bias +
        // moveCamTo * (1.0f - bias);
        // Camera.main.transform.LookAt(transform.position + transform.forward * 50.0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Laser = (GameObject)Instantiate(_LaserPrefab, transform.position + new Vector3(-2, 0, 0), Quaternion.identity);

            Laser.GetComponent<Laser>().travelDirection = transform.forward;
            lifeTimer -= Time.deltaTime;
            if (lifeTimer <= 0f)
            {
                Destroy(gameObject);

            }
        }

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



        //// Slow Motion
        //    if (Input.GetKeyDown(KeyCode.Space))
        //  {
        //
        //    if (Time.timeScale == 1.0f)
        //      Time.timeScale = 0.3f;
        //
        //else

        //  Time.timeScale = 1.0f;
        // Time.fixedDeltaTime = 0.02f * Time.timeScale;
        //}
        //if (Time.timeScale == 0.03f)
        //{

        //      currentAmount += Time.deltaTime;
        //  }

        //  if (currentAmount > maxAmount)
        //  {

        //    currentAmount = 0f;
        //    Time.timeScale = 1.0f;

        //  }
        ////
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        // Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
        //transform.Translate(new Vector3 (horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);
        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);
        if (terrainHeightWhereWeAre >= transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeightWhereWeAre, transform.position.z);

        }
        if (terrainHeightWhereWeAre > transform.position.x)
        {
            transform.position = new Vector3(terrainHeightWhereWeAre, transform.position.y, transform.position.z);
        }
        if (terrainHeightWhereWeAre > transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, terrainHeightWhereWeAre);

        }

        // make Vector3 with global coordinates xVal and zVal (Y doesn't matter):
        Vector3 signPosition = new Vector3(transform.position.x,transform.position.y,0);
        // set the Y coordinate according to terrain Y at that point:
        signPosition.z= Terrain.activeTerrain.SampleHeight(signPosition) + Terrain.activeTerrain.GetPosition().z;
        // you probably want to create the object a little above the terrain:
        signPosition.z += 0.5f; // move position 0.5 above the terrain
        GameObject sign = Instantiate(Resources.Load("prefabs/StopSign"), signPosition, Quaternion.identity) as GameObject;


    }
}
