namespace IIS.Caseberry.Logging.Objects
{
    using System;

    /// <summary>
    /// Исключение-обертка для строк лога.
    /// </summary>
    [Serializable]
    public class ApplicationLogException : Exception
    {
        private const string ExceptionMessage = "Информация о записи лога приложения";

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="innerException">Исключение.</param>
        public ApplicationLogException(Exception innerException)
            : base(ExceptionMessage, innerException)
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="innerException">Исключение.</param>
        public ApplicationLogException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
