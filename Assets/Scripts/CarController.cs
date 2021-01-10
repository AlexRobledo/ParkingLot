using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider ruedaDelanteraDerecha;
    public WheelCollider ruedaDelanteraIzquierda;
    public WheelCollider ruedaTraseraDerecha;
    public WheelCollider ruedaTraseraIzquierda;
    public float fuerzaMotor;
    public float maximaFuerzaMotor;
    public float giroRuedas;
    public float maximoGiroRuedas;
    public float freno;
    public bool estoyFrenando;
    public Vector3 centroDeMasas;
    public Vector3 positionRueda;
    public Quaternion rotationRueda;

    // Start is called before the first frame update
    void Start()
    {
        fuerzaMotor = 0.0f;
        maximaFuerzaMotor = 800.0f;
        giroRuedas = 0.0f;
        maximoGiroRuedas = 25.0f;
        centroDeMasas = new Vector3(0.0f, 0.0f, 0.0f);
        estoyFrenando = false;
        //this.gameObject.GetComponent<RigidBody>().centerOfMass = centroDeMasas;
    }

    // Update is called once per frame
    void Update()
    {
        fuerzaMotor = maximaFuerzaMotor * Input.GetAxis("Vertical");
        giroRuedas = maximoGiroRuedas * Input.GetAxis("Horizontal");
        if(Input.GetButton("Jump"))
        {
            estoyFrenando = true;
        }
        else
        {
            estoyFrenando = false;
        }
        ruedaDelanteraDerecha.steerAngle = giroRuedas;
        ruedaDelanteraIzquierda.steerAngle = giroRuedas;
        ruedaDelanteraDerecha.motorTorque = fuerzaMotor;
        ruedaDelanteraIzquierda.motorTorque = fuerzaMotor;
        ruedaTraseraDerecha.motorTorque = fuerzaMotor;
        ruedaTraseraIzquierda.motorTorque = fuerzaMotor;
        if(estoyFrenando)
        {
            ruedaDelanteraDerecha.brakeTorque = 400.0f;
            ruedaDelanteraIzquierda.brakeTorque = 400.0f;
            ruedaTraseraDerecha.brakeTorque = 400.0f;
            ruedaTraseraIzquierda.brakeTorque = 400.0f;
        }
        else
        {
            ruedaDelanteraDerecha.brakeTorque = 0.0f;
            ruedaDelanteraIzquierda.brakeTorque = 0.0f;
            ruedaTraseraDerecha.brakeTorque = 0.0f;
            ruedaTraseraIzquierda.brakeTorque = 0.0f;
        }
        //Rueda delantera derecha
        Transform ruedaDD = ruedaDelanteraDerecha.gameObject.transform.GetChild(0);
        ruedaDelanteraDerecha.GetComponent<WheelCollider>().GetWorldPose(out positionRueda, out rotationRueda);
        ruedaDD.transform.position = positionRueda;
        ruedaDD.transform.rotation = rotationRueda;
        //Rueda delantera izquierda
        Transform ruedaDI = ruedaDelanteraIzquierda.gameObject.transform.GetChild(0);
        ruedaDelanteraIzquierda.GetComponent<WheelCollider>().GetWorldPose(out positionRueda, out rotationRueda);
        ruedaDI.transform.position = positionRueda;
        ruedaDI.transform.rotation = rotationRueda;
        //Rueda trasera derecha
        Transform ruedaTD = ruedaTraseraDerecha.gameObject.transform.GetChild(0);
        ruedaTraseraDerecha.GetComponent<WheelCollider>().GetWorldPose(out positionRueda, out rotationRueda);
        ruedaTD.transform.position = positionRueda;
        ruedaTD.transform.rotation = rotationRueda;
    }
}
