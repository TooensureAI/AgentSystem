using AgentSystem.Web.Resources.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Blazor.Services;

namespace AgentSystem.Web.Services
{
	public class ResxLocalizer : ITelerikStringLocalizer
	{
		public string this[string name]
		{
			get
			{
				return GetStringFromResource(name);
			}
		}

		public string GetStringFromResource(string key)
		{
			return TelerikMessages.ResourceManager.GetString(key, TelerikMessages.Culture) ?? string.Empty;
		}
	}
}
