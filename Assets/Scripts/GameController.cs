using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text pickupsText;

    int initialPickupsCount;

    public void CollectPickup()
    {
        var currentPickupsCount = GameObject.FindGameObjectsWithTag("Pickup").Length - 1;
        UpdateText(currentPickupsCount);
    }

    void Start()
    {
        initialPickupsCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        UpdateText(initialPickupsCount);
    }

    void UpdateText(int currentPickupsCount)
    {
        pickupsText.text = $"Pickups: {initialPickupsCount - currentPickupsCount} / {initialPickupsCount}";
    }
}
