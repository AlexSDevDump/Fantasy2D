using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject invUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ToggleInventoryUI()
    {
        invUI.SetActive(!invUI.activeSelf);
    }
}
