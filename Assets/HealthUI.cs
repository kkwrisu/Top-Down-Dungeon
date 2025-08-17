using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class HealthUI : MonoBehaviour
{
    public UnityEngine.UI.Image heartPrefab;
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    private List<Image> hearts = new List<Image>();

    public void SetMaxHearts(int maxHearts)
    {
        foreach (Image heart in hearts)
        {
            Destroy(heart.gameObject);
        }

        hearts.Clear();

        for (int i = 0; i < maxHearts; i++)
        {
            Image heart = Instantiate(heartPrefab, transform);
            heart.sprite = fullHeartSprite;
            heart.color = Color.red;
            hearts.Add(heart);
        }
    }

    public void UpdatedHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeartSprite;
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].sprite = emptyHeartSprite;
                hearts[i].color = Color.white;
            }
        }
    }
}
