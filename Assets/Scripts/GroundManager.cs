using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject groundGameObject;
    [SerializeField]
    private GameObject coin;
    private float sizeXZ;
    private Vector3 lastPosition;
    private int graundLimit = 10;
    public static int groundsCreated;
    void Start()
    {
        groundsCreated = 0;
        lastPosition = groundGameObject.transform.position;
        sizeXZ = groundGameObject.transform.localScale.x;
        StartCoroutine(CreateGroundInGame());
    }

    private void CreateX()
    {
        lastPosition.x += sizeXZ;
        Instantiate(groundGameObject, lastPosition, Quaternion.identity);
        CreateCoin();
    }

    private void CreateZ()
    {
        lastPosition.z += sizeXZ;
        Instantiate(groundGameObject, lastPosition, Quaternion.identity);
        CreateCoin();
    }

    IEnumerator CreateGroundInGame()
    {
        while (!BallController.gameOver)
        {
            yield return new WaitForSeconds(0.2f);
            CreateGroundXZ();
        }
    }

    private void CreateGroundXZ()
    {
        int value = Random.Range(0, 2);
        if(groundsCreated == graundLimit) return;
        if (value.Equals(0))
        {
            CreateX();
        }
        else
        {
            CreateZ();
        }
        groundsCreated++;
    }

    private void CreateCoin()
    {
        int index = Random.Range(0, 5);
        if (index > 2) return;
        
        Vector3 position = lastPosition;
        position.y += 0.2f;
        Instantiate(coin, position, coin.transform.rotation);
    }
}
