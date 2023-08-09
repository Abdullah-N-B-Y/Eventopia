using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.DTO
{
	public class ResponseBody
	{
		public string? Content { get; set; }

		public ResponseBody(string? content)
		{
			Content = content;
		}
	}
}
