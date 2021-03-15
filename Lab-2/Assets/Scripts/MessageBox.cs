using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    [SerializeField] private Image cover;
    [SerializeField] private GameObject container;
    [SerializeField] private Text title;
    [SerializeField] private Text message;

    public void Configure(string title, string message)
    {
        this.title.text = title;
        this.message.text = message;
    }
    public void Show()
    {
        cover.color = new Color(0, 0, 0, 0.75f);
        container.SetActive(true);
    }
    public void Dismiss()
    {
        cover.color = new Color(0, 0, 0, 0);
        container.SetActive(false);
    }
}
