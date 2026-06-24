using System.Data.SqlClient;
using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;
using AgroControl.Model.DAO.Implementations;
using AgroControl.Controller.Interfaces;

namespace AgroControl.Controller.Implementations
{
    public class PlantController : IPlantController
    {
        private readonly IPlantDAO _dao = new PlantDAO();
        private readonly IRequirementsDAO _reqDao = new RequirementsDAO();

        public int Agregar(Plant plant) => _dao.Insert(plant);
        public Plant? Obtener(int id) => _dao.GetById(id);
        public List<Plant> Listar() => _dao.GetAll();
        public List<Plant> Buscar(string nombre) => _dao.Search(nombre);
        public void Eliminar(int id) => _dao.Delete(id);

        public void GuardarConRequerimientos(Plant planta, Requirements req)
        {
            string sql = @"BEGIN TRY BEGIN TRANSACTION
                DECLARE @newId INT;
                INSERT INTO PLANTA (nombre, nombreCien, descripcion) VALUES (@nombre, @nombreCien, @desc);
                SET @newId = SCOPE_IDENTITY();
                INSERT INTO REQUERIMIENTOS (tempAireMin, tempAireMax, humAireMin, humAireMax, humSueloMin, humSueloMax, luzMin, luzMax, idPlanta)
                VALUES (@taMin, @taMax, @haMin, @haMax, @hsMin, @hsMax, @lMin, @lMax, @newId);
            COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION; THROW; END CATCH";

            var pars = new List<SqlParameter>
            {
                new("@nombre", planta.Nombre), new("@nombreCien", planta.NombreCien),
                new("@desc", string.IsNullOrEmpty(planta.Descripcion) ? (object)DBNull.Value : planta.Descripcion),
                new("@taMin", req.TempAireMin), new("@taMax", req.TempAireMax),
                new("@haMin", req.HumAireMin), new("@haMax", req.HumAireMax),
                new("@hsMin", req.HumSueloMin), new("@hsMax", req.HumSueloMax),
                new("@lMin", req.LuzMin), new("@lMax", req.LuzMax)
            };
            Model.DataAccess.ExecQuery(sql, pars);
        }
    }
}
