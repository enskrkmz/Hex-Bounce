using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform ballpos,hexagon;
    [SerializeField] private Transform ballstartpos;
    private bool starting = false;
    [SerializeField] private TMP_Text tapToPlayText;
    void Start()
    {
        hexagon.GetComponent<HexagonMovement>().enabled = false;
    }
    void Update()
    {
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame && !starting)
        {
            ballpos.position = ballstartpos.position;
            starting = true;
            hexagon.GetComponent<HexagonMovement>().enabled = true;
            tapToPlayText.enabled = false;
        }
    }
}
