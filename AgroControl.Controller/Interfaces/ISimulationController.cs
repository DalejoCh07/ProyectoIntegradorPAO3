namespace AgroControl.Controller.Interfaces
{
    public interface ISimulationController
    {
        (double[] fechas, double[] tempAire, double[] humAire, double[] humSuelo, double[] luzTotal)
            GenerarCurvas(int idInvernadero);
        (double[] tiempos, double[] tempReal, double[] tempModelo, double[] humedadSuelo)
            ObtenerComparacion(int idInvernadero);
    }
}
