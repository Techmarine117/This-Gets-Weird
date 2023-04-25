using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{

    public DataManager dataManager;
    [SerializeField] GameObject savingAni;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.FindObjectOfType<DataManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FPSPlayer")
        {
            Debug.Log("Triggered");
            StartCoroutine(SaveAnim());
            dataManager.SaveGame();
            FindObjectOfType<SaveSystem>().SaveGameToSlot(0);
            
        }
    }

    IEnumerator SaveAnim()
    {
        savingAni.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        savingAni.SetActive(false);
    }
}
