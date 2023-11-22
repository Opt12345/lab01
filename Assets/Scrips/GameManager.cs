using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playScore;
    public int PlayerScore;

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] ballPosition;
    [SerializeField] private GameObject cueBall;
    [SerializeField] private GameObject ballLine;
    [SerializeField] private GameObject camera;
    [SerializeField] private float xInput;


    public static GameManager instance;
    
    void Start()
    {
        instance = this;

        camera = Camera.main.gameObject;
        CameraBehindCueBall();
        camera.transform.SetParent(cueBall.transform);
        
        SetBall(BallColor.White,0);
        SetBall(BallColor.Red,1);
        SetBall(BallColor.Yellow,2);
        SetBall(BallColor.Green,3);
        SetBall(BallColor.Brown,4);
        SetBall(BallColor.Blue,5);
        SetBall(BallColor.Pink,6);
        SetBall(BallColor.Black,7);
    }
    
    void Update()
    {
        RotateBall();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }
        
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StopBall();
        }
    }

    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab, ballPosition[i].transform.position, Quaternion.identity);

        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }

    private void RotateBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f, xInput, 0f));
    }

    private void ShootBall()
    {
        camera.transform.parent = null;
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 20, ForceMode.Impulse);
        ballLine.SetActive(false);
    }

    private void CameraBehindCueBall()
    {
        camera.transform.parent = cueBall.transform;
        camera.transform.position = cueBall.transform.position + new Vector3(0f, 7f, -10f);
    }

    private void StopBall()
    {
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles =Vector3.zero;
        
        CameraBehindCueBall();
        camera.transform.eulerAngles = new Vector3(30f, 0f, 0f);
        ballLine.SetActive(true);
    }

}
