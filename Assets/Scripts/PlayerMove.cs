using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Rigidbody rbody;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private Vector3 moveVector;
    [SerializeField] private Vector2 turnVector;
    [SerializeField] private float turnXSpeed = 2f;
    [SerializeField] private float turnYSpeed = 2f;
    [SerializeField] private float tempYrot;
    [SerializeField] private float tempXrot;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool isGrounded;

    [SerializeField] private PlayerStats playerStats;

    //GROUND CHECK
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground") 
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground") 
        {
            isGrounded = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //store input
        moveVector = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")).normalized;
        turnVector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        isRunning = Input.GetKey(KeyCode.LeftShift);

        //TURNING
        tempXrot += turnVector.x * turnXSpeed;
        tempYrot += -turnVector.y * turnYSpeed;
        tempYrot = Mathf.Clamp(tempYrot, -45, 45);
        transform.localRotation = Quaternion.Euler(tempYrot, tempXrot, 0);
        
        //WALKING
        if (moveVector != Vector3.zero && isRunning == false)
        {
            transform.Translate(moveVector * walkSpeed * Time.deltaTime);
        }
        //RUNNING
        else if (moveVector != Vector3.zero && isRunning == true)
        {
            transform.Translate(moveVector * runSpeed * Time.deltaTime);
            playerStats.UpdateStamina(-0.02f);
        }
        //JUMPING
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            playerStats.UpdateStamina(-20f);
        }

        //DEATH
        if (playerStats.curHealth <= 0)
        {
            //RESPAWN
            //change this to a variable for a respawn pos
            transform.position = Vector3.zero;
            //update the health and armour again
            playerStats.UpdateHealth(playerStats.maxHealth);
            playerStats.UpdateArmour(playerStats.maxArmour);
        }
    }
}
