using System;

public class CombinedMethod
{
    private static double fx(double x)
    {
        return Math.Pow(x, 3) - 2 * Math.Pow(x, 2) + x + 1;
    }
    private static double dFx(double x)
    {
        return 3 * Math.Pow(x, 2) - 4 * x + 1;
    }
    private static double d2Fx(double x)
    {
        return 6 * x - 4;
    }

    public static double MainFun(double leftBorder, double rightBorder, double epsilon)
    {
        double xOld = leftBorder;
        double xNew = leftBorder;
        double notXOld = rightBorder;
        double notXNew = rightBorder;

        if (fx(xOld) * fx(notXOld) > 0)
        {
            throw new ArgumentException("Function wrong");
        }
        if (dFx(xOld) * dFx(notXOld) <= 0)
        {
            throw new ArgumentException("First derivative wrong");
        }
        if (d2Fx(xOld) * d2Fx(notXOld) <= 0)
        {
            throw new ArgumentException("Second derivative wrong");
        }

        while (Math.Abs(notXNew - xNew) > epsilon)
        {
            xOld = xNew;
            notXOld = notXNew;
            xNew = xOld - ((fx(xOld)) / (fx(notXOld) - fx(xOld))) * (notXOld - xOld);
            notXNew = notXOld - (fx(notXOld) / dFx(notXOld));
        }
        return (xNew + notXNew) / 2;
    }
}
