namespace IIS.Caseberry.Logging.Objects
{
    /// <summary>
    /// Базовый интерфейс для менеджера логов.
    /// </summary>
    public interface ILogManager
    {
        /// <summary>
        /// Добавление идентификатора data-object.
        /// </summary>
        /// <param name="obj">Идентификатор data-object.</param>
        void OnNewLogEntryAdded(DataObjectIdEventArgs obj);
    }
}