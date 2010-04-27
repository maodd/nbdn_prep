using System;

namespace nothinbutdotnetprep.infrastructure.events
{
	public class Running
	{
		Action action;
		Exception exception;

		public Running(Action action)
		{
			this.action = action;

			try
			{
				foreach (var action_delegate in action.GetInvocationList())
				{
					action_delegate.DynamicInvoke();
				}
			}
			catch (Exception e)
			{
				exception = e.InnerException;
			}
		}

		public Exception get_resulting_exception()
		{
			if (exception != null)
			{
				return new ArgumentException(exception.Message, exception);
			}
			return null;
		}
	}
}
