namespace ExpenseControl.UserRegistration.Infra.Repository
{
    public interface IRepository
    {
    }

    public abstract class Repository : IRepository
    {
        protected readonly string _connectionString;

        //protected Repository(ILogger logger, IOptions<ConnectionStringOption> connectionString)
        //{
        //    //User = user;
        //    Logger = logger;
        //    //_connectionString = connectionString.Value.SQLConnection;
        //}

        //public ILogger Logger { get; }
        //public IAuthenticatedUser User { get; }
    }
}
