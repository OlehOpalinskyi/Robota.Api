namespace Robota.Data
{
    using Models;
    using System.Data.Entity;

    public class RobotaContext : DbContext
    {
        // Your context has been configured to use a 'RobotaContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Robota.Data.RobotaContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RobotaContext' 
        // connection string in the application configuration file.
        public RobotaContext()
            : base("name=RobotaContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<CategoryDataModel> Categories { get; set; }
        public virtual DbSet<PersonDataModel> Persons { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}