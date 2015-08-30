using UnityEngine;
using System.Collections;

public class Conveyor : MonoBehaviour 
{
    public float Speed = 1;

	void Update () 
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
	}
}
