using System;

namespace AgroControl
{
    public static class SimulationBus
    {
        public const double C = 10.0, alpha = 0.5, alpha2 = 0.8, beta = 0.1, gamma = 2.0, eta = 1.5;
        public const double kr = 5.0, kd = 0.5, ke = 0.1, kh = 4.0, kv = 1.2, ks = 0.8, kL = 500.0;
        public const double Text = 20.0;

        public static (double[] tiempos, double[] tempAire, double[] humSuelo, double[] humAire, double[] luzTotal)
            SimularInvernadero(int minutosSimulacion)
        {
            double dt = 0.1;
            int n = (int)(minutosSimulacion / dt);
            double[] tiempos = new double[n];
            double[] tempAire = new double[n];
            double[] humSuelo = new double[n];
            double[] humAire = new double[n];
            double[] luzTotal = new double[n];

            double R = 1.0, V = 0.0, L = 1.0, S = 0.0, U = 0.0, I_ext = 200.0;

            double T = 25.0, Hs = 40.0, Ha = 60.0;

            for (int i = 0; i < n; i++)
            {
                double Itotal = I_ext + kL * L;
                double evap = (T > 0 ? T : 0) * ((100.0 - Ha) / 100.0);

                double dT = (1.0 / C) * (alpha * I_ext + alpha2 * L - beta * (T - Text) - gamma * V - eta * S);
                double dHs = kr * R - kd * Hs - ke * evap;
                double dHa = kh * U + ke * Hs - kv * V * Ha - ks * S * Ha;

                T += dT * dt;
                Hs += dHs * dt;
                Ha += dHa * dt;

                Hs = Math.Max(0, Math.Min(100, Hs));
                Ha = Math.Max(0, Math.Min(100, Ha));

                tiempos[i] = i * dt;
                tempAire[i] = T;
                humSuelo[i] = Hs;
                humAire[i] = Ha;
                luzTotal[i] = Itotal;
            }

            return (tiempos, tempAire, humSuelo, humAire, luzTotal);
        }
    }
}
