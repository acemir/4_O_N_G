using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
    [Header("Settings")]
    public float Cycles = 10f;

	void Update () {

        this.transform.Rotate(Vector3.up, Cycles * Time.deltaTime);
	}
}
