using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class newPlant : Form
    {
        public newPlant()
        {
            InitializeComponent();
            iconButton1.Click += iconButton1_Click;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string nombre = textBox5.Text.Trim();
            string nombreCien = textBox4.Text.Trim();
            string descripcion = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(nombreCien))
            {
                MessageBox.Show("Debes ingresar el nombre y el nombre científico de la planta.", "Campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox6.Text.Trim(), out decimal hsMin) ||
                !decimal.TryParse(textBox7.Text.Trim(), out decimal hsMax) ||
                !decimal.TryParse(textBox11.Text.Trim(), out decimal taMin) ||
                !decimal.TryParse(textBox8.Text.Trim(), out decimal taMax) ||
                !decimal.TryParse(textBox10.Text.Trim(), out decimal haMin) ||
                !decimal.TryParse(textBox19.Text.Trim(), out decimal haMax) ||
                !decimal.TryParse(textBox9.Text.Trim(), out decimal lMin) ||
                !decimal.TryParse(textBox20.Text.Trim(), out decimal lMax))
            {
                MessageBox.Show("Todos los campos de requerimientos deben ser valores numéricos.", "Campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (hsMin >= hsMax || taMin >= taMax || haMin >= haMax || lMin >= lMax)
            {
                MessageBox.Show("El valor mínimo debe ser menor que el máximo en cada rango.", "Rangos inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string desc = string.IsNullOrEmpty(descripcion) ? null : descripcion;

                string sql = @"
BEGIN TRY
    BEGIN TRANSACTION
        DECLARE @newId INT;
        INSERT INTO PLANTA (nombre, nombreCien, descripcion) VALUES (@nombre, @nombreCien, @desc);
        SET @newId = SCOPE_IDENTITY();
        INSERT INTO REQUERIMIENTOS (tempAireMin, tempAireMax, humAireMin, humAireMax, humSueloMin, humSueloMax, luzMin, luzMax, idPlanta)
        VALUES (@taMin, @taMax, @haMin, @haMax, @hsMin, @hsMax, @lMin, @lMax, @newId);
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    THROW;
END CATCH";

                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@nombre", nombre));
                parametros.Add(new SqlParameter("@nombreCien", nombreCien));
                parametros.Add(new SqlParameter("@desc", string.IsNullOrEmpty(descripcion) ? (object)DBNull.Value : descripcion));
                parametros.Add(new SqlParameter("@taMin", taMin));
                parametros.Add(new SqlParameter("@taMax", taMax));
                parametros.Add(new SqlParameter("@haMin", haMin));
                parametros.Add(new SqlParameter("@haMax", haMax));
                parametros.Add(new SqlParameter("@hsMin", hsMin));
                parametros.Add(new SqlParameter("@hsMax", hsMax));
                parametros.Add(new SqlParameter("@lMin", lMin));
                parametros.Add(new SqlParameter("@lMax", lMax));

                int filas = DataAccess.DataAccess.execQuery(sql, parametros);

                if (filas <= 0)
                {
                    MessageBox.Show("No se pudo registrar la planta.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Planta y requerimientos registrados correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
