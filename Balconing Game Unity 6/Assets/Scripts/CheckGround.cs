using UnityEngine;

public class CheckGround : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            GameManager.Instance.textResult.text = "¡Te has estrellado!";

        } else if(other.gameObject.tag == "Water")
        {
            GameManager.Instance.textResult.text = "¡Has sobrevivido al balconing!";
        }

        GameManager.Instance.GameActive = false;
        GameManager.Instance.HideShowUI();
        GameManager.Instance.ResetPositions();
    }
}
