using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMessage : MonoBehaviour
{
    public GameObject TextPrefab;
    public float Offset = 0f;

    private List<Text> Popups = new List<Text>();

    private void Update()
    {
        foreach (var popup in Popups)
        {
            if (popup != null)
            {
                popup.transform.position += new Vector3(0f, 0f, -1.5f * Time.deltaTime);
                popup.color = new Color(popup.color.r, popup.color.g, popup.color.b, popup.color.a - Time.deltaTime);
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var popup in Popups)
        {
            if (popup != null)
            {
                Destroy(popup.gameObject);
            }
        }
    }

    public void CreatePopup(float number, Color color)
    {
        CreatePopup(string.Format("{0:0}", number), color);
    }

    public void CreatePopup(string text, Color color)
    {
        var popup = Instantiate(TextPrefab, transform.position + new Vector3(0f, 0f, -Offset), TextPrefab.transform.rotation);

        var txt = popup.GetComponentInChildren<Text>();

        txt.text = text;
        txt.color = color;

        Popups.Add(txt);

        Destroy(popup, 5f);
    }
}
