using System.Collections;
using UnityEngine;

public class Moveing : MonoBehaviour
{   
    // This only works for 2d games with Unity

    //Variables
    public Rigidbody2D _rigidbody;
    public float MoveSpeed = 1;
    public float JumpForce = 1;

    public Gun ProjectilePrefab;
    public Transform LaunchOffset;

    
    private void Start()
    {

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        // Movement
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MoveSpeed;
        //Cool Move thing
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;


        //Jumping
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {

            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

        }

        if(Input.GetButtonDown("Fire1"))
        {

            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);

        }
    }
}
