namespace IIS.Caseberry.Logging.Objects
{
    using System;

    /// <summary>
    /// Содержит идентификатор data-object
    /// </summary>
    public class DataObjectIdEventArgs:EventArgs
    {
        /// <summary>
        /// Id дата-обджекта
        /// </summary>
        public Object DataObjectId { get; set; }
    }
}
