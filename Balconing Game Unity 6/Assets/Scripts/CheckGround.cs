using UnityEngine;

public class CheckGround : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            Debug.Log("Ha caido en el suelo");
        } else if(other.gameObject.tag == "Water")
        {
            GameManager.Instance.Points++;
            Debug.Log("Ha caido en el agua");
        }

        GameManager.Instance.GameActive = false;
        GameManager.Instance.ResetPositions();
    }
}
