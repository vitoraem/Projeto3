using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [Range(1f, 200f)] public float distancia = 2;
    public GameObject playerGO;
    public GameObject baldeGO;
    public int entregues;
    public static bool BucketUsed;
    public static bool WrenchUsed;
    public string _index;
    private bool coletou;

    private void Awake()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        BucketUsed = false;
        coletou = false;


    }

    IEnumerator GasolinaSpawn()
    {
        Instantiate(baldeGO, new Vector3(192.8f, 0, -30.2f), Quaternion.identity);
        coletou = true;
        yield return new WaitForSeconds(2);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerGO.transform.position);
        switch (entregues)
        {
            case 0:
                
                if (distanceToPlayer < distancia)
                {
                    if (DoorCards.HasBucket && Input.GetKeyDown(KeyCode.E))
                    {

                        var balde = InventoryManager.Items.Find(x => x.name == "Balde");
                        InventoryManager.Items.Remove(balde);
                        if (!BucketUsed)
                        {
                            entregues++;
                            BucketUsed = true;
                        }

                    }
                }
                break;
            case 1:
                
                if (distanceToPlayer < distancia)
                {
                    if (DoorCards.HasWrench && Input.GetKeyDown(KeyCode.E))
                    {
                        var chave = InventoryManager.Items.Find(x => x.name == "ChaveDeFenda");
                        InventoryManager.Items.Remove(chave);
                        if (!WrenchUsed)
                        {
                            entregues++;
                            WrenchUsed = true;
                        }

                    }


                }
                break;

                case 2:
                if(!coletou)
                 StartCoroutine(GasolinaSpawn());
                break;
        }
    }
}
