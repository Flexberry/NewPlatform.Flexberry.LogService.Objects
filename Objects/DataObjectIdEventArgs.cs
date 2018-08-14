using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IIS.Caseberry.Logging.MsEntLib
{
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
