using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;

    private float vInput;
    private float hInput;
    public float distanceToGround = 0.8f;

    private Rigidbody _rb;
    public LayerMask groundLayer;

    private CapsuleCollider _col;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _col = GetComponent<CapsuleCollider> ();

    }
    

    // Update is called once per frame
    void Update()
    {
        //3
        this.vInput = Input.GetAxis("Vertical") * moveSpeed;
        //4
        this.hInput = Input.GetAxis("Horizontal") * rotateSpeed;
     //  //5
     //  this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
     //  //6
     //  this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        
    }
    void FixedUpdate() 
    {
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        Vector3 rotation = Vector3.up * hInput;

        Quaternion angelRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angelRot);
    }
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,  _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, 
            capsuleBottom, 
            distanceToGround,
           // groundLayer,
           // QueryTriggerInteraction.Ignore);
        //Debug.Log($"текущее расстояние от пола до центра {capsuleBottom.y}");
        Debug.Log($"расстояние START: {capsuleBottom}" +
            $" - расстояние END: {_col.bounds.center}" +
            $" - RADIUS - {distanceToGround}" +
          //  $" - LAYERMASK - {groundLayer}" +
           // $" - queryTriggerInteraction - {QueryTriggerInteraction.Ignore}" +
            $" в ИТОГЕ -- {grounded}");
       // Debug.Log($"grounded -- {grounded}");
        return grounded;

    }
}
