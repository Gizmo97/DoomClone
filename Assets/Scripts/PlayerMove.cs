using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Rigidbody rbody;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpPower = 10f;
    [SerializeField] private Vector3 moveVector;
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
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //store input
        moveVector = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
        isRunning = Input.GetKey(KeyCode.LeftShift);

        //WALKING
        if (moveVector != Vector3.zero && isRunning == false)
        {
            transform.Translate(moveVector * walkSpeed * Time.deltaTime);
        }
        //RUNNING
        else if (moveVector != Vector3.zero && isRunning == true)
        {
            transform.Translate(moveVector * runSpeed * Time.deltaTime);
        }
        //JUMPING
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbody.AddForce(transform.up * jumpPower);
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
