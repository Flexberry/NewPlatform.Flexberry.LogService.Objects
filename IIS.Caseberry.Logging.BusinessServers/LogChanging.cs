﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:2.0.50727.5420
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IIS.Caseberry.Logging
{
    using Unity;
    using ICSSoft.Services;
    using ICSSoft.STORMNET;
    using IIS.Caseberry.Logging.Objects;

    // *** Start programmer edit section *** (LogChanging CustomAttributes)

    // *** End programmer edit section *** (LogChanging CustomAttributes)
    [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class LogChanging : ICSSoft.STORMNET.Business.BusinessServer
    {

        // *** Start programmer edit section *** (LogChanging CustomMembers)

        /// <summary>
        /// Field for <see cref="LogManager"/>.
        /// </summary>
        private ILogManager logManager;

        /// <summary>
        /// Flag indicates that LogManager is empty (Unity config for <see cref="ILogManager"/> is absent).
        /// </summary>
        private bool logManagerIsEmpty = false;

        /// <summary>
        /// Получение инстации лог менеджера.
        /// </summary>
        protected ILogManager LogManager
        {
            get
            {
                if (logManager != null || logManagerIsEmpty)
                {
                    return logManager;
                }

                IUnityContainer container = UnityFactory.GetContainer();
                if (container.IsRegistered<ILogManager>())
                {
                    logManager = container.Resolve<ILogManager>();

                    return logManager;
                }
                else
                {
                    logManagerIsEmpty = true;
                    return null;
                }
            }
        }
        // *** End programmer edit section *** (LogChanging CustomMembers)


        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateApplicationLog(Objects.ApplicationLog UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateApplicationLog)

            if (UpdatedObject.GetStatus() == ObjectStatus.Created)
            {
                if (LogManager != null)
                {
                    LogManager.OnNewLogEntryAdded(new DataObjectIdEventArgs
                    {
                        DataObjectId = UpdatedObject.__PrimaryKey
                    });
                }
            }

            return new ICSSoft.STORMNET.DataObject[] { UpdatedObject };
            // *** End programmer edit section *** (OnUpdateApplicationLog)
        }
    }
}
