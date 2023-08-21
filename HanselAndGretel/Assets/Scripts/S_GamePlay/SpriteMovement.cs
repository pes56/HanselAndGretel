using UnityEngine;
using UnityEngine.UI;

public class SpriteMovement : MonoBehaviour
{
    public Image spriteImage;
    public Image silhouetteImage;
    public float snapDistance = 20f;

    public Material glowMaterial;
    private Material originalMaterial;

    private bool isPlaced = false;
    private bool isMoving = false;

    private void Start()
    {
        originalMaterial = spriteImage.material;
    }

    private void Update()
    {
        if (!isPlaced && Vector2.Distance(spriteImage.rectTransform.anchoredPosition, silhouetteImage.rectTransform.anchoredPosition) <= snapDistance)
        {
            isPlaced = true;
            Debug.Log("CorrectSpot!");
            silhouetteImage.gameObject.SetActive(false);
        }
        else if (isPlaced && Vector2.Distance(spriteImage.rectTransform.anchoredPosition, silhouetteImage.rectTransform.anchoredPosition) > snapDistance)
        {
            isPlaced = false;
            silhouetteImage.gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0)) // Changed to GetMouseButtonDown
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject == spriteImage.gameObject)
            {
                isMoving = true;
                spriteImage.material = glowMaterial;
            }
        }
        else if (Input.GetMouseButtonUp(0)) // Changed to GetMouseButtonUp
        {
            if (isMoving)
            {
                isMoving = false;
                spriteImage.material = originalMaterial;
            }
        }
    }
}
