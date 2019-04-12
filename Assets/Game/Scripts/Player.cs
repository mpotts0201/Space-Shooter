using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShot;

    [SerializeField]
    private float _fireRate = 0.25f;


    private float _nextFire = 0.0f;




    [SerializeField] 
    private float _speed = 5.0f;

    public bool canTripleShot = false;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, 0, 0);
	}


	
	// Update is called once per frame
	void Update () {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }





    }


    private void Shoot(){
        //if space is pressed, laser spawns


            if (Time.time > _nextFire)
            {

                if (canTripleShot == true)
                {
                    Instantiate(_tripleShot, transform.position, Quaternion.identity);

                }
                else {

                    Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                    
                    _nextFire = Time.time + _fireRate;
                }
            }


    }

    private void Movement(){
        // Look up these in docs 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        //If player on the y is > 0 
        //Set player pos to 0
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //same for x
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }




}

