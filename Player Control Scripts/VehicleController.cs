using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public static VehicleController instance;
    private Rigidbody rb;
    private Transform taxiTransform;
    public bool isMoving;

    [Header("Audio")]
    public AudioSource audioEngine;
    public AudioClip clipMoving;
    public AudioClip clipStandby;
    private bool isClipChangeMove;
    private bool isClipChangeStandby;

    [SerializeField] private float speedForward;
    public float speedHorizontal = 25f;

    public VehicleState vehicleState;

    public enum VehicleState
    {
        EleventhStreet,
        DonaHermosa,
        NinethStreet,
        BaleteDrive, 
        Park
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        taxiTransform = GetComponent<Transform>();
    }

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        isMoving = false;
        isClipChangeMove = false;
        isClipChangeStandby = true;
    }

    private void Update()
    {
        if  (GameManager.instance.gameState == GameState.Gameplay)
        {
            LimitSpeed();
            //taxiTransform.position = new Vector3(taxiTransform.position.x, -25.04299f, taxiTransform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.gameState == GameState.Gameplay)
        {
            if (Input.GetKey(KeyCode.W))
            {
                isMoving = true;

                if (isClipChangeMove)
                {
                    audioEngine.clip = clipMoving;
                    audioEngine.Play();
                    isClipChangeStandby = true;
                    isClipChangeMove = false;
                }
            }
            else
            {
                isMoving = false;

                if (isClipChangeStandby)
                {
                    audioEngine.clip = clipStandby;
                    audioEngine.Play();
                    isClipChangeStandby = false;
                    isClipChangeMove = true;
                }
            }
                

            if (vehicleState == VehicleState.EleventhStreet)
            {
                taxiTransform.rotation = Quaternion.Euler(0, 90f, 0);

                if (Input.GetKey(KeyCode.W))
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z + speedForward);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rb.velocity = new Vector3(rb.velocity.x - speedHorizontal, 0, rb.velocity.z);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rb.velocity = Vector3.zero;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rb.velocity = new Vector3(rb.velocity.x + speedHorizontal, 0, rb.velocity.z);
                }
            }
            else if (vehicleState == VehicleState.DonaHermosa)
            {
                taxiTransform.rotation = Quaternion.Euler(0, 0, 0);

                if (Input.GetKey(KeyCode.W))
                {
                    rb.velocity = new Vector3(rb.velocity.x - speedForward, rb.velocity.y, rb.velocity.z);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z - speedHorizontal);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rb.velocity = Vector3.zero;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + speedHorizontal);
                }
            }
            else if (vehicleState == VehicleState.NinethStreet)
            {
                taxiTransform.rotation = Quaternion.Euler(0, -90f, 0);

                if (Input.GetKey(KeyCode.W))
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z - speedForward);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rb.velocity = new Vector3(rb.velocity.x + speedHorizontal, rb.velocity.y, rb.velocity.z);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rb.velocity = Vector3.zero;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rb.velocity = new Vector3(rb.velocity.x - speedHorizontal, rb.velocity.y, rb.velocity.z);
                }
            }
            else if (vehicleState == VehicleState.BaleteDrive)
            {
                taxiTransform.rotation = Quaternion.Euler(0, -180f, 0);

                if (Input.GetKey(KeyCode.W))
                {
                    rb.velocity = new Vector3(rb.velocity.x + speedForward, rb.velocity.y, rb.velocity.z);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + speedHorizontal);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rb.velocity = Vector3.zero;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z - speedHorizontal);
                }
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }       
    }

    private void LimitSpeed()
    {
        switch (vehicleState)
        {
            case VehicleState.BaleteDrive:
                /*
                 * W = x
                 * A = z
                 * D = -z
                 * */

                if (rb.velocity.x > speedForward)
                    rb.velocity = new Vector3(speedForward, rb.velocity.y, rb.velocity.z);
                if (rb.velocity.z > speedHorizontal)
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speedHorizontal);
                if (rb.velocity.z < -speedHorizontal)
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speedHorizontal);

                break;
            case VehicleState.EleventhStreet:
                /*
                 * W = z
                 * A = -x
                 * D = x
                 * */

                if (rb.velocity.z > speedForward)
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speedForward);
                if (rb.velocity.x > speedHorizontal)
                    rb.velocity = new Vector3(speedHorizontal, rb.velocity.y, rb.velocity.z);
                if (rb.velocity.x < -speedHorizontal)
                    rb.velocity = new Vector3(-speedHorizontal, rb.velocity.y, rb.velocity.z);

                break;
            case VehicleState.DonaHermosa:
                /*
                 * W = -x
                 * A = -z
                 * D = z
                 * */

                if (rb.velocity.x < -speedForward)
                    rb.velocity = new Vector3(-speedForward, rb.velocity.y, rb.velocity.z);
                if (rb.velocity.z > speedHorizontal)
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speedHorizontal);
                if (rb.velocity.z < -speedHorizontal)
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speedHorizontal);

                break;
            case VehicleState.NinethStreet:
                /*
                 * W = -z
                 * A = x
                 * D = -x
                 * */

                if (rb.velocity.z < speedForward)
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speedForward);
                if (rb.velocity.x > speedHorizontal)
                    rb.velocity = new Vector3(speedHorizontal, rb.velocity.y, rb.velocity.z);
                if (rb.velocity.x < -speedHorizontal)
                    rb.velocity = new Vector3(-speedHorizontal, rb.velocity.y, rb.velocity.z);

                break;
        }

        rb.velocity = new Vector3(rb.velocity.x, -0.3f, rb.velocity.z);
    }
}
