using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] Transform taxiTransform;
    [SerializeField] GameObject playerObj;
    [SerializeField] Camera taxiCamera;

    [SerializeField] GameObject passengersInside;
    [SerializeField] GameObject passengersOutside;
    [SerializeField] GameObject passengersArrive;

    [SerializeField] Transform goingDonaTransform;
    [SerializeField] Transform going9thTransform;
    [SerializeField] Transform goingBaleteTransform;
    [SerializeField] Transform going11thTransform;

    private void OnTriggerEnter(Collider actor)
    {
        if (GameManager.instance.gameState == GameState.Gameplay)
        {
            if (actor.CompareTag("Taxi") && gameObject.name == "PassengerEnter")
            {
                StartCoroutine(PassengerEnter());
            }
            else if (actor.CompareTag("Taxi") && gameObject.name == "Going9th")
            {
                StartCoroutine(Going9th());
            }
            else if (actor.CompareTag("Taxi") && gameObject.name == "GoingBalete")
            {
                StartCoroutine(GoingBalete());
            }
            else if (actor.CompareTag("Taxi") && gameObject.name == "Going11th")
            {
                StartCoroutine(Going11th());
            }
            else if (actor.CompareTag("Taxi") && gameObject.name == "GoingDona")
            {
                StartCoroutine(GoingDona());
            }
            else if (actor.CompareTag("Taxi") && gameObject.name == "PassengerExit")
            {
                StartCoroutine(PassengerExit());
            }
            else if (actor.CompareTag("Taxi") && gameObject.name == "Home")
            {
                StartCoroutine(HomeSweetHome());
            }
        }
    }

    IEnumerator PassengerEnter()
    {
        VehicleController.instance.vehicleState = VehicleController.VehicleState.Park;
        yield return new WaitForSeconds(3);
        VehicleController.instance.vehicleState = VehicleController.VehicleState.DonaHermosa;
        passengersInside.SetActive(true);
        passengersOutside.SetActive(false);
    }

    IEnumerator PassengerExit()
    {
        VehicleController.instance.vehicleState = VehicleController.VehicleState.Park;
        yield return new WaitForSeconds(3);
        VehicleController.instance.vehicleState = VehicleController.VehicleState.BaleteDrive;
        passengersArrive.SetActive(true);
        passengersInside.SetActive(false);
    }

    IEnumerator Going9th()
    {
        VehicleController.instance.vehicleState = VehicleController.VehicleState.Park;
        yield return new WaitForSeconds(1);
        Vector3 targetPos = going9thTransform.position;
        taxiTransform.position = new Vector3(targetPos.x, taxiTransform.position.y, targetPos.z);
        VehicleController.instance.vehicleState = VehicleController.VehicleState.NinethStreet;
    }

    IEnumerator GoingBalete() 
    {
        VehicleController.instance.vehicleState = VehicleController.VehicleState.Park;
        yield return new WaitForSeconds(1);
        Vector3 targetPos = goingBaleteTransform.position;
        taxiTransform.position = new Vector3(targetPos.x, taxiTransform.position.y, targetPos.z);
        VehicleController.instance.vehicleState = VehicleController.VehicleState.BaleteDrive;
    }

    IEnumerator Going11th()
    {
        VehicleController.instance.vehicleState = VehicleController.VehicleState.Park;
        yield return new WaitForSeconds(1);
        Vector3 targetPos = going11thTransform.position;
        taxiTransform.position = new Vector3(targetPos.x, taxiTransform.position.y, targetPos.z);
        VehicleController.instance.vehicleState = VehicleController.VehicleState.EleventhStreet;
    }

    IEnumerator GoingDona()
    {
        VehicleController.instance.vehicleState = VehicleController.VehicleState.Park;
        yield return new WaitForSeconds(1);
        Vector3 targetPos = goingDonaTransform.position;
        taxiTransform.position = new Vector3(targetPos.x, taxiTransform.position.y, targetPos.z);
        VehicleController.instance.vehicleState = VehicleController.VehicleState.DonaHermosa;
    }

    IEnumerator HomeSweetHome()
    {
        VehicleController.instance.vehicleState = VehicleController.VehicleState.Park;
        yield return new WaitForSeconds(1);
        taxiCamera.enabled = false;
        playerObj.SetActive(true);
    }

    public void ActivatePassengerObject()
    {
        StartCoroutine(PassengerEnter());
    }

    public void DeactivatePassengerObject()
    {
        StartCoroutine(PassengerExit());
    }
}
