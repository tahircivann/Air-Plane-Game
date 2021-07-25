using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camchanger : MonoBehaviour
{
    public GameObject firstcam;
    public GameObject thirdcam;
    public int Cammode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
           if (Cammode == 1)
            {
                Cammode = 0;
            }
           else
            {
                Cammode += 1;
            }
          StartCoroutine(cam());

    
        
        }
        IEnumerator cam()
        {
            yield return new WaitForSeconds(0.01f);
            if (Cammode == 0)
            {
                firstcam.SetActive(true);
                thirdcam.SetActive(false);
            }
            if (Cammode == 1)
            {
                firstcam.SetActive(false);
                thirdcam.SetActive(true);
            }


        }

    }



}
