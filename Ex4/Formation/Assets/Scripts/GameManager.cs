using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject copPrefab;
    public Transform startingPos;
    private GameObject[] copList = new GameObject[4];
    public bool isFormationRequired = false;

    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            copList[i] = Instantiate(copPrefab, startingPos);
            copList[i].name = "Cop " + (i + 1).ToString();
        }
    }
}
