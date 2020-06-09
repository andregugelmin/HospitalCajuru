using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTree : MonoBehaviour
{

    public GameObject baseArvore, troncoArvore, topoArvore, spawnPoint;
    private Vector3 primeiroTronco, segundoTronco, topo;
    // Start is called before the first frame update
    void Start()
    {
        primeiroTronco = spawnPoint.transform.position + new Vector3(0, 0.75f, 0);
        segundoTronco = primeiroTronco + new Vector3(0, 0.27f, 0);

        if (Points.instance.finalPoints <= 100)
        {
            Instantiate(baseArvore, spawnPoint.transform.position, transform.rotation);
            Instantiate(troncoArvore, primeiroTronco, transform.rotation);
            Instantiate(topoArvore, primeiroTronco + new Vector3(0, 1.15f, 0), transform.rotation);
        }
        else if (Points.instance.finalPoints <= 250)
        {
            Instantiate(baseArvore, spawnPoint.transform.position, transform.rotation);
            Instantiate(troncoArvore, primeiroTronco, transform.rotation);
            Instantiate(troncoArvore, segundoTronco, transform.rotation);
            Instantiate(topoArvore, segundoTronco + new Vector3(0, 1.15f, 0), transform.rotation);
        }
        else if (Points.instance.finalPoints <= 400)
        {
            Instantiate(baseArvore, spawnPoint.transform.position, transform.rotation);
            Instantiate(troncoArvore, primeiroTronco, transform.rotation);
            Instantiate(troncoArvore, segundoTronco, transform.rotation);
            Instantiate(troncoArvore, segundoTronco + new Vector3(0, 0.27f, 0), transform.rotation);
            Instantiate(topoArvore, segundoTronco + new Vector3(0, 1.42f, 0), transform.rotation);
        }
        else if (Points.instance.finalPoints <= 800)
        {
            Instantiate(baseArvore, spawnPoint.transform.position, transform.rotation);
            Instantiate(troncoArvore, primeiroTronco, transform.rotation);
            Instantiate(troncoArvore, segundoTronco, transform.rotation);
            Instantiate(troncoArvore, segundoTronco + new Vector3(0, 0.27f, 0), transform.rotation);
            Instantiate(troncoArvore, segundoTronco + new Vector3(0, 0.54f, 0), transform.rotation);
            Instantiate(topoArvore, segundoTronco + new Vector3(0, 1.69f, 0), transform.rotation);
        }
        else
        {
            Instantiate(baseArvore, spawnPoint.transform.position, transform.rotation);
            Instantiate(troncoArvore, primeiroTronco, transform.rotation);
            Instantiate(troncoArvore, segundoTronco, transform.rotation);
            Instantiate(troncoArvore, segundoTronco + new Vector3(0, 0.27f, 0), transform.rotation);
            Instantiate(troncoArvore, segundoTronco + new Vector3(0, 0.54f, 0), transform.rotation);
            Instantiate(troncoArvore, segundoTronco + new Vector3(0, 0.81f, 0), transform.rotation);
            Instantiate(topoArvore, segundoTronco + new Vector3(0, 1.96f, 0), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
