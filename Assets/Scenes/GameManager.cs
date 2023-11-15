using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playScore;
    public int PlayerScore { get { return PlayerScore; } set { PlayerScore = value; } }

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] ballPosition;

    public static GameManager instance;
    
    void Start()
    {
        instance = this;
        
        SetBall(BallColor.Red,1);
    }

   
    void Update()
    {
        
    }

    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab, ballPosition[i].transform.position, Quaternion.identity);

        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }
}
