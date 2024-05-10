using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PickUpScript : MonoBehaviour
{
    private static PickUpScript instance = null;

    // Object Variables
    public float distance;
    public float throwForce = 600;
    private Vector3 objectPosition;

    public bool canHold;
    public GameObject holdObject;
    public bool isHolding;
    public bool beenThrown;

    // UI Variables
    public GameObject pickUpUI;
    public GameObject canThrowUI;
    void Start()
    {
        canHold = true;
        isHolding = false;
        beenThrown = false;
    }

    void Update()
    {
        // Caculating the distance between the pickable item and the hold position of the player
        distance = Vector3.Distance(transform.position, holdObject.transform.position);

        // Item can not be pick up if the player is greater than 5 metres
        if (distance > 5f)
        {
            isHolding = false;
            pickUpUI.SetActive(false);
        }
        else if (distance <= 5f)  // Item can be pick up if the player is 5 metres close or less
        {
            Debug.Log("Click Left Mouse Button to Pick Up");
            pickUpUI.SetActive(true);
        }

        if (isHolding == true)
        {
            // If the item is being held, the velcoity and angular velecity will be set to zero
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.SetParent(holdObject.transform); // The item will become a parent object of the hold position

            Debug.Log("Press E to Throw");
            canThrowUI.SetActive(true);
            pickUpUI.SetActive(false);

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Pressing the Keyboard E will allow the player to throw the item
                GetComponent <Rigidbody>().AddForce(holdObject.transform.forward * throwForce);
                isHolding = false;
                beenThrown = true;
            }

        }
        else if (isHolding == false) 
        {
            // The item will not be attached if the player is not holding the item anymore
            objectPosition = transform.position;
            transform.SetParent(null);
            GetComponent<Rigidbody>().useGravity = true;
            transform.position = objectPosition;
            canThrowUI.SetActive(false);

        }
    }

    private void OnMouseDown()
    {
        // The item will be held if the player clicks the left mouse button but if only the player is 5 metres or less away from the item
        if (distance <= 5f)
        {
            isHolding = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().detectCollisions = true;
        }
    }
    private void OnMouseUp()
    {
        // The item will not be held if the player lets go the left mouse button (without pressing the E button)
        isHolding = false;
    }

    void Awake()
    {
        instance = this;
    }

    public static PickUpScript Instance
    {
        get
        {
            return instance;
        }
    }

}
