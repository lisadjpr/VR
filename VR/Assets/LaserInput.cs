using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaserInput : MonoBehaviour
{
    public static GameObject currentObject;
    //Button buttonMoveUp;
    int currentID;
    public float default_lenght = 10.0f;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentObject = null;
        currentID = 0;
        Debug.Log("The game has started");

    }

    // Update is called once per frame
    void Update()
    {
        // Sends out a Raycast and returns on array filled with everything it hit
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, default_lenght);

        //Goes through all the hit objects and checks if any of them were our button
        for(int i =0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            //Use the object ID to determine if the run has already run fot this object
            int id = hit.collider.gameObject.GetInstanceID();

            // If not then run it again but if it's already run it's unneccessary to keep it running
            if(currentID != id)
            {
                currentID = id;
                currentObject = hit.collider.gameObject;

                // check based on the name
                string name = currentObject.name;

                if (name.Equals("move"))
                {
                    Debug.Log("Hit Move button");
                }

                // check based on the tag
                string tag = currentObject.tag;
                if (tag == "Button")
                {
                    Debug.Log("Hit the tag Button");
                    transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
                }
            }
        }
    }

    public void OnClickMoveUP()
    {
            Debug.Log("The player Move forward");
        transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;

    }
}
