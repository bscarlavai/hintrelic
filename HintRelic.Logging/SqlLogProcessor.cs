using System;
using HintRelic.Data;

namespace HintRelic.Logging
{
    public class SqlLogProcessor
    {
        #region Methods

        public static void Listen(LogListener LogListener)
        {
            LogListener.LogCreated += new EventHandler<LogCreatedEventArgs>(LogListener_LogCreated);
        }

        private static void LogListener_LogCreated(object sender, LogCreatedEventArgs e)
        {
            try
            {
                _dataContext.Logs.AddObject(e.Log);
                _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Fields

        private static hintrelicEntities _dataContext = new hintrelicEntities();

        #endregion
    }
}
