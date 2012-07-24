using System;
using System.Diagnostics;
using HintRelic.Data;
using System.Text;

namespace HintRelic.Logging
{
    public class LogListener : TraceListener
    {
        #region Constructors

        public LogListener() { }

        public LogListener(string r_strListenerName) : base(r_strListenerName) { }

        #endregion

        #region Methods

        public void OnLogCreated(Log log)
        {
            if (LogCreated != null)
                LogCreated(this, new LogCreatedEventArgs(log));
        }

        public override void Write(object o, string category)
        {
            if (o is Exception)
            {
                Exception ex = (Exception)o;
                StringBuilder sbMessage = new StringBuilder();
                do
                {
                    sbMessage.Append(ex.Message + Environment.NewLine);
                    ex = ex.InnerException;

                } while (ex != null);

                Write(sbMessage.ToString(), category);
            }
            else
                Write(o.ToString(), category);
        }

        public override void Write(string message, string category)
        {
            //if (category.Equals(LoggingCategory.Debug) && !Utility.ToBoolean(ConfigurationManager.AppSettings["DebugMode"]))
            //    return;

            StackTrace stackTrace = new StackTrace(true);
            Log log = new Log()
            {
                log_id = Guid.NewGuid().ToString(),
                log_date = DateTime.UtcNow,
                log_category = category,
                log_description = message,
                stack_trace = stackTrace.ToString()
            };

            OnLogCreated(log);
        }

        public override void Write(string message)
        {
            StackTrace stackTrace = new StackTrace(true);
            Log log = new Log()
            {
                log_id = Guid.NewGuid().ToString(),
                log_date = DateTime.UtcNow,
                log_category = string.Empty,
                log_description = message,
                stack_trace = stackTrace.ToString()
            };

            OnLogCreated(log);
        }

        public override void Write(object o)
        {
            if (o is Exception)
            {
                Exception ex = (Exception)o;
                StringBuilder sbMessage = new StringBuilder();
                do
                {
                    sbMessage.Append(ex.Message + Environment.NewLine);
                    ex = ex.InnerException;

                } while (ex != null);

                Write(sbMessage.ToString());
            }
            else
                Write(o.ToString());
        }

        public override void WriteLine(object o, string category)
        {
            if (o is Exception)
            {
                Exception ex = (Exception)o;
                StringBuilder sbMessage = new StringBuilder();
                do
                {
                    sbMessage.Append(ex.Message + Environment.NewLine);
                    ex = ex.InnerException;

                } while (ex != null);

                Write(sbMessage.ToString(), category);
            }
            else
                WriteLine(o.ToString(), category);
        }

        public override void WriteLine(string message, string category)
        {
            Write(message + Environment.NewLine, category);
        }

        public override void WriteLine(string message)
        {
            Write(message + Environment.NewLine);
        }

        public override void WriteLine(object o)
        {
            if (o is Exception)
            {
                Exception ex = (Exception)o;
                StringBuilder sbMessage = new StringBuilder();
                do
                {
                    sbMessage.Append(ex.Message + Environment.NewLine);
                    ex = ex.InnerException;

                } while (ex != null);

                Write(sbMessage.ToString());
            }
            else
                WriteLine(o.ToString());
        }

        #endregion

        #region Events

        public event EventHandler<LogCreatedEventArgs> LogCreated;

        #endregion
    }

    #region LogCreatedEventArgs class

    public class LogCreatedEventArgs : EventArgs
    {
        #region Constructors

        public LogCreatedEventArgs(Log log)
        {
            this.Log = log;
        }

        #endregion

        #region Properties

        public Log Log { get; set; }

        #endregion
    }

    #endregion
}
