using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Calculations : MonoBehaviour
{
    [SerializeField] private MessageBox messageBox;
    [SerializeField] private InputField arrayInput;
    [SerializeField] private Text resultInfoText;
    [SerializeField] private Slider sizeSlider;
    [SerializeField] private InputField sizeInput;
    [SerializeField] private InputField leftBorder;
    [SerializeField] private InputField rightBorder;

    private float min;
    private float max;
    private int size;
    private int amountOfOperations = 0;
    private Stopwatch stopwatch = new Stopwatch();
    private Coroutine calculateCoroutine;

    private void Awake()
    {
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
    }

    public void Calculate()
    {
        calculateCoroutine = StartCoroutine("CalculateCoroutine");
    }
    private IEnumerator CalculateCoroutine()
    {
        if (arrayInput.text.Equals("")) { ThrowError("Помилка", "Масив пустий!"); }

        var unsortedArrayOfStrings = arrayInput.text.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        var unsortedArray = Array.ConvertAll(unsortedArrayOfStrings, new Converter<string, float>(StringToFloat));

        stopwatch.Start();
        var sortedArray = Sort(unsortedArray, 0, unsortedArray.Length - 1);
        stopwatch.Stop();

        arrayInput.text = string.Join(", ", sortedArray);
        resultInfoText.text = $"Кількість елементів: {sortedArray.Length}\n" +
                              $"Час виконання: {stopwatch.Elapsed.TotalMilliseconds * 1000} мкс\n" +
                              $"Кількість операцій: {amountOfOperations}";
        stopwatch.Reset();
        amountOfOperations = 0;

        yield return null;
    }

    public void Randomize()
    {
        try 
        { 
            size = int.Parse(sizeInput.text);
            min = float.Parse(leftBorder.text);
            max = float.Parse(rightBorder.text);
        }
        catch { ThrowError("Помилка", "Розмір масиву, або границі генерування випадкових чисел задані некоректно!"); }

        if (min >= max) { ThrowError("Помилка", "Ліва границя генерування випадкових чисел менша або дорівнює правій!"); }
        
        arrayInput.text = string.Join(", ", RandomizeArray(size, min, max));
    }
    private float[] RandomizeArray(int size, float min, float max)
    {
        var randomArray = new float[size];
        for (int i = 0; i < size; i++)
        {
            randomArray[i] = (float)Math.Round((double)UnityEngine.Random.Range(min, max), 2);
        }
        return randomArray;
    }

    private float StringToFloat(string stringNumber)
    {
        try { return float.Parse(stringNumber, CultureInfo.InvariantCulture); }
        catch
        {
            ThrowError("Помилка", "Масив заданий некоректно!");
            return -1;
        }
    }

    private float[] Sort(float[] array, int low, int high)
    {
        if (low < high)
        {
            try
            {
                int partitionIndex = Partition(array, low, high);
                Sort(array, low, partitionIndex - 1);
                Sort(array, partitionIndex + 1, high);
            }
            catch
            {
                ThrowError("Помилка", $"Відбулось переповнення стеку, через надто велику кількість рекурсивних викликів." +
                                      $" Скоріше за все, це відбулось через те, що ви спробували відсортувати вже упорядкований масив" +
                                      $" (через особливості алгоритму кількість рекурсивних викликів у такому випадку надто висока => O(n)).");
            }
        }

        return array;
    }
    private int Partition(float[] array, int low, int high)
    {
        float pivot = array[high];
        int lowIndex = (low - 1);

        for (int i = low; i < high; i++)
        {
            if (array[i] <= pivot)
            {
                lowIndex++;

                float temp = array[lowIndex];
                array[lowIndex] = array[i];
                array[i] = temp;
                amountOfOperations += 1;
            }
            amountOfOperations += 1;
        }

        float temp1 = array[lowIndex + 1];
        array[lowIndex + 1] = array[high];
        array[high] = temp1;
        amountOfOperations += 1;

        return lowIndex + 1;
    }

    public void OnSizeSliderValueChanged()
    {
        sizeInput.text = sizeSlider.value.ToString();
    }
    public void OnSizeInputValueChanged()
    {
        try { sizeSlider.value = int.Parse(sizeInput.text); }
        catch { return; }
    }
    private void ThrowError(string title, string message)
    {
        messageBox.Configure(title, message);
        messageBox.Show();
        StopCoroutine(calculateCoroutine);
    }
}
