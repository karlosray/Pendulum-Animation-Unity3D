using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class changeShape : MonoBehaviour {


    public float length_y=1.0f, size_x=1.0f, size_z = 1.0f;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(size_x, length_y, size_z);

	}
}
