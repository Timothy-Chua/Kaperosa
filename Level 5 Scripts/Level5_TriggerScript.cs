using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5_TriggerScript : MonoBehaviour
{
    [SerializeField] Transform kaperosaTransform;
    //[SerializeField] GameObject kaperosaObj;
    [SerializeField] GameObject claraObj;
    [SerializeField] GameObject kaperosaPassengerObj;

    [SerializeField] Transform spawn11;
    [SerializeField] Transform spawn12;
    [SerializeField] Transform spawn21;
    [SerializeField] Transform spawn22;
    [SerializeField] Transform spawn31;
    [SerializeField] Transform spawn32;

    int RandomSpawn;

    private void Start()
    {
        //kaperosaTransform = GameObject.Find("Kaperosa").transform;
        //kaperosaObj = GameObject.Find("Kaperosa");
        //claraObj = GameObject.Find("Clara Hermosa");
        //kaperosaPassengerObj = GameObject.Find("Clara Hermosa Inside");

        spawn11 = GameObject.Find("Spawn 1.1").transform;
        spawn12 = GameObject.Find("Spawn 1.2").transform;
        spawn21 = GameObject.Find("Spawn 2.1").transform;
        spawn22 = GameObject.Find("Spawn 2.2").transform;
        spawn31 = GameObject.Find("Spawn 3.1").transform;
        spawn32 = GameObject.Find("Spawn 3.2").transform;

        kaperosaPassengerObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider actor)
    {
        if (Level5_Manager.instance.currentObjective == Level5Objective.Pickup)
        {
            if (actor.CompareTag("Taxi") && gameObject.name == "Trigger1")
            {
                RandomSpawn = Random.Range(0, 2);

                Vector3 SpawnPos;

                if (RandomSpawn > 0)
                {
                    SpawnPos = spawn11.transform.position;
                }
                else
                {
                    SpawnPos = spawn12.transform.position;

                }
                kaperosaTransform.transform.position = SpawnPos;
            }
            else if (actor.CompareTag("Taxi") && gameObject.name == "Trigger2")
            {
                RandomSpawn = Random.Range(0, 2);

                Vector3 SpawnPos;

                if (RandomSpawn > 0)
                {
                    SpawnPos = spawn21.transform.position;
                }
                else
                {
                    SpawnPos = spawn22.transform.position;

                }
                kaperosaTransform.transform.position = SpawnPos;
            }
            else if (actor.CompareTag("Taxi") && gameObject.name == "Trigger3")
            {
                RandomSpawn = Random.Range(0, 2);

                Vector3 SpawnPos;

                if (RandomSpawn > 0)
                {
                    SpawnPos = spawn31.transform.position;
                }
                else
                {
                    SpawnPos = spawn32.transform.position;

                }
                kaperosaTransform.transform.position = SpawnPos;
            }
            else
            {
                //StartCoroutine(EnterPassenger());
            }
        }
    }

    public void Update()
    {
        if (Level5_Manager.instance.currentObjective != Level5Objective.Pickup)
        {
            kaperosaTransform.gameObject.SetActive(false);
        }
    }

    public void EnterPassengerCar()
    {
        claraObj.SetActive(false);
        kaperosaPassengerObj.SetActive(true);
        Level5_Manager.instance.currentObjective = Level5Objective.Hospital;
    }

    public void ExitPassengerCar()
    {
        claraObj.SetActive(false);
        kaperosaPassengerObj.SetActive(false);
        Level5_Manager.instance.currentObjective = Level5Objective.Home;
    }

    /*
    IEnumerator EnterPassenger()
    {
        kaperosaObj.SetActive(false);
        VehicleController.instance.vehicleState = VehicleController.VehicleState.Park;
        yield return new WaitForSeconds(2);
        VehicleController.instance.vehicleState = VehicleController.VehicleState.BaleteDrive;
        claraObj.SetActive(false);
        kaperosaPassengerObj.SetActive(true);
        gameObject.SetActive(false);
    }
    */
}

