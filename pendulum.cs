using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class pendulum : MonoBehaviour {

    public Text t;


    Quaternion start, end;

    [SerializeField, Range(0.0f, 360f)]
    private float angle = 90.0f;

    [SerializeField, Range(0.0f, 5.0f)]
    private float speed = 2.0f;

    [SerializeField, Range(0.0f, 10f)]
    private float starttime = 0.0f;

    void Start()  
    {
        start = PendulumRot(angle);
        end = PendulumRot(--angle);
    }

    void Update()
    {
        t.text = "Angle:" + angle;
    }

	// Update is called once per frame
	void FixedUpdate () {
        starttime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(start, end, (Mathf.Sin(starttime * speed + Mathf.PI / 2) + 1.0f) / 2.0f);
	}

    Quaternion PendulumRot(float angle)
    {
        var pendulumRotation = transform.rotation;
        var angle2 = pendulumRotation.eulerAngles.z + angle;

        if (angle2 > 100)
        {
            angle2 -= 360;
            pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, (angle2 * 50));
        }
        else if (angle2 < -100)
        {
            angle2 += 360;
            pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, -(angle2 * 50));
        }
  //      pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angle2 * 20);
        return pendulumRotation;
    }

    

    void ResetTimer()
    {
        starttime = 0.0f;
    }

}
