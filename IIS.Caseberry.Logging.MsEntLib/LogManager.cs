namespace IIS.Caseberry.Logging.MsEntLib
{
    using IIS.Caseberry.Logging.Objects;

    /// <summary>
    /// Имплементация интерфейса <see cref="ILogManager"/>.
    /// </summary>
    public sealed class LogManager : ILogManager
    {
        ///<inheritdoc cref="IAgentManager"/>
        public void OnNewLogEntryAdded(DataObjectIdEventArgs obj)
        {
            CaseberryDatabaseTraceListener.OnNewLogEntryAdded(obj);
        }
    }
}
