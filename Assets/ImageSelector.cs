using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageSelector : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    Image imageComponent;
    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideImage()
    {
        imageComponent.enabled = false;
    }

    public int GetNumberOfImages()
    {
        return sprites.Length;
    }

    public void ShowImage(int index)
    {
        imageComponent.enabled = true;
        if (index < sprites.Length)
        {
            imageComponent.sprite = sprites[index];
            imageComponent.SetNativeSize();
        }
    }
}
