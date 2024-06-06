using UnityEngine;

public class ChestController : MonoBehaviour
{
    public BoxChecker[] boxes; 
    public GameObject torch; 

    private bool isOpen = false;

    void Update()
    {

        if (!isOpen && CheckAllBoxes())
        {
            OpenChest();
        }
    }

    bool CheckAllBoxes()
    {
        foreach (BoxChecker box in boxes)
        {
            if (!box.GetIsCorrect())
            {
                return false;
            }
        }
        return true;
    }

    void OpenChest()
    {
        isOpen = true;
        // Sandığın açılma animasyonunu veya işlemini burada yap
        Debug.Log("Meşale görünür oldu.");

        
            torch.SetActive(true);
        

    }
}
