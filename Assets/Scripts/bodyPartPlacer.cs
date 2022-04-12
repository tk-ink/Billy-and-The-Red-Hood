using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyPartPlacer : MonoBehaviour
{
    private GameObject[] bodyParts;
    private int numOfPartsAllowed;
    private int totalNumOfParts;
    private int randomNum;

    public List<int> randomNumsChosen = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        bodyParts = GameObject.FindGameObjectsWithTag("bodyPart");
        //How many parts to allow in the scene
        numOfPartsAllowed = 6;
        totalNumOfParts = bodyParts.Length;

        if (totalNumOfParts > numOfPartsAllowed)
        {
            for (int i = bodyParts.Length; i > (bodyParts.Length - numOfPartsAllowed); --i)
            {
                //Build random array to determine which body parts to destroy
                randomNum = Random.Range(0, bodyParts.Length);
                if (!randomNumsChosen.Contains(randomNum))
                {
                    randomNumsChosen.Add(randomNum);
                }
                else
                {
                    //Add back to loop and try getting unique number again
                    i++;
                }

                
            }
            foreach (var item in randomNumsChosen)
            {
                //Remove body parts based on random compiled list
                Destroy(bodyParts[item]);
            }


        }


    }


    // Update is called once per frame
    void Update()
    {

    }
}
