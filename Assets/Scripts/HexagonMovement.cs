using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HexagonMovement : MonoBehaviour
{
    private Vector3 mPosition;
    void Update()
    {
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            mPosition = Camera.main.ScreenToWorldPoint(Pointer.current.position.ReadValue());
            mPosition.z = 0f;
            StartCoroutine(Move());
        }
        
    }
    private IEnumerator Move()
    {
        if (mPosition.x <= 0)
        {
            transform.Rotate(0, 0, 30);
            yield return new WaitForSeconds(.05f);
            transform.Rotate(0, 0, 30);
        }
        else
        {
            transform.Rotate(0, 0, -30);
            yield return new WaitForSeconds(.05f);
            transform.Rotate(0, 0, -30);
        }

    }
}
