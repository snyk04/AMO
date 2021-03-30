using System;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private InputField leftBorderInput;
    [SerializeField] private InputField rightBorderInput;
    [SerializeField] private Text resultText;
    [SerializeField] private MessageBox messageBox;

    public void Calculate()
    {
        messageBox.SetTitle("Помилка");

        double leftBorder;
        double rightBorder;

        try
        {
            leftBorder = double.Parse(leftBorderInput.text);
            rightBorder = double.Parse(rightBorderInput.text);
        }
        catch
        {
            ThrowException("Некоректно задані границі");
            return;
        }

        if (leftBorder >= rightBorder)
        {
            ThrowException("Ліва границя менше або дорівнює правій границі");
            return;
        }

        try
        {
            resultText.text = $"Корінь = {Math.Round(CombinedMethod.MainFun(leftBorder, rightBorder, 0.001), 4)}";
        }
        catch (ArgumentException exception)
        {
            switch (exception.Message)
            {
                case "Function wrong":
                    ThrowException("Заданий проміжок є не коректним для даної функції, оскільки на ньому функція не змінює знак");
                    break;
                case "First derivative wrong":
                    ThrowException("Заданий проміжок є не коректним для даної функції, оскільки на ньому перша похідна змінуює знак");
                    break;
                case "Second derivative wrong":
                    ThrowException("Заданий проміжок є не коректним для даної функції, оскільки на ньому друга похідна змінуює знак");
                    break;
            }
            return;
        }

    }
    public void ThrowException(string text)
    {
        messageBox.SetText(text);
        messageBox.Show();
    }
}
