using System;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [Header("Input and output")]
    [SerializeField] private InputField x1Input;
    [SerializeField] private InputField x2Input;
    [SerializeField] private InputField x3Input;
    [Space]
    [SerializeField] private InputField y1Input;
    [SerializeField] private InputField y2Input;
    [SerializeField] private InputField y3Input;
    [Space]
    [SerializeField] private InputField z1Input;
    [SerializeField] private InputField z2Input;
    [SerializeField] private InputField z3Input;
    [Space]
    [SerializeField] private InputField answer1Input;
    [SerializeField] private InputField answer2Input;
    [SerializeField] private InputField answer3Input;
    [Space]
    [SerializeField] private Text resultText;
    [Header("Other")]
    [SerializeField] private MessageBox messageBox;

    private void Start()
    {
        messageBox.SetTitle("Помилка");
    }

    public void Calculate()
    {
        float[,] A = { { GetNumber(x1Input) , GetNumber(y1Input) , GetNumber(z1Input) },
                       { GetNumber(x2Input) , GetNumber(y2Input) , GetNumber(z2Input) },
                       { GetNumber(x3Input) , GetNumber(y3Input) , GetNumber(z3Input) } };
        float[] b = { GetNumber(answer1Input) , GetNumber(answer2Input) , GetNumber(answer3Input) };

        try
        {
            float[] result = GaussSeidel.Method(A, b);
            resultText.text = "Корені рівняння:" +
                $"\nx = {result[0]}" +
                $"\ny = {result[1]}" +
                $"\nz = {result[2]}";
        }
        catch
        {
            messageBox.SetMessage("Щось не так з вашею матрицею");
        }
    }

    private float GetNumber(InputField input)
    {
        try
        {
            return float.Parse(input.text);
        }
        catch
        {
            messageBox.SetMessage("Некоректно введені дані");
            throw new ArgumentException();
        }
    }
}
