using AwesomeCharts;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private LineChart mainPlotChart;
    [SerializeField] private LineChart errorPlotChart;
    [Space]
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;

    private Interpolation interpolation;

    private void Awake()
    {
        interpolation = new Interpolation(this);
    }
    private void Start()
    {
        ConfigurePlotChartAxisBordersX(mainPlotChart, new Vector2(leftBorder, rightBorder));
        ConfigurePlotChartAxisBordersX(errorPlotChart, new Vector2(leftBorder, rightBorder));
    }

    public void SinFunctionButton()
    {
        ClearPlotChart(mainPlotChart);
        ClearPlotChart(errorPlotChart);

        interpolation.SinFunctionInterpolation(11, leftBorder, rightBorder);
        interpolation.SinFunctionError(11, leftBorder, rightBorder);

        ConfigurePlotChartAxisBordersY(mainPlotChart, new Vector2(0, 1.1f));
        ConfigurePlotChartAxisBordersY(errorPlotChart, new Vector2(0, 1));

        RefreshAllPlotCharts();
    }
    public void MyFunctionButton()
    {
        ClearPlotChart(mainPlotChart);
        ClearPlotChart(errorPlotChart);

        interpolation.MyFunctionInterpolation(11, leftBorder, rightBorder);
        interpolation.MyFunctionError(11, leftBorder, rightBorder);

        ConfigurePlotChartAxisBordersY(mainPlotChart, new Vector2(-1.8f, 3.7f));
        ConfigurePlotChartAxisBordersY(errorPlotChart, new Vector2(0, 4f));

        RefreshAllPlotCharts();
    }

    public void AddEntryToMainPlot(int dataSet, Vector2 entry)
    {
        mainPlotChart.GetChartData().DataSets[dataSet].AddEntry(new LineEntry(entry.x, entry.y));
    }
    public void AddEntryToErrorPlot(int dataSet, Vector2 entry)
    {
        errorPlotChart.GetChartData().DataSets[dataSet].AddEntry(new LineEntry(entry.x, entry.y));
    }

    private void ConfigurePlotChartAxisBordersX(LineChart lineChart, Vector2 xAxis)
    {
        lineChart.XAxis.MinAxisValue = xAxis.x;
        lineChart.XAxis.MaxAxisValue = xAxis.y;
    }
    private void ConfigurePlotChartAxisBordersY(LineChart lineChart, Vector2 yAxis)
    {
        lineChart.YAxis.MinAxisValue = yAxis.x;
        lineChart.YAxis.MaxAxisValue = yAxis.y;
    }
    private void ClearPlotChart(LineChart lineChart)
    {
        for (int i = 0; i < lineChart.GetChartData().DataSets.Count; i++)
        {
            lineChart.GetChartData().DataSets[i].Clear();
        }
    }
    private void RefreshAllPlotCharts()
    {
        mainPlotChart.SetDirty();
        errorPlotChart.SetDirty();
    }
}
