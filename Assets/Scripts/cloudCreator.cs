using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudCreator : MonoBehaviour
{
    [SerializeField] GameObject cloud1, cloud2;
    [SerializeField] float waitTimeMain = 100f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnClouds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnClouds() 
    {
        yield return new WaitForSeconds(0f);
        Instantiate (cloud1, this.transform.position, cloud1.transform.rotation);
        yield return new WaitForSeconds(50f);
        Instantiate (cloud2, this.transform.position, cloud2.transform.rotation);

        yield return new WaitForSeconds(waitTimeMain);
        Instantiate (cloud1, this.transform.position, cloud1.transform.rotation);
        yield return new WaitForSeconds(50f);
        Instantiate (cloud2, this.transform.position, cloud2.transform.rotation);

        yield return new WaitForSeconds(waitTimeMain);
        Instantiate (cloud1, this.transform.position, cloud1.transform.rotation);
        yield return new WaitForSeconds(50f);
        Instantiate (cloud2, this.transform.position, cloud2.transform.rotation);

        yield return new WaitForSeconds(waitTimeMain);
        Instantiate (cloud1, this.transform.position, cloud1.transform.rotation);
        yield return new WaitForSeconds(50f);
        Instantiate (cloud2, this.transform.position, cloud2.transform.rotation);

        yield return new WaitForSeconds(waitTimeMain);
        Instantiate (cloud1, this.transform.position, cloud1.transform.rotation);
        yield return new WaitForSeconds(50f);
        Instantiate (cloud2, this.transform.position, cloud2.transform.rotation);

        yield return new WaitForSeconds(waitTimeMain);
        Instantiate (cloud1, this.transform.position, cloud1.transform.rotation);
        yield return new WaitForSeconds(50f);
        Instantiate (cloud2, this.transform.position, cloud2.transform.rotation);

        yield return new WaitForSeconds(waitTimeMain);
        Instantiate (cloud1, this.transform.position, cloud1.transform.rotation);
        yield return new WaitForSeconds(50f);
        Instantiate (cloud2, this.transform.position, cloud2.transform.rotation);

        yield return new WaitForSeconds(waitTimeMain);
        Instantiate (cloud1, this.transform.position, cloud1.transform.rotation);
        yield return new WaitForSeconds(50f);
        Instantiate (cloud2, this.transform.position, cloud2.transform.rotation);

        yield return new WaitForSeconds(waitTimeMain);
        Instantiate (cloud1, this.transform.position, cloud1.transform.rotation);
        yield return new WaitForSeconds(50f);
        Instantiate (cloud2, this.transform.position, cloud2.transform.rotation);

        yield return new WaitForSeconds(waitTimeMain);
        Instantiate (cloud1, this.transform.position, cloud1.transform.rotation);
        yield return new WaitForSeconds(50f);
        Instantiate (cloud2, this.transform.position, cloud2.transform.rotation);
        

    }
}
