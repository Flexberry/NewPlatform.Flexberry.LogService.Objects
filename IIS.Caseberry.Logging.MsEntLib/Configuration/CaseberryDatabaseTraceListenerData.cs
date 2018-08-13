// -----------------------------------------------------------------------
// <copyright file="CaseberryDatabaseTraceListenerData.cs" company="IIS">
// Copyright © ЗАО "Институт информационных систем" 2012
// </copyright>
// -----------------------------------------------------------------------

namespace IIS.Caseberry.Logging.MsEntLib.Configuration
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;
    using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;

    /// <summary>
    /// Configuration object for a <see cref="CaseberryDatabaseTraceListener"/>.
    /// </summary>
    [ResourceDescription(typeof(DesignResources), "CaseberryDatabaseTraceListenerDataDescription")]
    [ResourceDisplayName(typeof(DesignResources), "CaseberryDatabaseTraceListenerDataDisplayName")]
    [AddSateliteProviderCommand("connectionStrings", typeof(DatabaseSettings), "DefaultDatabase", "DatabaseInstanceName")]
    public class CaseberryDatabaseTraceListenerData : TraceListenerData
    {
        /// <summary>
        /// Formatter property name
        /// </summary>
        private const string FormatterNameProperty = "formatter";

        /// <summary>
        /// Initializes a new instance of the <see cref="CaseberryDatabaseTraceListenerData"/> class.
        /// </summary>
        public CaseberryDatabaseTraceListenerData()
            : base(typeof(CaseberryDatabaseTraceListener))
        {
            ListenerDataType = typeof(CaseberryDatabaseTraceListenerData);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaseberryDatabaseTraceListenerData"/> class
        /// with name and formatter name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="formatterName">The formatter name.</param>
        public CaseberryDatabaseTraceListenerData(string name, string formatterName)
            : this(
                name,
                formatterName,
                TraceOptions.None,
                SourceLevels.All)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaseberryDatabaseTraceListenerData"/> class
        /// with name and formatter name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="formatterName">The formatter name.</param>
        /// <param name="traceOutputOptions">The trace options.</param>
        /// <param name="filter">The filter to be applied</param>
        public CaseberryDatabaseTraceListenerData(
                                                    string name,
                                                    string formatterName,
                                                    TraceOptions traceOutputOptions,
                                                    SourceLevels filter)
            : base(name, typeof(CaseberryDatabaseTraceListener), traceOutputOptions, filter)
        {
            this.Formatter = formatterName;
        }

        /// <summary>
        /// Gets or sets the formatter name.
        /// </summary>
        [ConfigurationProperty(FormatterNameProperty, IsRequired = false)]
        [ResourceDescription(typeof(DesignResources), "CaseberryDatabaseTraceListenerDataFormatterDescription")]
        [ResourceDisplayName(typeof(DesignResources), "CaseberryDatabaseTraceListenerDataFormatterDisplayName")]
        [Reference(typeof(NameTypeConfigurationElementCollection<FormatterData, CustomFormatterData>), typeof(FormatterData))]
        public string Formatter
        {
            get { return (string)base[FormatterNameProperty]; }
            set { base[FormatterNameProperty] = value; }
        }

        /// <summary>
        /// Returns a lambda expression that represents the creation of the trace listener described by this
        /// configuration object.
        /// </summary>
        /// <returns>A lambda expression to create a trace listener.</returns>
        protected override Expression<Func<TraceListener>> GetCreationExpression()
        {
            return () =>
                   new CaseberryDatabaseTraceListener(Container.ResolvedIfNotNull<ILogFormatter>(this.Formatter));
        }
    }
}
