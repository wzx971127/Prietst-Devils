using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taiyangxi : MonoBehaviour
{

    public Transform sun;
    public Transform shuixing;
    public Transform jinxing;
    public Transform earth;
    public Transform huoxing;
    public Transform muxing;
    public Transform tuxing;
    public Transform tianwangxing;
    public Transform haiwangxing;
    public Transform moon;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sun.Rotate(Vector3.up * 30 * Time.deltaTime);

        shuixing.Rotate(Vector3.up * 40 * Time.deltaTime);
        shuixing.RotateAround(sun.position, new Vector3(1, -8, 0), 30 * Time.deltaTime);

        jinxing.Rotate(Vector3.up * 50 * Time.deltaTime);
        jinxing.RotateAround(sun.position, new Vector3(10, -23, 0), 100 * Time.deltaTime);

        earth.Rotate(Vector3.up * 60 * Time.deltaTime);
        earth.RotateAround(sun.position, new Vector3(0, 1, 0), 50 * Time.deltaTime);

        huoxing.Rotate(Vector3.up * 40 * Time.deltaTime);
        huoxing.RotateAround(sun.position, new Vector3(1, -2, 0), 70 * Time.deltaTime);

        muxing.Rotate(Vector3.up * 20 * Time.deltaTime);
        muxing.RotateAround(sun.position, new Vector3(2, 23, 0), 30 * Time.deltaTime);

        tuxing.Rotate(Vector3.up * 10 * Time.deltaTime);
        tuxing.RotateAround(sun.position, new Vector3(2, -11, 0), 40 * Time.deltaTime);

        tianwangxing.Rotate(Vector3.up * 30 * Time.deltaTime);
        tianwangxing.RotateAround(sun.position, new Vector3(3, -62, 0), 20 * Time.deltaTime);

        haiwangxing.Rotate(Vector3.up * 60 * Time.deltaTime);
        haiwangxing.RotateAround(sun.position, new Vector3(3, 34, 0), 100 * Time.deltaTime);

        moon.Rotate(Vector3.up * 60 * Time.deltaTime);
        moon.RotateAround(earth.position, Vector3.up, 500 * Time.deltaTime);
    }
}

