public class GaussSeidel
{
    public static float[] Method(float[,] A, float[] b)
    {
        int n = b.Length;
        float[] x = new float[n];
        for (int i = 0; i < n; i++)
        {
            x[i] = 0;
        }

        for (int k = 0; k < n - 1; k++)
        {
            for (int i = k + 1; i < n; i++)
            {
                for (int j = k + 1; j < n; j++)
                {
                    A[i, j] = A[i, j] - A[k, j] * (A[i, k] / A[k, k]);
                }

                b[i] = b[i] - b[k] * A[i, k] / A[k, k];
            }
        }

        for (int k = n - 1; k >= 0; k--)
        {
            float s = 0;
            for (int j = k + 1; j < n; j++)
            {
                s += A[k, j] * x[j];
            }
            x[k] = (b[k] - s) / A[k, k];
        }

        return x;
    }
}
